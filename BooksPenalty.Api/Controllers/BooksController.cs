using BooksPenalty.Api.Dtos;
using BooksPenalty.Api.Interfaces.Repositories;
using BooksPenalty.Api.Models;
using BooksPenalty.PenaltyCalculatorLibrary;
using Microsoft.AspNetCore.Mvc;

namespace BooksPenalty.Api.Controllers;

[Route("books")]
[ApiController]
public class BookController : ControllerBase
{
	private readonly IBookRepository _bookRepository;
	private readonly IBaseRepository<Customer> _customeRepository;

	public BookController(IBookRepository bookRepository, IBaseRepository<Customer> customeRepository)
	{
		_bookRepository = bookRepository;
		_customeRepository = customeRepository;
	}

	[HttpGet]
	public async Task<IActionResult> GetAllBooks()
	{
		var books = await _bookRepository.GetAllAsync();
		return Ok(books.ToList());
	}

	[HttpPost("penalty")]
	public async Task<IActionResult> GetPenalty(PenaltyReadDto penaltyReadDto)
	{
		var res = await PenaltyCalculator
			.Calculate(penaltyReadDto.StartDate, penaltyReadDto.EndDate, penaltyReadDto.Country);
		var customer = await _customeRepository.FirstOrDefaultAsync();
		var book = await _bookRepository.FindAsync(x => x.Id == penaltyReadDto.bookId);
		await _bookRepository.AddNewBookPenalty(book, customer, res);
		return Ok(res);
	}
}