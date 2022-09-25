using BooksPenalty.Api.Data;
using BooksPenalty.Api.Interfaces.Repositories;
using BooksPenalty.Api.Models;

namespace BooksPenalty.Api.Repositories
{
	public class BookRepository : BaseRepository<Book>, IBookRepository
	{
		private readonly AppDbContext _context;

		public BookRepository(AppDbContext context) : base(context)
		{
			_context = context;
		}

		public async Task AddNewBookPenalty(Book book, Customer customer, decimal penaltyAmount)
		{
			var bookPenalty = new BookPenalty()
			{
				Customer = customer,
				Book = book,
				PenaltyAmount = penaltyAmount
			};
			await _context.BookPenalties.AddAsync(bookPenalty);
			await _context.SaveChangesAsync();
		}
	}
}
