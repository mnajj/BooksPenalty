namespace BooksPenalty.Client.Models;

public class User
{
	public Guid Id { get; set; }


	public User()
	{
		BookPenalties = new HashSet<BookPenalty>();
	}

	public virtual ICollection<BookPenalty> BookPenalties { get; set; }
}