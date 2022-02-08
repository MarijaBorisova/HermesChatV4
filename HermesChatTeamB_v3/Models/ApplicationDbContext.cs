using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HermesChatTeamB_v3.Models
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {

        //public DbSet<User> Users { get; set; }
        //public DbSet<Role> Roles { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>().HasData(new User[] {  });
            base.OnModelCreating(modelBuilder);


        }
    }
}




