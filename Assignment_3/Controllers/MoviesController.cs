using Microsoft.AspNetCore.Mvc;
using Assignment_3.Data.Models;
using Assignment_3.Services.Movies;
using Assignment_3.Data.DTOs.Movies;
using AutoMapper;
using Assignment_3.Data.Exceptions;
using Assignment_3.Data.DTOs.Characters;

namespace Assignment_3.Controllers
{
    [Route("api/v1/Movies")]
    [Produces("application/json")]
    [ApiConventionType(typeof(DefaultApiConventions))]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _service;
        private readonly IMapper _mapper;

        public MoviesController(IMovieService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        /// <summary>
        ///     Get all movies
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieGetDTO>>> GetMovies()
        {
            return Ok(_mapper.Map<IEnumerable<MovieGetDTO>>(await _service.GetAllAsync()));
        }

        /// <summary>
        ///     Get one movie by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<MovieGetDTO>> GetMovie(int id)
        {
            try
            {
                return Ok(_mapper.Map<MovieGetDTO>(
                    await _service.GetByIdAsync(id)));
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        /// <summary>
        ///     Update one movie
        /// </summary>
        /// <param name="id"></param>
        /// <param name="movie"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMovie(int id, MoviePutDTO movie)
        {
            if (id != movie.Id)
            {
                return BadRequest();
            }

            try
            {
                await _service.UpdateAsync(_mapper.Map<Movie>(movie));
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }

            return NoContent();
        }

        /// <summary>
        ///     Add a new movie
        /// </summary>
        /// <param name="movie"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<MovieGetDTO>> AddMovie(MoviePostDTO movie)
        {
            var newMovie = await _service.AddAsync(_mapper.Map<Movie>(movie));

            return CreatedAtAction("GetMovie",
                new { id = newMovie.Id },
                _mapper.Map<MovieGetDTO>(newMovie));
        }

        /// <summary>
        ///     Delete one movie
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMovie(int id)
        {
            try
            {
                await _service.DeleteByIdAsync(id);
                return NoContent();
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        /// <summary>
        ///     Get characters in movie
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}/Characters")]
        public async Task<ActionResult<IEnumerable<CharactersListDTO>>> GetCharactersInMovie(int id)
        {
            try
            {
                return Ok(_mapper.Map<IEnumerable<CharactersListDTO>>(await _service.GetAllCharactersByMovieIdAsync(id)));
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}