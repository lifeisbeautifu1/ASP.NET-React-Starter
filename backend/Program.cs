using Backend.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
{
	var conn = builder.Configuration.GetConnectionString("DefaultConnection");

	builder.Services.AddDbContext<ApiDbContext>(options =>
		options.UseNpgsql(conn));

	builder.Services.AddControllers();

	builder.Services.AddEndpointsApiExplorer();

	builder.Services.AddSwaggerGen();
}

var app = builder.Build();
{
	app.UseSwagger();

	app.UseSwaggerUI();

	app.UseCors(options =>
	{
		options.AllowAnyHeader().AllowAnyHeader().AllowAnyOrigin();
	});

	// app.UseHttpsRedirection();

	app.UseAuthorization();

	app.MapControllers();

	app.Run();
}
