using MovieCollectionAPI.DTOs;
using MovieCollectionAPI.Models;
using MovieCollectionAPI.Repositories;

namespace MovieCollectionAPI.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;

        public MovieService(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<IEnumerable<MovieDto>> GetAllMoviesAsync()
        {
            var movies = await _movieRepository.GetAllMoviesAsync();
            return movies.Select(m => MapToDto(m));
        }

        public async Task<MovieDto?> GetMovieByIdAsync(int id)
        {
            var movie = await _movieRepository.GetMovieByIdAsync(id);
            return movie != null ? MapToDto(movie) : null;
        }

        public async Task<MovieDto> CreateMovieAsync(CreateMovieDto createMovieDto)
        {
            var movie = new Movie
            {
                Title = createMovieDto.Title,
                Director = createMovieDto.Director,
                ReleaseYear = createMovieDto.ReleaseYear,
                Genre = createMovieDto.Genre,
                Rating = createMovieDto.Rating,
                Watched = createMovieDto.Watched
            };

            var createdMovie = await _movieRepository.AddMovieAsync(movie);
            return MapToDto(createdMovie);
        }

        public async Task<bool> UpdateMovieAsync(int id, UpdateMovieDto updateMovieDto)
        {
            var movie = await _movieRepository.GetMovieByIdAsync(id);
            if (movie == null)
            {
                return false;
            }

            movie.Title = updateMovieDto.Title;
            movie.Director = updateMovieDto.Director;
            movie.ReleaseYear = updateMovieDto.ReleaseYear;
            movie.Genre = updateMovieDto.Genre;
            movie.Rating = updateMovieDto.Rating;
            movie.Watched = updateMovieDto.Watched;

            await _movieRepository.UpdateMovieAsync(movie);
            return true;
        }

        public async Task<bool> DeleteMovieAsync(int id)
        {
            return await _movieRepository.DeleteMovieAsync(id);
        }

        private static MovieDto MapToDto(Movie movie)
        {
            return new MovieDto
            {
                Id = movie.Id,
                Title = movie.Title,
                Director = movie.Director,
                ReleaseYear = movie.ReleaseYear,
                Genre = movie.Genre,
                Rating = movie.Rating,
                Watched = movie.Watched
            };
        }
    }
}