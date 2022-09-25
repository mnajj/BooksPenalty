namespace BooksPenalty.Api.Interfaces;

public interface IInstaller
{
	void InstallService(IConfiguration configuration, IServiceCollection serviceCollection);
}