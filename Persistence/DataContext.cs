using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext : IdentityDbContext<User>
    {
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {
            
        }
         public DbSet<Character>? Characters { get; set; }
         public DbSet<Weapon>? Weapons { get; set; }
    }
}