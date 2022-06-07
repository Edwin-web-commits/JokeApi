using System.ComponentModel.DataAnnotations.Schema;

namespace JokeApi.Data
{
    public class Joke
    {
        public int Id { get; set; }
        public string Body { get; set; }

        public virtual IList<Comment> Comments { get; set; }


        [ForeignKey(nameof(UserId))]
        public string UserId { get; set; }
        public User User { get; set; }

    }

  
}