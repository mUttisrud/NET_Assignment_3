using Assignment_3.Data.Exceptions;
using Assignment_3.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Assignment_3.Services.Characters
{
    public class CharacterService : ICharacterService
    {
        private readonly Assignment3DbContext _context;
        public CharacterService(Assignment3DbContext context)
        {
            _context = context;
        }
        public async Task<ICollection<Character>> GetAllAsync()
        {
            return await _context.Characters
                                    .Include(character => character.Movies)
                                    .ToListAsync();
        }

        public async Task<Character> AddAsync(Character newCharacter)
        {
            await _context.Characters.AddAsync(newCharacter);
            await _context.SaveChangesAsync();
            return newCharacter;
        }

        public async Task<Character> GetByIdAsync(int id)
        {
            var Character = await _context.Characters.Where(Character => Character.Id == id)
                .Include(Character => Character.Movies)
                .FirstAsync();

            if (Character is null)
                throw new EntityNotFoundException(nameof(Character), id);

            return Character;

        }

        private async Task<bool> CharacterExistsAsync(int id)
        {
            return await _context.Characters.AnyAsync(Character => Character.Id == id);
        }

        public async Task<Character> UpdateAsync(Character obj)
        {
            if (!await CharacterExistsAsync(obj.Id))
                throw new EntityNotFoundException(nameof(Character), obj.Id);

            if (obj.Movies != null)
                obj.Movies.Clear();

            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();

            return obj;
        }

        public async Task DeleteByIdAsync(int id)
        {
            if (!await CharacterExistsAsync(id))
                throw new EntityNotFoundException(nameof(Character), id);

            var CharacterToDelete = await _context.Characters
               .Where(Character => Character.Id == id)
               .FirstAsync();

            if (CharacterToDelete.Movies != null)
                CharacterToDelete.Movies.Clear();

            _context.Characters.Remove(CharacterToDelete);

            await _context.SaveChangesAsync();
        }
    }
}
