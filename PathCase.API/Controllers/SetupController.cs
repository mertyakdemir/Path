using PathCaseAPI.Identity;
using PathCaseAPI.Web.Identity.DTO.Responses;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;

namespace PathCaseAPI.Controllers
{
    [Route("api/[controller]")]  // api/Roles
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IAppContext _context;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<RolesController> _logger;

        public RolesController(
            IAppContext context,
            UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager,
            ILogger<RolesController> logger
        )
        {
            _logger = logger;
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult GetAllRoles()
        {
            var roles = _roleManager.Roles.ToList();
            return Ok(new GetAllResponseBase<IdentityRole>()
            {
                  Success = true,
                  DataList = roles,
                  DataCount = roles.Count
            });
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(string name)
        {
            // Check if the role exist
            var roleExist = await _roleManager.RoleExistsAsync(name);

            if (!roleExist) // checks on the role exist status
            {
                var roleResult = await _roleManager.CreateAsync(new IdentityRole(name));

                // We need to check if the role has been added successfully
                if (roleResult.Succeeded)
                {
                    _logger.LogInformation($"The Role {name} has been added successfully");
                    return Ok(new ResponseBase()
                    {
                        Success = true,
                        ErrorMessage = "Rol başarıyla eklendi."
                    });
                }
                else
                {
                    _logger.LogInformation($"The Role {name} has not been added");
                    return BadRequest(new ResponseBase()
                    {
                        Success = false,
                        ErrorMessage = "Error"
                    });
                }

            }

            return BadRequest(new ResponseBase()
            {
                Success = false,
                ErrorMessage = "Rol zaten mevcut."
            });
        }

        [HttpGet]
        [Route("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userManager.Users.ToListAsync();
            return Ok(new GetAllResponseBase<User>()
            {
                Success = true,
                DataList = users,
                DataCount = users.Count
            });
        }

        [HttpPost]
        [Route("AddUserToRole")]
        public async Task<IActionResult> AddUserToRole(string email, string roleName)
        {
            // Check if the user exist
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null) // User does not exist
            {
                _logger.LogInformation($"The user with the {email} does not exist");
                return BadRequest(new ResponseBase()
                {
                    Success = false,
                    ErrorMessage = "Kullanıcı mevcut değil."
                });
            }

            // Check if the role exist
            // Check if the role exist
            var roleExist = await _roleManager.RoleExistsAsync(roleName);

            if (!roleExist) // checks on the role exist status
            {
                _logger.LogInformation($"The role {email} does not exist");
                return BadRequest(new ResponseBase()
                {
                    Success = false,
                    ErrorMessage = "Rol mevcut değil."
                });
            }

            var result = await _userManager.AddToRoleAsync(user, roleName);

            // Check if the user is assigned to the role successfully
            if (result.Succeeded)
            {
                return BadRequest(new ResponseBase()
                {
                    Success = true,
                    ErrorMessage = "Kullanıcı başarıyla role eklendi."
                });
            }
            else
            {
                _logger.LogInformation($"The user was not abel to be added to the role");
                return BadRequest(new ResponseBase()
                {
                    Success = false,
                    ErrorMessage = "Error"
                });
            }

        }

        [HttpGet]
        [Route("GetUserRoles")]
        public async Task<IActionResult> GetUserRoles(string email)
        {
            // check if the email is valid
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null) // User does not exist
            {
                _logger.LogInformation($"The user with the {email} does not exist");
                return BadRequest(new ResponseBase()
                {
                    Success = false,
                    ErrorMessage = "Kullanıcı mevcut değil."
                });
            }

            // return the roles
            var roles = await _userManager.GetRolesAsync(user);

            return Ok(new GetAllResponseBase<string>()
            {
                Success = true,
                DataList = roles,
                DataCount = roles.Count
            });
        }

        [HttpPost]
        [Route("RemoveUserFromRole")]
        public async Task<IActionResult> RemoveUserFromRole(string email, string roleName)
        {
            // Check if the user exist
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null) // User does not exist
            {
                _logger.LogInformation($"The user with the {email} does not exist");
                return BadRequest(new ResponseBase()
                {
                    Success = false,
                    ErrorMessage = "Kullanıcı mevcut değil."
                });
            }

            // Check if the role exist
            var roleExist = await _roleManager.RoleExistsAsync(roleName);

            if (!roleExist) // checks on the role exist status
            {
                _logger.LogInformation($"The role {email} does not exist");
                return BadRequest(new ResponseBase()
                {
                    Success = false,
                    ErrorMessage = "Rol mevcut değil."
                });
            }

            var result = await _userManager.RemoveFromRoleAsync(user, roleName);

            if (result.Succeeded)
            {
                return Ok(new GetByIdResponseBase<IdentityResult>()
                {
                    Success = true,
                    Data = result,
                    ErrorMessage = "Successful"
                });
            }

            return BadRequest(new ResponseBase()
            {
                Success = false,
                ErrorMessage = "Error"
            });
        }
    }
}
