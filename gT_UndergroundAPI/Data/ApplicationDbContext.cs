using Microsoft.EntityFrameworkCore;
using gT_UndergroundAPI.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace gT_UndergroundAPI.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext() : base() 
        { 
        }

        public ApplicationDbContext(DbContextOptions options) 
            : base(options) 
        { 
        }
        
    }
}
