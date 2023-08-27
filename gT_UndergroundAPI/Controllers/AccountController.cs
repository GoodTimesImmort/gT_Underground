using gT_UndergroundAPI.Data;
using gT_UndergroundAPI.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace gT_UndergroundAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly JwtHandler _jwtHandler;

        public AccountController(
            ApplicationDbContext context,
            RoleManager<IdentityRole> roleManager,
            UserManager<ApplicationUser> userManager,
            JwtHandler jwtHandler)
        {
            _context = context;
            _roleManager = roleManager;
            _userManager = userManager;
            _jwtHandler = jwtHandler;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            var user = await _userManager.FindByNameAsync(loginRequest.Email);
            if (user == null
                || !await _userManager.CheckPasswordAsync(user, loginRequest.Password))
            {
                return Unauthorized(new LoginResult()
                {
                    Success = false,
                    Message = "Invalid Email or Password."
                });
            }
            var secToken = await _jwtHandler.GetTokenAsync(user);
            var jwt = new JwtSecurityTokenHandler().WriteToken(secToken);
            return Ok(new LoginResult()
            {
                Success = true,
                Message = "Login successful.",
                Token = jwt
            });
        }

        [HttpPost("Registration")]
        public async Task<IActionResult> RegisterUser(RegistrationRequest registrationUser)
        {
            if (registrationUser == null || ModelState.IsValid == false) 
            {
                return BadRequest();
            }
            
            var user = (new ApplicationUser()
            {
                SecurityStamp = Guid.NewGuid().ToString(),
                FirstName = registrationUser.FirstName,
                LastName = registrationUser.LastName,
                UserName = registrationUser.Username,
                Email = registrationUser.Email
            });
            
            var result = await _userManager.CreateAsync(user, registrationUser.Password);
            if (!result.Succeeded) 
            {
                var errors = result.Errors.Select(e => e.Description);
                Console.WriteLine("result !success");
                return BadRequest(new RegistrationResult { Errors = errors });
            }

            return Ok(new RegistrationResult()
            {
                Success = true,
                Message = "Registration successful."
            });
        }
    }
}
