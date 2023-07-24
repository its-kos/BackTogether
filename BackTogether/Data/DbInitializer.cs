using BackTogether.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace BackTogether.Data {
	public static class DbInitializer {

		public static void Initialize(BackTogetherContext context) {
			// Look for any Users.
			if (context.Users.Any()) {
				return;   // DB has already been seeded
			}

			var students = new User[] {
				new User { Username = "aFEf4w4f", Password = "NZ#7eYB%", Email = "example@email.com", HasAdminPrivileges = true },
				new User { Username = "fa4gfwff", Password = "6*%7rKNd", Email = "example1@email.com", HasAdminPrivileges = true },
				new User { Username = "tejh56eu", Password = "K^aB%s6T", Email = "example2@email.com", HasAdminPrivileges = false },
				new User { Username = "f34g34qg", Password = "Fg75^U@j", Email = "example3@email.com", HasAdminPrivileges = false },
				new User { Username = "fq34gqgf", Password = "#VEGu3it", Email = "example4@email.com", HasAdminPrivileges = false },
				new User { Username = "qf34gq3g", Password = "Cnk@XH23", Email = "example5@email.com", HasAdminPrivileges = false },
				new User { Username = "f34qg4q3", Password = "HpKY6N%X", Email = "example6@email.com", HasAdminPrivileges = true },
				new User { Username = "n4eh6wqw", Password = "P6@%R6%a", Email = "example7@email.com", HasAdminPrivileges = false }
			};

			context.Users.AddRange(students);
			context.SaveChanges();
		}
	}
}
