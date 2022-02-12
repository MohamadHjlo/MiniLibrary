using System;
using Daneshgah.Models;
using Microsoft.EntityFrameworkCore;

namespace Daneshgah.Data
{
    public class WebsiteContext : DbContext 
    {
        public WebsiteContext(DbContextOptions<WebsiteContext> options) : base(options)
        {

        }
        
        public DbSet<User> Users { get; set; }

        public DbSet<Deposit> Deposits { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<Journal> Journals { get; set; }

        public DbSet<Article> Articles { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User()
            {
                Id = 1,
                Name = "سارا",
                Family = "سارایی",
                Email = "sarasaraii@gmail.com",
                IsAdmin = true,
                Password = "123",
                BirthDate = 1375,
                RegisterDate = DateTime.Now
            },
                new User()
                {
                    Id = 2,
                    Name = "سارا",
                    Family = "سارایی",
                    Email = "sarasaraii@gmail.com",
                    IsAdmin = true,
                    Password = "123",
                    BirthDate = 1375,
                    RegisterDate = DateTime.Now
                },
                new User()
                {
                    Id = 3,
                    Name = "نازنین",
                    Family = "رضایی",
                    Email = "nazaninrezaii@gmail.com",
                    IsAdmin = false,
                    Password = "123",
                    BirthDate = 1370,
                    RegisterDate = DateTime.Now
                },
                new User()
                {
                    Id = 4,
                    Name = "رضا",
                    Family = "محمدزاده",
                    Email = "rezamohamadzade@gmail.com",
                    IsAdmin = true,
                    Password = "123",
                    BirthDate = 1380,
                    RegisterDate = DateTime.Now
                }
            );
            modelBuilder.Entity<Book>().HasData(new Book()
            {
                Id = 1,
                Title = "صداهای ترسناک",
                Topic = "کودک و نوجوان",
                ISBN = 9823564123591,
                PageCount = 200,
                PublicationYear = DateTime.Now.AddYears(-10),
                Publisher = "پیدایش"

            },
                new Book()
                {
                    Id = 2,
                    Title = "شگفتی های بدن",
                    Topic = "علمی",
                    ISBN = 9823564123591,
                    PageCount = 200,
                    PublicationYear = DateTime.Now.AddYears(-30),
                    Publisher = "پیدایش"
                },
                new Book()
                {
                    Id = 3,
                    Title = "شوک الکتریسیته",
                    Topic = "علمی",
                    ISBN = 9003704123591,
                    PageCount = 200,
                    PublicationYear = DateTime.Now.AddYears(-20),
                    Publisher = "پیدایش"
                },
                new Book()
                {
                    Id = 4,
                    Title = "جانداران سمی هولناک",
                    Topic = "کودک و نوجوان",
                    ISBN = 9000004123591,
                    PageCount = 200,
                    PublicationYear = DateTime.Now.AddYears(-19),
                    Publisher = "پیدایش"
                }
            );
            modelBuilder.Entity<Deposit>().HasData(new Deposit()
            {
                Id = 1,
                BookId = 1,
                UserId = 1,
                RespiteTime = DateTime.Now.AddYears(-1),
                IsDelivered = true
            },
                new Deposit()
                {
                    Id = 2,
                    BookId = 1,
                    UserId = 1,
                    RespiteTime = DateTime.Now.AddYears(-1),
                    IsDelivered = true
                },
                new Deposit()
                {
                    Id = 3,
                    BookId = 2,
                    UserId = 1,
                    RespiteTime = DateTime.Now.AddDays(-4),
                    IsDelivered = true
                },
                new Deposit()
                {
                    Id = 4,
                    BookId = 3,
                    UserId = 2,
                    RespiteTime = DateTime.Now.AddDays(-2),
                    IsDelivered = true
                }
                ,
                new Deposit()
                {
                    Id = 5,
                    BookId = 4,
                    UserId = 2,
                    RespiteTime = DateTime.Now.AddDays(-1),
                    IsDelivered = true
                }
                ,
                new Deposit()
                {
                    Id = 6,
                    BookId = 2,
                    UserId = 3,
                    RespiteTime = DateTime.Now.AddHours(-12),
                    IsDelivered = false
                }
            );
            base.OnModelCreating(modelBuilder);
        }
    }
}
