using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Assignment_3.Data.Models;
using Assignment_3.Services.Characters;
using Assignment_3.Data.DTOs.Characters;
using Microsoft.VisualBasic;
using AutoMapper;
using Assignment_3.Data.Exceptions;

namespace Assignment_3.Controllers
{
    [Route("api/v1/Characters")]
    [ApiController]
    public class CharactersController : ControllerBase
    {
        private readonly ICharacterService _service;
        private readonly IMapper _mapper;

        public CharactersController(ICharacterService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        // GET: api/Characters
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CharacterDTO>>> GetCharacters()
        {
            return Ok(_mapper.Map<IEnumerable<CharacterDTO>>(await _service.GetAllAsync()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CharacterDTO>> GetCharacter(int id)
        {
            try
            {
                return Ok(_mapper.Map<CharacterDTO>(
                    await _service.GetByIdAsync(id)));
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCharacter(int id, CharacterPutDTO Character)
        {
            if (id != Character.Id)
            {
                return BadRequest();
            }

            try
            {
                await _service.UpdateAsync(_mapper.Map<Character>(Character));
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound(ex.Message);
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<CharacterDTO>> PostCharacter(CharacterPostDTO Character)
        {
            var newCharacter = await _service.AddAsync(_mapper.Map<Character>(Character));

            return CreatedAtAction("GetCharacter",
                new { id = newCharacter.Id },
                _mapper.Map<CharacterDTO>(newCharacter));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCharacter(int id)
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
