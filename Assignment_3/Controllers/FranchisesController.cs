using Assignment_3.Data.DTOs.Franchises;
using Assignment_3.Data.Exceptions;
using Assignment_3.Data.Models;
using Assignment_3.Services.Movies;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_3.Controllers {

    [Route("api/v1/Franchises")]
    [ApiController]
    public class FranchisesController : ControllerBase {
        private readonly IFranchiseService _service;
        private readonly IMapper _mapper;

        public FranchisesController(IFranchiseService service, IMapper mapper) {
            _service = service;
            _mapper = mapper;
        }

        // GET: api/Franchises
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FranchiseDTO>>> GetFranchises() {
            return Ok(_mapper.Map<IEnumerable<FranchiseDTO>>(await _service.GetAllAsync()));
        }

        // GET: api/Franchises{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<FranchiseDTO>> GetFranchise(int id) {
            try {
                return Ok(_mapper.Map<FranchiseDTO>(
                    await _service.GetByIdAsync(id)));
            }
            catch (EntityNotFoundException ex) {
                return NotFound(ex.Message);

            }
        }
        // PUT: api/Francises{id}
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

        // DELETE: api/Franchises{id}
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

        // POST: api/Franchises
        [HttpPost]
        public async Task<ActionResult<FranchiseDTO>> PostFranchise(FranchisePostDTO franchise) {
            var newFranchise = await _service.AddAsync(_mapper.Map<Franchise>(franchise));

            return CreatedAtAction("GetFranchise",
                new { id = newFranchise.Id },
                _mapper.Map<FranchiseDTO>(newFranchise));
        }
    }
}