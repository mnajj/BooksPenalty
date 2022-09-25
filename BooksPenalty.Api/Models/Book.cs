namespace BooksPenalty.Api.Models;

public class Book
{
	public Book()
	{
		BookPenalties = new HashSet<BookPenalty>();
	}

	public Guid Id { get; set; }
	public string Name { get; set; }
	public string Author { get; set; }
	public int Pages { get; set; }

	public virtual ICollection<BookPenalty> BookPenalties { get; set; }
}