using Assignment_3.Data.Exceptions;
using Assignment_3.Data.Models;
using Assignment_3.Services.Movies;
using Microsoft.EntityFrameworkCore;

namespace Assignment_3.Services.Franchises {
    public class FranchiseService : IFranchiseService {
        private readonly Assignment3DbContext _context;
        public FranchiseService(Assignment3DbContext context) {
            _context = context;
        }
        public async Task<ICollection<Franchise>> GetAllAsync() {
            return await _context.Franchises.ToListAsync();
        }

        public Task<Franchise> AddAsync(Franchise obj) {
            throw new NotImplementedException();
        }

        public Task<Franchise> GetByIdAsync(int id) {
            throw new NotImplementedException();
        }

        public Task<Franchise> UpdateAsync(Franchise obj) {
            throw new NotImplementedException();
        }

        public Task DeleteByIdAsync(int id) {
            throw new NotImplementedException();
        }
    }
}