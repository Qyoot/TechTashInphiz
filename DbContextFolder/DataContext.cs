using Microsoft.EntityFrameworkCore;
using TaskTech.DbModel;

namespace TaskTech.DbContextFolder
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users{ get; set; }

        public DbSet<UserLoginAtempt> UserLoginAtempts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-09TSHR8;Database=TechTask;Trusted_Connection=True;");
        }
    }
}
