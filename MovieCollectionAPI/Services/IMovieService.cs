using MovieCollectionAPI.DTOs;

namespace MovieCollectionAPI.Services
{
    public interface IMovieService
    {

        Task<IEnumerable<MovieDto>> GetAllMoviesAsync();
        Task<MovieDto?> GetMovieByIdAsync(int id);
        Task<MovieDto> CreateMovieAsync(CreateMovieDto createMovieDto);
        Task<bool> UpdateMovieAsync(int id, UpdateMovieDto updateMovieDto);
        Task<bool> DeleteMovieAsync(int id);
    }
}
