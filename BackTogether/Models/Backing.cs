using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackTogether.Models {
    public class Backing{
        public int Id { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; } = null!;
        public int ProjectId { get; set; }
        public Project? Project { get; set; } = null!;

        [DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
		public DateTime DateBacked { get; set; }

		[DataType(DataType.Currency)]
		public decimal Amount { get; set; }
    }
}
