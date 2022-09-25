using BooksPenalty.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace BooksPenalty.Api.Data;

public sealed class AppDbContext : DbContext
{
	public DbSet<Book> Books { get; set; }
	public DbSet<User> Users { get; set; }
	public DbSet<Customer> Customers { get; set; }
	public DbSet<BookPenalty> BookPenalties { get; set; }

	public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
	{
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.Entity<BookPenalty>()
			.HasKey(k => new
			{
				k.Id,
				k.BookId,
				k.CustomerId
			});

		modelBuilder.Entity<Customer>()
			.HasData(new Customer { Id = Guid.NewGuid() });

		modelBuilder.Entity<Book>()
			.HasData(new Book { Id = Guid.NewGuid(), Name = "Moby-Dick", Author = "Herman Melville", Pages = 558 });
		base.OnModelCreating(modelBuilder);
	}
}