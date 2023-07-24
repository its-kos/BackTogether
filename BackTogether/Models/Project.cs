using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace BackTogether.Models {
    public class Project {
        public int Id { get; set; }

		[StringLength(50, ErrorMessage = "Project title cannot be longer than 50 characters.")]
		public string Title { get; set; }

		[StringLength(100, ErrorMessage = "Project description cannot be longer than 100 characters.")]
		public string? Description { get; set; }
        public Helpers.Enums.Categories Category { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateCreated { get; set; }

		[DataType(DataType.Currency)]
		public decimal CurrentFunding { get; set; }

		[DataType(DataType.Currency)]
		public decimal FinalGoal { get; set; }
		public virtual ICollection<Backing>? Backings { get; set; }
        public virtual ICollection<Reward>? Rewards { get; set; }

		// public virtual ICollection<ResourceURL> ImageURLS { get; set; }
	}
}
