using BooksPenalty.Api.Data;
using BooksPenalty.Api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BooksPenalty.Api.Installers;

public sealed class SqlServerInstaller : IInstaller
{
	public void InstallService(IConfiguration configuration, IServiceCollection serviceCollection)
	{
		serviceCollection.AddDbContext<AppDbContext>(opts =>
			opts.UseSqlServer(
				configuration.GetConnectionString("DefaultConnection")));
	}
}