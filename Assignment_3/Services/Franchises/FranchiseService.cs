using Assignment_3.Data.Exceptions;
using Assignment_3.Data.Models;
using Assignment_3.Services.Movies;
using Microsoft.EntityFrameworkCore;

namespace Assignment_3.Services.Franchises {
    public class FranchiseService : IFranchiseService 
    {
        private readonly Assignment3DbContext _context;
        public FranchiseService(Assignment3DbContext context) {
            _context = context;
        }
        public async Task<ICollection<Franchise>> GetAllAsync() {
            return await _context.Franchises
                .Include(franchise => franchise.Movies)
                .ToListAsync();
        }

        public async Task<Franchise> AddAsync(Franchise obj) {
            await _context.Franchises.AddAsync(obj);
            await _context.SaveChangesAsync();
            return obj;
        }

        public async Task<Franchise> GetByIdAsync(int id) {
            var franchise = await _context.Franchises
                                .Where(franchise => franchise.Id == id)
                                .Include(franchise => franchise.Movies)
                                .FirstAsync();
            if(franchise is null)
                throw new EntityNotFoundException(nameof(franchise), id);

            return franchise;
        }

        private async Task<bool> FranchiseExistsAsync(int id)
        {
            return await _context.Franchises.AnyAsync(franchise => franchise.Id == id);
        }

        public async Task<Franchise> UpdateAsync(Franchise obj) {
            if (!await FranchiseExistsAsync(obj.Id))
                throw new EntityNotFoundException(nameof(obj), obj.Id);

            obj.Movies.Clear();
            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();

            return obj;
        }

        public async Task DeleteByIdAsync(int id)
        {
            if (!await FranchiseExistsAsync(id))
                throw new EntityNotFoundException(nameof(Franchise), id);

            var franchise = await _context.Franchises
                                .Where(franchise => franchise.Id == id)
                                .FirstAsync();

            franchise.Movies.Clear();
            _context.Franchises.Remove(franchise);
            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<Character>> GetCharactersAsync(int id)
        {
            if (!await FranchiseExistsAsync(id))
                throw new EntityNotFoundException(nameof(Franchise), id);

            var franchise = await _context.Franchises
                .Where(franchise => franchise.Id == id)
                .Include(franchise => franchise.Movies) 
                .ThenInclude(movie => movie.Characters)
                .FirstAsync();

            List<Character> characters = new List<Character>();

            foreach (Movie movie in franchise.Movies)
            {
                foreach (Character character in movie.Characters)
                {
                    if(!characters.Contains(character))
                        characters.Add(character);
                }
            }

            return characters;
        }

        public async Task<ICollection<Movie>> GetMoviesAsync(int id)
        {
            if (!await FranchiseExistsAsync(id))
                throw new EntityNotFoundException(nameof(Franchise), id);

            var franchise = await _context.Franchises
                .Where(franchise => franchise.Id == id)
                .Include(franchise => franchise.Movies)
                .FirstAsync();

            List<Movie> movies = new List<Movie>();

            foreach(Movie movie in franchise.Movies)
            {
                movies.Add(movie);
            }

            return movies;
        }
    }
}