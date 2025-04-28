using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovieCollectionAPI.DTOs;
using MovieCollectionAPI.Services;

namespace MovieCollectionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        // GET: api/Movies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieDto>>> GetMovies()
        {
            var movies = await _movieService.GetAllMoviesAsync();
            return Ok(movies);
        }


        // GET: api/Movies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MovieDto>> GetMovie(int id)
        {
            var movie = await _movieService.GetMovieByIdAsync(id);

            if (movie == null)
            {
                return NotFound();
            }

            return Ok(movie);
        }


        // POST: api/Movies
        [HttpPost]
        public async Task<ActionResult<MovieDto>> CreateMovie(CreateMovieDto createMovieDto)
        {
            var movie = await _movieService.CreateMovieAsync(createMovieDto);
            return CreatedAtAction(nameof(GetMovie), new { id = movie.Id }, movie);
        }


        // PUT: api/Movies/5
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMovie(int id, UpdateMovieDto updateMovieDto)
        {
            var result = await _movieService.UpdateMovieAsync(id, updateMovieDto);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }


        // DELETE: api/Movies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            var result = await _movieService.DeleteMovieAsync(id);

            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }




    }
}
