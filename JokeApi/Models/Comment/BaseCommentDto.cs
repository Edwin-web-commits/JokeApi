using System.ComponentModel.DataAnnotations;

namespace JokeApi.Models.Comment
{
    public abstract class BaseCommentDto
    {
        [Required]
        public string Body { get; set; }

        
        public int UserId { get; set; }

      
        public int JokeId { get; set; }
    }
}
