using PathCaseAPI.Identity;
using PathCaseAPI.Web.Identity.DTO.Responses;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PathCaseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClaimsSetupController : ControllerBase
    {
        private readonly IAppContext _context;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<ClaimsSetupController> _logger;

        public ClaimsSetupController(
            IAppContext context,
            UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager,
            ILogger<ClaimsSetupController> logger
        )
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllClaims(string email)
        {
            // Check if the user exist
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null) // User does not exist
            {
                _logger.LogInformation($"The user with the {email} does not exist");
                return BadRequest(new GetByIdResponseBase<string>()
                {
                     Success = false,
                     ErrorMessage = "Not Found"
                });
               
            }

            var userClaims = await _userManager.GetClaimsAsync(user);
            return Ok(new GetByIdResponseBase<string>()
            {
                Success = true,
                ErrorMessage = "Successful"
            });
        }

        [HttpPost]
        [Route("AddClaimsToUser")]
        public async Task<IActionResult> AddClaimsToUser(string email, string claimName, string claimValue)
        {
            // Check if the user exist
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null) // User does not exist
            {
                _logger.LogInformation($"The user with the {email} does not exist");
                return BadRequest(new GetByIdResponseBase<string>()
                {
                    Success = false,
                    ErrorMessage = "User not found"
                });
            }

            var userClaim = new Claim(claimName, claimValue);

            var result = await _userManager.AddClaimAsync(user, userClaim);

            if (result.Succeeded)
            {
                return Ok(new GetByIdResponseBase<string>()
                {
                    Success = true,
                    ErrorMessage = "Successful"
                });
            }

            return BadRequest(new GetByIdResponseBase<string>()
            {
                Success = false,
                ErrorMessage = "Error"
            });

        }
    }
}
