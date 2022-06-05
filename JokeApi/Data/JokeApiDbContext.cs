using Microsoft.EntityFrameworkCore;

namespace JokeApi.Data
{
    //Contract between the API and the Database
    public class JokeApiDbContext : DbContext
    {
        public JokeApiDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Joke> Joke { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    username = "edwin@bbd.co.za"

                });
            modelBuilder.Entity<Joke>().HasData(

                new Joke
                {
                    Id = 1,
                    Body = "First Joke",
                    UserId = 1
                },
                new Joke
                {
                    Id = 2,
                    Body = "Second Joke",
                    UserId = 1
                });

            modelBuilder.Entity<Comment>().HasData(
                new Comment
                {
                    Id = 1,
                    Body = "First Comment",
                    JokeId = 1,
                    UserId = 1
                });
            
        }
    }
}
