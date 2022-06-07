using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace JokeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        // method for getting user Id from the generated token
        protected string GetUserId()
        {
            return User.FindFirst(ClaimTypes.Name).Value;
        }
    }
}
