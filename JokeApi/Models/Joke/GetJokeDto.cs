using JokeApi.Models.Comment;
using System.ComponentModel.DataAnnotations.Schema;

namespace JokeApi.Models.Joke
{
    public class GetJokeDto
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public string UserId { get; set; }
    }

    

    
}
