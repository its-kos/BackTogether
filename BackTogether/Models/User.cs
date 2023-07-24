using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackTogether.Models {
    public class User {
        public int Id { get; set; }

		[StringLength(30, ErrorMessage = "First name cannot be longer than 30 characters.")]
		public string? FirstName { get; set; }

		[StringLength(30, ErrorMessage = "Last name cannot be longer than 30 characters.")]
		public string? LastName { get; set; }

		public string FullName { 
            get { 
                if ((FirstName == null) && (LastName == null)) {
                    return string.Empty;
                } else {
                    return FirstName + " " + LastName;
                }
            } 
        }

		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
		public DateTime SignupDate { get; set; } 

		[StringLength(30, MinimumLength = 3, ErrorMessage = "Username must be between 3 and 30 characters.")]
		public string Username { get; set; } = string.Empty;

		[StringLength(50, MinimumLength = 5, ErrorMessage = "Password must be between 5 and 50 characters.")]
		[DataType(DataType.Password)]
		public string Password { get; set; } = string.Empty;

		[DataType(DataType.EmailAddress)]
		public string Email { get; set; } = string.Empty;
        public virtual ICollection<Project>? Projects { get; } = null!;
		public virtual ICollection<Backing>? Backings { get; } = null!;
		public bool HasAdminPrivileges { get; set; }

		// public int? ImageURLId { get; set; }
		// public virtual ResourceURL? ImageURL { get; set; }
	}
}
