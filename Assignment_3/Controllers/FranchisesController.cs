using Assignment_3.Data.DTOs.Franchises;
using Assignment_3.Data.Exceptions;
using Assignment_3.Data.Models;
using Assignment_3.Services.Movies;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_3.Controllers {

    [Route("api/v1/Franchises")]
    [ApiController]
    public class FranchiseController : ControllerBase {
        private readonly IFranchiseService _service;
        private readonly IMapper _mapper;

        public FranchiseController(IFranchiseService service, IMapper mapper) {
            _service = service;
            _mapper = mapper;
        }

        // GET: api/Franchises
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FranchiseGetDTO>>> GetFranchises() {
            return Ok(_mapper.Map<IEnumerable<FranchiseGetDTO>>(await _service.GetAllAsync()));
        }

        // GET: api/Franchises{id}
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
        public async Task<ActionResult<FranchisePostDTO>> PostMovie(FranchisePostDTO franchise) {
            var newFranchise = await _service.AddAsync(_mapper.Map<Franchise>(franchise));

            return CreatedAtAction("GetFranchise",
                new { id = newFranchise.Id },
                _mapper.Map<FranchisePostDTO>(newFranchise));
        }
    }
}