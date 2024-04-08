using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
        {
        }
       public DbSet<FoodItem> FoodItems { get; set; }
       public DbSet<Restaurant> Restaurants { get; set;}
       public DbSet<Address> Addresses { get; set; }  
    }

}
