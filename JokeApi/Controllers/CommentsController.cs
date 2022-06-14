using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JokeApi.Data;
using JokeApi.IRepository;
using AutoMapper;
using JokeApi.Models.Comment;
using Microsoft.AspNetCore.Authorization;

namespace JokeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CommentsController : BaseController
    {
        
        private readonly ICommentsRepository _commentsRepository;
        private readonly IMapper _mapper;

        public CommentsController(ICommentsRepository commentsRepository, IMapper mapper)
        {
           
            this._commentsRepository = commentsRepository;
            this._mapper = mapper;
        }

        // GET: api/Comments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CommentDto>>> GetComments()
        {
            var comments = await _commentsRepository.GetAllAsync();
            return Ok(_mapper.Map<List<CommentDto>>(comments));
        }

        // GET: api/Comments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CommentDto>> GetComment(int id)
        {
            var comment = await _commentsRepository.GetAsync(id);  

            if (comment == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<CommentDto>(comment));
        }

        // PUT: api/Comments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        
        public async Task<IActionResult> PutComment(int id, UpdateCommentDto updateCommentDto)
        {
            if (id != updateCommentDto.Id)
            {
                return BadRequest();
            }

            var comment = await _commentsRepository.GetAsync(id);
            if (comment == null)
            {
                return NotFound();
            }

            _mapper.Map(updateCommentDto, comment);

            try
            {
                await _commentsRepository.UpdateAsync(comment);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await CommentExists(id))
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

        // POST: api/Comments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        
        public async Task<ActionResult<CommentDto>> PostComment(CreateCommentDto commentDto)
        {
            var comment = _mapper.Map<Comment>(commentDto);
            var userId = GetUserId();
            comment.UserId = userId;

            await _commentsRepository.AddAsync(comment);

            return CreatedAtAction("GetComment", new { id = comment.Id }, commentDto);
        }

        // DELETE: api/Comments/5
        [HttpDelete("{id}")]
        
        public async Task<IActionResult> DeleteComment(int id)
        {
            var comment = await _commentsRepository.GetAsync(id);
            if (comment == null)
            {
                return NotFound();
            }

           await _commentsRepository.DeleteAsync(id);

            return NoContent();
        }

        private async Task<bool> CommentExists(int id)
        {
            return await _commentsRepository.Exists(id);
        }
    }
}
