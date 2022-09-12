using System.Collections.Generic;
using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public sealed class DataContext : IdentityDbContext<ApplicationUser>
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
            //DbLoggerCategory.Database.EnsureCreated();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Weather>().Property(x => x.City).HasMaxLength(21);
            builder.Entity<Weather>().Property(x => x.Temperature).HasMaxLength(2);
            builder.Entity<Weather>().Property(x => x.TempMax).HasMaxLength(2);
            builder.Entity<Weather>().Property(x => x.TempMin).HasMaxLength(2);
            builder.Entity<Weather>().Property(x => x.CityImageUrl).HasMaxLength(255);

            var hasher = new PasswordHasher<ApplicationUser>();

            builder.Entity<ApplicationUser>().HasData(
                new ApplicationUser
                {
                    UserName = "admin",
                    Email = "admin@mail.com",
                    NormalizedUserName = "ADMIN",
                    NormalizedEmail = "ADMIN@MAIL.COM",
                    PasswordHash = hasher.HashPassword(null, "Administrator123$")
                });

            builder.Entity<Weather>().HasData(
                new Weather
                {
                    Id = 1,
                    City = "Cali",
                    CityImageUrl = "https://i.pinimg.com/originals/cc/fb/07/ccfb07552df291483bb98b2e0b8bf4f3.jpg",
                    Temperature = 45,
                    TempMin = 32,
                    TempMax = 50
                },
                new Weather
                {
                    Id = 2,
                    City = "Bogotá",
                    CityImageUrl = "https://i.pinimg.com/originals/68/14/b8/6814b835359837f03548a49bbb38faf0.jpg",
                    Temperature = 25,
                    TempMin = 20,
                    TempMax = 45
                },
                new Weather
                {
                    Id = 3,
                    City = "Medellin",
                    CityImageUrl = "https://i.pinimg.com/originals/12/17/26/121726ece1a75f18b188342ed708ede9.jpg",
                    Temperature = 42,
                    TempMin = 32,
                    TempMax = 49
                },
                new Weather
                {
                    Id = 4,
                    City = "Bucaramanga",
                    CityImageUrl = "https://content.r9cdn.net/rimg/dimg/3b/7f/302c7c97-city-18865-169e971acd4.jpg?crop=true&width=1366&height=768&xhint=1969&yhint=497",
                    Temperature = 39,
                    TempMin = 27,
                    TempMax = 48
                },
                new Weather
                {
                    Id = 5,
                    City = "Pereira",
                    CityImageUrl = "https://i.pinimg.com/originals/63/a2/a5/63a2a53423f6faa9b22e487090f25b00.jpg",
                    Temperature = 25,
                    TempMin = 23,
                    TempMax = 43
                },
                new Weather
                {
                    Id = 6,
                    City = "Risaralda",
                    CityImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/e/e6/Pereira_-_Risaralda_-_Colombia.webm/1920px--Pereira_-_Risaralda_-_Colombia.webm.jpg",
                    Temperature = 27,
                    TempMin = 30,
                    TempMax = 40
                },
                new Weather
                {
                    Id = 7,
                    City = "Buga",
                    CityImageUrl = "https://turismovalledelcauca.com/wp-content/uploads/2020/01/foto-buga-municipio-turismo-valle-del-cauca-colombia-1.jpg",
                    Temperature = 41,
                    TempMin = 32,
                    TempMax = 48
                },
                new Weather
                {
                    Id = 8,
                    City = "Palmira",
                    CityImageUrl = "http://turismovalledelcauca.com/wp-content/uploads/2019/12/foto-palmira-municipio-turismo-valle-del-cauca-colombia-11.jpg",
                    Temperature = 47,
                    TempMin = 32,
                    TempMax = 50
                });


            base.OnModelCreating(builder);
        }

        public DbSet<Weather> Weather { get; set; }
    }
}