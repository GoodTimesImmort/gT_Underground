using GtUndergroundAPI.Data;
using GtUndergroundAPI.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using System.Runtime.CompilerServices;

namespace GtUndergroundAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeedController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IWebHostEnvironment _env;
        private readonly IConfiguration _configuration;

        public SeedController(
            ApplicationDbContext context, 
            RoleManager<IdentityRole> roleManager, 
            UserManager<ApplicationUser> userManager, 
            IWebHostEnvironment webHostEnvironment, 
            IConfiguration configuration)
        {
            _context = context;
            _roleManager = roleManager;
            _userManager = userManager;
            _env = webHostEnvironment;
            _configuration = configuration;
        }

        [HttpGet]
        public async Task<ActionResult> CreateDefaultUsers()
        {
            throw new NotImplementedException();
        }
    }
}
