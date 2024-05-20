using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class ApplicationDbContext : IdentityDbContext<AppUser, IdentityRole<Guid>, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
        }
       public DbSet<FoodItem> FoodItems { get; set; }
       public DbSet<Restaurant> Restaurants { get; set;}
       public DbSet<Address> Addresses { get; set; }  
       public DbSet<AppUser> AppUsers { get; set; }
    }

}
