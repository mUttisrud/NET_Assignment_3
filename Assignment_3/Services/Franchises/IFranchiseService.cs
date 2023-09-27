using Assignment_3.Data.Models;

namespace Assignment_3.Services.Movies
{
    public interface IFranchiseService : ICrudService<Franchise, int>
    {
        Task<ICollection<Character>> GetCharactersAsync(int id);
        Task<ICollection<Movie>> GetMoviesAsync(int id);
    }
}
