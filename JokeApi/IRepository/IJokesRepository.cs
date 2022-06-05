using JokeApi.Data;

namespace JokeApi.IRepository
{
    public interface IJokesRepository : IGenericRepository<Joke>
    {
        Task<Joke> GetDetails(int id);
    }
}
