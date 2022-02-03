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
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{

        //    string adminRoleName = "admin";
        //    string userRoleName = "user";
        //    // добавляем тестовые роли
        //    Role adminRole = new Role { Name = adminRoleName };
        //    Role userRole = new Role { Name = userRoleName };
        //    // добавляем тестовых пользователей
        //    User adminUser1 = new User { };
        //    User adminUser2 = new User { };
        //    User simpleUser1 = new User { };
        //    User simpleUser2 = new User { };

        //    modelBuilder.Entity<Role>().HasData(new Role[] { adminRole, userRole });
        //    modelBuilder.Entity<User>().HasData(new User[] { adminUser1, adminUser2, simpleUser1, simpleUser2 });
        //    base.OnModelCreating(modelBuilder);
        //}
    }
}



