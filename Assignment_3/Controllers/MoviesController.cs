using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Assignment_3.Data.Models;
using Assignment_3.Services.Movies;
using Assignment_3.Data.DTOs.Movies;
using Microsoft.VisualBasic;
using AutoMapper;
using Assignment_3.Data.Exceptions;

namespace Assignment_3.Controllers
{
    [Route("api/v1/Movies")]
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

        // GET: api/Movies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MovieGetDTO>>> GetMovies()
        {
            return Ok(_mapper.Map<IEnumerable<MovieGetDTO>>(await _service.GetAllAsync()));
        }

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

        [HttpPut("{id}")]
        public async Task<IActionResult> PutMovie(int id, MoviePutDTO movie)
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

        [HttpPost]
        public async Task<ActionResult<MovieGetDTO>> PostMovie(MoviePostDTO movie)
        {
            var newMovie = await _service.AddAsync(_mapper.Map<Movie>(movie));

            return CreatedAtAction("GetMovie", 
                new { id = newMovie.Id },
                _mapper.Map<MovieGetDTO>(newMovie));
        }

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
    }
}
