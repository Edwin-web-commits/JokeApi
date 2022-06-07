using System.ComponentModel.DataAnnotations.Schema;

namespace JokeApi.Data
{
    public class Comment
    {
        public int Id { get; set; }
        public string Body { get; set; }


        [ForeignKey(nameof(UserId))]
        public string UserId { get; set; }
        public User User { get; set; }


        [ForeignKey(nameof(JokeId))]
        public int JokeId { get; set; }
        public Joke Joke { get; set; }
    }
}
