using Microsoft.EntityFrameworkCore;
using TestApp.Domains.Domains;

namespace TestApp.DAL.EfDbContext
{
    public class TestAppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Post> Posts { get; set; }


        public DbSet<Test> Tests { get; set; }


        public DbSet<Question> Questions { get; set; }



        //public TestAppDbContext(DbContextOptions<TestAppDbContext> options) : base(options)
        //{

        //}

        //Sql connectin appsetings.jsonda belirtip Startup'dan ulasıyoruz
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite("Data Source=..\\TestApp.Web\\DataBase\\TestApp.db");


    }
}



