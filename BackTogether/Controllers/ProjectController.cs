﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BackTogether.Data;
using BackTogether.Models;
using BackTogether.Services.api;
using BackTogether.Helpers.Enums;

namespace BackTogether.Controllers {
    public class ProjectController : Controller {
        private readonly IDatabase _dbService;

        public ProjectController(IDatabase dbService) {
            _dbService = dbService;
        }

        // GET: Project
        // (Optionally) GET: Project/{amount}
        // QOL update - Enable sorting functionality
        public IActionResult Index(int amount = 100) {
            // Show 100 per page
            // Change this to show more 
            ViewData["projects"] = _dbService.GetAllProjects(amount);
			if (HttpContext.Session.GetInt32("SessionUserId") != null) {
				//If you get here α user is logged in
				ViewData["LoggedAdmin"] = HttpContext.Session.GetInt32("SessionUserAdminRights") == 1;
				return View();
			}
			return View();
        }

        // GET: Project/id/{id}
        [HttpGet]
        public IActionResult Id(int id) {
			Project project = _dbService.GetProjectById(id);
            if (project == null) {
                return View("Error");
            } else {
                // Show project page here
                return View(project);
            }
        }

        // GET: Project/Create
        // Check if user is logged in
        // * If yes -> Show project creation page
        // * If no -> redirect to login
        [HttpGet]
        public IActionResult Create() {
			if (HttpContext.Session.GetInt32("SessionUserId") != null) {
				//If you get here α user is logged in
				ViewBag.selectCategory = Enum.GetValues(typeof(Categories)).Cast<Categories>();
				return View();
			} else {
				return RedirectToAction("Login", "Home");
			}
			
        }

        // POST: Project/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        // See here: https://stackoverflow.com/questions/73734515/binding-complex-entities-inside-complex-entities-to-requests/73737722#73737722
        public IActionResult Create([Bind("Id,Title,Description,Category,UserId,DateCreated,CurrentFunding,FinalGoal")] Project project) {
            if (ModelState.IsValid) {
                project.UserId = HttpContext.Session.GetInt32("SessionUserId");
                project.DateCreated = DateTime.Now;
				_dbService.CreateProject(project);
            }
            return RedirectToAction("Index");
        }

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Delete(int id) {
            _dbService.DeleteProject((int)ViewData["ToDelete"]);
			return RedirectToAction("Index");
		}
	}
}
