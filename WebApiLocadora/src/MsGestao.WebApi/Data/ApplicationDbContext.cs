using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


//using Microsoft.AspNetCore.Identity;
// Microsoft.AspNet.Identity.EntityFramework
// using Microsoft.AspNet.Identity.EntityFramework;
// using Microsoft.AspNet.Identity.EntityFramework;

namespace Locadora.WebApi.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server =.; Initial Catalog = Locadora; User Id = sa; Password = msgestao@2020");
                
              
            }
        }

        public DbSet<IdentityUser> Usuarios { get; set; }
    }
}
