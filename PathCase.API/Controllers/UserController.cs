using PathCase.BusinessLayer.Abstract;
using PathCaseAPI.Configuration;
using PathCaseAPI.Controllers;
using PathCaseAPI.Identity;
using PathCaseAPI.Web.Identity.DTO.Responses;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Threading.Tasks;

namespace PathCaseAPI.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly JwtConfig _jwtConfig;
        private readonly TokenValidationParameters _tokenValidationParams;
        private readonly IAppContext _apiDbContext;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<AuthManagementController> _logger;

        public UserController(
            UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager,
            IOptionsMonitor<JwtConfig> optionsMonitor,
            TokenValidationParameters tokenValidationParams,
            ILogger<AuthManagementController> logger,
            IAppContext apiDbContext
            )
        {
            _logger = logger;
            _roleManager = roleManager;
            _userManager = userManager;
            _jwtConfig = optionsMonitor.CurrentValue;
            _tokenValidationParams = tokenValidationParams;
            _apiDbContext = apiDbContext;
            
        }

        [HttpGet]
        [Route("GetUsers")]
        public async Task<IActionResult> GetUsers()
        {
            var model = await _apiDbContext.Users.ToListAsync();
            return Ok(new GetAllResponseBase<User>()
            {
                Success = true,
                DataList = model,
                DataCount = model.Count
            });
        }

        [HttpGet]
        [Route("GetRoles")]
        public async Task<IActionResult> GetRoles()
        {
            var model = await _apiDbContext.Roles.ToListAsync();
            return Ok(new GetAllResponseBase<IdentityRole>()
            {
                Success = true,
                DataList = model,
                DataCount = model.Count
            });
        }

       
    }
}
