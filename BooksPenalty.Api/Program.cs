using BooksPenalty.Api.Interfaces;
using BooksPenalty.Api.Interfaces.Repositories;
using BooksPenalty.Api.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();
builder.Services.AddTransient(
	typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddTransient<IBookRepository, BookRepository>();

var installers = typeof(Program).Assembly.ExportedTypes
	.Where(x =>
	typeof(IInstaller).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
	.Select(Activator.CreateInstance)
	.Cast<IInstaller>()
	.ToList();

installers.ForEach(i => i.InstallService(builder.Configuration, builder.Services));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}
app.UseCors(x => x
	.AllowAnyMethod()
	.AllowAnyHeader()
	.SetIsOriginAllowed(origin => true)
	.AllowCredentials());
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();