using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackTogether.Models {
    public class Reward {
        public int Id { get; set; }

		[StringLength(50, ErrorMessage = "Reward name cannot be longer than 50 characters.")]
		public string Name { get; set; }

		[StringLength(100, ErrorMessage = "Description cannot be longer than 100 characters.")]
		public string? Description { get; set; }
		public int ProjectId { get; set; }
        public Project Project { get; set; } = null!;

		[DataType(DataType.Currency)]
		public decimal UnlockAmount { get; set; }
    }
}
