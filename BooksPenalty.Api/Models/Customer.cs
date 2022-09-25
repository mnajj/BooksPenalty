namespace BooksPenalty.Api.Models
{
	public class Customer
	{
		public Guid Id { get; set; }

		public Customer()
		{
			BookPenalties = new HashSet<BookPenalty>();
		}
		public virtual ICollection<BookPenalty> BookPenalties { get; set; }
	}
}
