using JokeApi.Data;
using JokeApi.IRepository;
using Microsoft.EntityFrameworkCore;

namespace JokeApi.Repository
{
    public class JokesRepository : GenericRepository<Joke>, IJokesRepository
    {
        private readonly JokeApiDbContext _context;

        public JokesRepository(JokeApiDbContext context) : base(context)
        {
            this._context = context;
        }

        public async Task<Joke> GetDetails(int id)
        {
           return await _context.Joke.Include(q => q.Comments).FirstOrDefaultAsync(q => q.Id == id);
        }
    }
}
