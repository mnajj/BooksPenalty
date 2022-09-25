using BooksPenalty.Api.Models;

namespace BooksPenalty.Api.Interfaces.Repositories
{
	public interface IBookRepository : IBaseRepository<Book>
	{
		Task AddNewBookPenalty(Book book, Customer customer, decimal penaltyAmount);
	}
}
