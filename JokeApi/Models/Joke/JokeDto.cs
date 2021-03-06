using JokeApi.Models.Comment;

namespace JokeApi.Models.Joke
{
    public class JokeDto
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public string UserId { get; set; }

        public List<CommentDto> Comments { get; set; }
    }
}
