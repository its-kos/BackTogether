using BackTogether.Data;
using BackTogether.Models;
using BackTogether.Services.api;
using Humanizer;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Linq;

namespace BackTogether.Services {
    public class DatabaseService : IDatabase {

        private readonly BackTogetherContext _context;

        public DatabaseService(BackTogetherContext context) {
            _context = context;
        }

        public async Task<int> CreateUser(User user) {
            //user.ImageURL = GetResourceUrlById(user.ImageURLId);
            _context.Add(user);
            return await _context.SaveChangesAsync();
        }
        public async Task<int> CreateProject(Project project) {
            //project = await GetUserById(project.Id);
            _context.Add(project);
            return await _context.SaveChangesAsync();
        }


        /*  
         *  Read 
         */
        public async Task<User?> GetUserById(int? id) {
            var user = await _context.Users.FirstOrDefaultAsync(m => m.Id == id);
            if (user == null) {
                return null;
            }
            return user;
        }

        // Get creator of Project
        public async Task<User?> GetUserByProjectId(int projectId) {
            //var userId = _context.Projects.Include(n => n.UserId).Where(n => n.Id == projectId).Select(n => n.UserId).Single();
            var user = await GetUserById(4);
            if (user == null) {
                return null;
            }
            return user;
        }

        public async Task<List<User>> GetAllUsers() {
            return await _context.Users.ToListAsync();
        }

        public async Task<Project?> GetProjectById(int id) {
            var project = await _context.Projects.FirstOrDefaultAsync(m => m.Id == id);
            if (project == null) {
                return null;
            }
            return project;
        }

        // Get all projects created by User
        public async Task<List<Project>?> GetCreatedProjectsByUserId(int userId) {
            var projects = await _context.Projects.ToListAsync();
            if (projects == null) {
                return null;
            }
            return projects;
        }
        public async Task<List<Project>?> GetBackedProjectsByUserId(int userId) {
            var projects = await (from n in _context.Projects
                            select n).ToListAsync();
            if (projects == null) {
                return null;
            }
            return projects;
        }
        public async Task<List<Project>> GetAllProjects(int amount) {
            // Sorting by date created by default
            var projects = await _context.Projects.OrderBy(n => n.DateCreated).Take(amount).ToListAsync();
            return projects;
        }


        /* 
         * Update 
         */
        public async Task<User> UpdateUser(User user) {
            throw new NotImplementedException();
        }

        public async Task<Project> UpdateProject(Project project) {
            throw new NotImplementedException();
        }

        /* 
         * Delete 
         */

        public async Task<bool> DeleteUser(int id) {
            var userToDelete = await GetUserById(id);
            if (userToDelete == null) {
                return false;
            } else {
                _context.Users.Remove(userToDelete);
                await _context.SaveChangesAsync();
                return true;
            }
        }

        public async Task<bool> DeleteProject(int id) {
            var projectToDelete = await GetProjectById(id);
            if (projectToDelete == null) {
                return false;
            } else {
                _context.Projects.Remove(projectToDelete);
                _context.SaveChanges();
                return true;
            }
        }
    }
}
