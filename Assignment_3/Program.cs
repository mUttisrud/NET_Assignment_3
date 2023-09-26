using Assignment_3.Data.Models;
using Assignment_3.Services.Movies;
using Assignment_3.Services.Characters;
using Microsoft.EntityFrameworkCore;

namespace Assignment_3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddDbContext<Assignment3DbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Assignment3")));

            builder.Services.AddScoped<IMovieService, MovieService>(); 
            builder.Services.AddScoped<ICharacterService, CharacterService>();
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}