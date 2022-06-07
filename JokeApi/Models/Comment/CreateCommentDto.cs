using System.ComponentModel.DataAnnotations;

namespace JokeApi.Models.Comment
{
    public class CreateCommentDto
    {
        [Required]
        public string Body { get; set; }


        


        public int JokeId { get; set; }
    }
}
