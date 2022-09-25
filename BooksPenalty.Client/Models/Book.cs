namespace BooksPenalty.Client.Models;

public class Book
{
	public Guid Id { get; set; }
	public string Name { get; set; }
	public string Author { get; set; }
	public int Pages { get; set; }

	public virtual ICollection<BookPenalty> BookPenalties { get; set; }

	public Book()
	{
		BookPenalties = new HashSet<BookPenalty>();
	}
}