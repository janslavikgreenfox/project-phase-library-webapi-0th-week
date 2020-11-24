using CookieAuthTest.Entities;
using Microsoft.EntityFrameworkCore;

namespace CookieAuthTest.Database
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            Users.Add(new User { Password = "pepa", Username = "pepa", FavouriteColor = "Green" });
            SaveChanges();
        }
    }
}
