using System.ComponentModel.DataAnnotations;
namespace BooksPenalty.Client.Models
{
	public class BookPenalty
	{
		[Key]
		public Guid UserId { get; set; }
		[Key]
		public Guid BookId { get; set; }

		public decimal PenaltyAmount { get; set; }

		public virtual Book Book { get; set; }
		public virtual User User { get; set; }
	}
}
