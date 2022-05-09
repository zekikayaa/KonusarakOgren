using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var posts = new List<Post>();


            var post1 = new Post()
            {
                CreatedDate = System.DateTime.UtcNow,
                Id = 11,
                Title = "Science Is Redefining Motherhood. If Only Society Would Let It",
                Content = "Karl, a PhD and lecturer at MIT, gave birth to both of his children—and despite being the one with the baby bump, he was routinely asked to wait outside while the nurses attended to his (not pregnant) wife. People were unable, he says, to see both a man and a pregnant body; as a result, Karl became a “fat man” rather than a pregnant person. Despite being assigned female at birth (AFAB) and possessing a uterus and glands for lactating, Karl was not—in the eyes of even the medical staff—the mother. Karl considered himself a PaPa; other transgender parents choose more androgynous terms, largely because of the way motherhood has been construed. At best, says Karl, unconventional pregnant parents cause “total gender confusion” even among medical practitioners, but at worst it results in trauma, violence, and harm, in trans men failing to get emergency care during miscarriages, in trans women being treated as pedophiles, and in nonbinary identities being entirely erased."

            };

            var post2 = new Post()
            {
                CreatedDate = System.DateTime.UtcNow.AddDays(2),
                Id = 22,
                Title = "Star Wars Ain’t What It Used to Be",
                Content = "Karl, a PhD and lecturer at MIT, gave birth to both of his children—and despite being the one with the baby bump, he was routinely asked to wait outside while the nurses attended to his (not pregnant) wife. People were unable, he says, to see both a man and a pregnant body; as a result, Karl became a “fat man” rather than a pregnant person. Despite being assigned female at birth (AFAB) and possessing a uterus and glands for lactating, Karl was not—in the eyes of even the medical staff—the mother. Karl considered himself a PaPa; other transgender parents choose more androgynous terms, largely because of the way motherhood has been construed. At best, says Karl, unconventional pregnant parents cause “total gender confusion” even among medical practitioners, but at worst it results in trauma, violence, and harm, in trans men failing to get emergency care during miscarriages, in trans women being treated as pedophiles, and in nonbinary identities being entirely erased."

            };

            var post3 = new Post()
            {
                CreatedDate = System.DateTime.UtcNow.AddDays(3),
                Id = 33,
                Title = "The Newest iPad Mini Is at Its Lowest Price Ever",
                Content = "Karl, a PhD and lecturer at MIT, gave birth to both of his children—and despite being the one with the baby bump, he was routinely asked to wait outside while the nurses attended to his (not pregnant) wife. People were unable, he says, to see both a man and a pregnant body; as a result, Karl became a “fat man” rather than a pregnant person. Despite being assigned female at birth (AFAB) and possessing a uterus and glands for lactating, Karl was not—in the eyes of even the medical staff—the mother. Karl considered himself a PaPa; other transgender parents choose more androgynous terms, largely because of the way motherhood has been construed. At best, says Karl, unconventional pregnant parents cause “total gender confusion” even among medical practitioners, but at worst it results in trauma, violence, and harm, in trans men failing to get emergency care during miscarriages, in trans women being treated as pedophiles, and in nonbinary identities being entirely erased."

            };

            var post4 = new Post()
            {
                CreatedDate = System.DateTime.UtcNow.AddDays(4),
                Id = 44,
                Title = "Fast, Cheap, and Out of Control: Inside Shein’s Sudden Rise",
                Content = "Karl, a PhD and lecturer at MIT, gave birth to both of his children—and despite being the one with the baby bump, he was routinely asked to wait outside while the nurses attended to his (not pregnant) wife. People were unable, he says, to see both a man and a pregnant body; as a result, Karl became a “fat man” rather than a pregnant person. Despite being assigned female at birth (AFAB) and possessing a uterus and glands for lactating, Karl was not—in the eyes of even the medical staff—the mother. Karl considered himself a PaPa; other transgender parents choose more androgynous terms, largely because of the way motherhood has been construed. At best, says Karl, unconventional pregnant parents cause “total gender confusion” even among medical practitioners, but at worst it results in trauma, violence, and harm, in trans men failing to get emergency care during miscarriages, in trans women being treated as pedophiles, and in nonbinary identities being entirely erased."

            };


            var post5 = new Post()
            {
                CreatedDate = System.DateTime.UtcNow.AddDays(5),
                Id = 55,
                Title = "24 Last-Minute Mother’s Day Gifts on Sale Now",
                Content = "Karl, a PhD and lecturer at MIT, gave birth to both of his children—and despite being the one with the baby bump, he was routinely asked to wait outside while the nurses attended to his (not pregnant) wife. People were unable, he says, to see both a man and a pregnant body; as a result, Karl became a “fat man” rather than a pregnant person. Despite being assigned female at birth (AFAB) and possessing a uterus and glands for lactating, Karl was not—in the eyes of even the medical staff—the mother. Karl considered himself a PaPa; other transgender parents choose more androgynous terms, largely because of the way motherhood has been construed. At best, says Karl, unconventional pregnant parents cause “total gender confusion” even among medical practitioners, but at worst it results in trauma, violence, and harm, in trans men failing to get emergency care during miscarriages, in trans women being treated as pedophiles, and in nonbinary identities being entirely erased."

            };

            posts.Add(post1);
            posts.Add(post2);
            posts.Add(post3);
            posts.Add(post4);
            posts.Add(post5);

            modelBuilder.Entity<Post>().HasData( posts);

            base.OnModelCreating(modelBuilder);
        }
    }
}



