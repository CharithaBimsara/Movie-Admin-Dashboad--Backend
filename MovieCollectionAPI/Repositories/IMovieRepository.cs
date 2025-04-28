using MovieCollectionAPI.Models;

namespace MovieCollectionAPI.Repositories
{
    public interface IMovieRepository
    {
        Task<IEnumerable<Movie>> GetAllMoviesAsync();
        Task<Movie?> GetMovieByIdAsync(int id);
        Task<Movie> AddMovieAsync(Movie movie);
        Task UpdateMovieAsync(Movie movie);
        Task<bool> DeleteMovieAsync(int id);
        Task<bool> MovieExistsAsync(int id);
    }
}
