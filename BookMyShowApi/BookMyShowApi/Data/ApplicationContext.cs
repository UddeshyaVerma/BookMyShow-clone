using BookMyShowApi.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookMyShowApi.Data
{
    public class ApplicationContext :IdentityDbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) 
        {

        }


       public DbSet<ApplicationUser> ApplicationUsers { get; set; } 
       public DbSet<MoviesModel> Movies { get; set; } 

       public DbSet<BookingModel> bookings { get; set; }
    }
}
