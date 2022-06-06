using JokeApi.Data;
using JokeApi.IRepository;

namespace JokeApi.Repository
{
    public class CommentsRepository : GenericRepository<Comment>, ICommentsRepository
    {
        public CommentsRepository(JokeApiDbContext context) : base(context)
        {
        }
    }

}
