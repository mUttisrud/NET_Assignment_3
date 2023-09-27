using Assignment_3.Data.Models;
using Microsoft.EntityFrameworkCore;
using Assignment_3.Data.DTOs.Movies;
using Assignment_3.Data.Exceptions;

namespace Assignment_3.Services.Movies
{
    public class MovieService : IMovieService
    {
        private readonly Assignment3DbContext _context;
        public MovieService(Assignment3DbContext context)
        {
            _context = context;
        }
        public async Task<ICollection<Movie>> GetAllAsync()
        {
            return await _context.Movies
                                    .Include(movie => movie.Characters)
                                    .ToListAsync();
        }

        public async Task<Movie> AddAsync(Movie newMovie)
        {
            await _context.Movies.AddAsync(newMovie);
            await _context.SaveChangesAsync();
            return newMovie;
        }

        public async Task<Movie> GetByIdAsync(int id)
        {
            var movie = await _context.Movies.Where(movie => movie.Id == id)
                .Include(movie => movie.Characters)
                .FirstAsync();

            if (movie is null)
                throw new EntityNotFoundException(nameof(movie), id);

            return movie;

        }

        private async Task<bool> MovieExistsAsync(int id)
        {
            return await _context.Movies.AnyAsync(movie => movie.Id == id);
        }

        public async Task<Movie> UpdateAsync(Movie obj)
        {
            if (!await MovieExistsAsync(obj.Id))
                throw new EntityNotFoundException(nameof(Movie), obj.Id);

            if(obj.Characters != null)
                obj.Characters.Clear();

            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();

            return obj;
        }

        public async Task DeleteByIdAsync(int id)
        {
            if (!await MovieExistsAsync(id))
                throw new EntityNotFoundException(nameof(Movie), id);

            var movie = await _context.Movies
               .Where(movie => movie.Id == id)
               .FirstAsync();

            if (movie.Characters != null)
                movie.Characters.Clear();

            _context.Movies.Remove(movie);

            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<Character>> GetAllCharactersByMovieIdAsync(int id)
        {
            if (!await MovieExistsAsync(id))
                throw new EntityNotFoundException(nameof(Movie), id);

            var movie = await _context.Movies
                .Where(movie => movie.Id == id)
                .Include(movie => movie.Characters)
                .FirstAsync();

            List<Character> result = new List<Character>();

            foreach (Character character in movie.Characters)
            {
                result.Add(character);
            }
            
            return result;
        }
    }
}
