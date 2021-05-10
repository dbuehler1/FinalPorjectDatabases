using Microsoft.EntityFrameworkCore;

    public class MovieController : DbContext{
        public DbSet<Movie> Movies{ get; set; }

        public DbSet<User> Users{get; set;}
    

    
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer();
        }
    }   