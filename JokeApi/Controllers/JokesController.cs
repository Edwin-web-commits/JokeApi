using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JokeApi.Data;
using JokeApi.Models.Joke;
using AutoMapper;
using JokeApi.IRepository;

namespace JokeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JokesController : ControllerBase
    {
        
        private readonly IMapper _mapper;
        private readonly IJokesRepository _jokesRepository;

        public JokesController( IMapper mapper, IJokesRepository jokesRepository)
        {
           
            this._mapper = mapper;
            this._jokesRepository = jokesRepository;
        }

        // GET: api/Jokes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetJokeDto>>> GetJoke()
        {
            var jokes = await _jokesRepository.GetAllAsync();
            var records =_mapper.Map<List<GetJokeDto>>(jokes);
            return Ok(records);
        }

        // GET: api/Jokes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<JokeDto>> GetJoke(int id)
        {
            var joke = await _jokesRepository.GetDetails(id);

            if (joke == null)
            {
                return NotFound();
            }
            var jokeDto = _mapper.Map<JokeDto>(joke);
            return Ok(jokeDto);
        }

        // PUT: api/Jokes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutJoke(int id, UpdateJokeDto updateJokeDto)
        {
            if (id != updateJokeDto.Id)
            {
                return BadRequest();
            }

            //  _context.Entry(joke).State = EntityState.Modified;
            var joke = await _jokesRepository.GetAsync(id);

            if(joke == null)
            {
                return NotFound();
            }

            _mapper.Map(updateJokeDto,joke);

            try
            {
                await _jokesRepository.UpdateAsync(joke);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await JokeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Jokes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<JokeDto>> PostJoke(CreateJokeDto createJoke)
        {
            var joke = _mapper.Map<Joke>(createJoke);
            await _jokesRepository.AddAsync(joke);

            return CreatedAtAction("GetJoke", new { id = joke.Id }, joke);
        }

        // DELETE: api/Jokes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteJoke(int id)
        {
            var joke = await _jokesRepository.GetAsync(id);
            if (joke == null)
            {
                return NotFound();
            }
            await _jokesRepository.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> JokeExists(int id)
        {
            return await _jokesRepository.Exists(id);
        }
    }
}
