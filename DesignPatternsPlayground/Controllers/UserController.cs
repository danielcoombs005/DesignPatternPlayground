using DesignPatternsPlayground.Models;
using DesignPatternsPlayground.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace DesignPatternsPlayground.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService _userService;

        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            _logger = logger;
            _userService = userService;
        }

        [HttpGet(Name = "GetUserById")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            User result = await _userService.GetUser(id);
            if (result == null)
            {
                return null;
            }
            return result;
        }
    }
}
