using AutoMapper;
using JokeApi.Data;
using JokeApi.IRepository;
using JokeApi.Models.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace JokeApi.Repository
{
    public class AuthManager : IAuthManager
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;
        private User _user;
        public AuthManager(IMapper mapper, UserManager<User> userManager, IConfiguration configuration)
        {
            this._mapper = mapper;
            this._userManager = userManager;
            this._configuration = configuration;
        }

        public async Task<AuthResponseDto> Login(UserDto userDto)
        {
            //
             var user = await _userManager.FindByEmailAsync(userDto.Email);

            bool isValidUser = await _userManager.CheckPasswordAsync(user, userDto.Password);

            if(user == null || isValidUser == false)
            {
                return null;
            }
           

            var token = await GenerateToken(user);

            return new AuthResponseDto
            {
                Token = token,
                UserId = user.Id,
            };
            
        }

        public async Task<IEnumerable<IdentityError>> Register(UserDto userDto)
        {
            var user  = _mapper.Map<User>(userDto);
            user.UserName = userDto.Email;

            var result = await _userManager.CreateAsync(user, userDto.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "User");
            }

            return result.Errors; //if succeeded there will be no errors and if not, there will be
        }

        private async Task<string> GenerateToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtSettings:Key"]));

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var roles = await _userManager.GetRolesAsync(user);

            

            var roleClaims = roles.Select(x => new Claim(ClaimTypes.Role, x)).ToList(); //generate the list of claims for the roles of the user

            ////generate the list of claims for the Id of the user
            //var userIdClaims = new List<Claim>
            //{
            //   new Claim(ClaimTypes.Name, _user.Id )
            //};

             var userClaims = await _userManager.GetClaimsAsync(user);

            //foreach (var role in roles )
            //{
            //    userIdClaims.Add(new Claim(ClaimTypes.Role, role));
            //}


            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Id ),
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("uid", user.Id)
            }
            .Union(userClaims.Union(roleClaims));

            var token = new JwtSecurityToken(
                issuer: _configuration["JwtSettings:Issuer"],
                audience: _configuration["JwtSettings:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes( Convert.ToInt32( _configuration["JwtSettings:DurationInMinutes"])),
                signingCredentials:credentials
                ) ;

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
