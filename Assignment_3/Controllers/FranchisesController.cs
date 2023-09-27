using Assignment_3.Data.DTOs.Franchises;
using Assignment_3.Data.Exceptions;
using Assignment_3.Data.Models;
using Assignment_3.Services.Movies;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_3.Controllers {

    [Route("api/v1/Franchises")]
    [Produces("application/json")]
    [ApiConventionType(typeof(DefaultApiConventions))] //This gives the correct status codes in the swagger docs
    [ApiController]
    public class FranchiseController : ControllerBase {
        private readonly IFranchiseService _service;
        private readonly IMapper _mapper;

        public FranchiseController(IFranchiseService service, IMapper mapper) {
            _service = service;
            _mapper = mapper;
        }

        /// <summary>
        ///     Gets all the franchises
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FranchiseGetDTO>>> GetFranchises() {
            return Ok(_mapper.Map<IEnumerable<FranchiseGetDTO>>(await _service.GetAllAsync()));
        }

        /// <summary>
        ///     Get one franchise by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<FranchiseGetDTO>> GetFrancise(int id) {
            try {
                return Ok(_mapper.Map<FranchiseGetDTO>(
                    await _service.GetByIdAsync(id)));
            }
            catch (EntityNotFoundException ex) {
                return NotFound(ex.Message);

            }
        }

        /// <summary>
        ///     Update one franchise
        /// </summary>
        /// <param name="id"></param>
        /// <param name="franchise"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFranchise(int id, FranchisePutDTO franchise) {
            if (id != franchise.Id) {
                return BadRequest();
            }
            try {
                await _service.UpdateAsync(_mapper.Map<Franchise>(franchise));
            }
            catch (EntityNotFoundException ex) {
                return NotFound(ex.Message);
            }
            return NoContent();
        }

        /// <summary>
        ///     Delete one franchise
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFranchise(int id) {
            try {
                await _service.DeleteByIdAsync(id);
                return NoContent();
            }
            catch (EntityNotFoundException ex) {
                return NotFound(ex.Message);
            }
        }

        /// <summary>
        ///     Add a new franchise
        /// </summary>
        /// <param name="franchise"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<FranchisePostDTO>> PostMovie(FranchisePostDTO franchise) {
            var newFranchise = await _service.AddAsync(_mapper.Map<Franchise>(franchise));

            return CreatedAtAction("GetFranchise",
                new { id = newFranchise.Id },
                _mapper.Map<FranchisePostDTO>(newFranchise));
        }
    }
}