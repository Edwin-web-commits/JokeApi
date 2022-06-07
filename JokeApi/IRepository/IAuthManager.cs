using JokeApi.Models.Users;
using Microsoft.AspNetCore.Identity;

namespace JokeApi.IRepository
{
    public interface IAuthManager
    {
        Task<IEnumerable<IdentityError>> Register(UserDto userDto);
        Task<AuthResponseDto>Login(UserDto userDto);
    }
}
