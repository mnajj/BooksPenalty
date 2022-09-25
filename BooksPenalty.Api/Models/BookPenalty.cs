using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BooksPenalty.Api.Models
{
	public class BookPenalty
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public Guid Id { get; set; }
		[Key]
		public Guid CustomerId { get; set; }
		[Key]
		public Guid BookId { get; set; }

		public decimal PenaltyAmount { get; set; }

		public virtual Book Book { get; set; }
		public virtual Customer Customer { get; set; }
	}
}
