using Bogus;
using BusinessModel.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Drawing;

namespace BusinessModel.Data
{
    public class Seed
    {
        private static readonly int ColorCount = Enum.GetNames(typeof(KnownColor)).Length;

        #region Vehicle Data

        internal Seed InitData(ModelBuilder modelBuilder)
        {
            Randomizer.Seed = new Random(42);

            var cars = new Faker<AutoMobile>()
                .RuleFor(a => a.Id, f => f.Random.Guid())
                .RuleFor(a => a.Manufacturer, f => f.Vehicle.Manufacturer())
                .RuleFor(a => a.Model, f => f.Vehicle.Model())
                .RuleFor(a => a.Type, f => f.Vehicle.Type())
                .RuleFor(a => a.Fuel, f => f.Vehicle.Fuel())
                .RuleFor(a => a.TopSpeed, f => f.Random.Int(10, 30) * 10)
                .RuleFor(a => a.Color, f => (KnownColor)f.Random.Int(28, ColorCount))
                .RuleFor(a => a.RegistritationDate, f => f.Date.Between(new DateTime(1990, 1, 1), new DateTime(2022, 1, 1)))
                .Generate(100);

            var users = new Faker<Customer>()
                .RuleFor(a => a.Id, f => f.Random.Guid())
                .RuleFor(c => c.FirstName, f => f.Name.FirstName())
                .RuleFor(c => c.LastName, f => f.Name.LastName())
                .RuleFor(c => c.Email, (f, c) => f.Internet.Email(c.FirstName, c.LastName))
                .Generate(5);
            

            modelBuilder.Entity<AutoMobile>().HasData(cars);
            modelBuilder.Entity<Customer>().HasData(users);

            return this;
        }

        #endregion

        #region Identity Data

        // Wenn wir Unit Tests schreiben koennen wir gegen diese vorgegebenen Daten validieren.

        public const string ADMIN_ROLE_ID = "d4e8321b-447b-43d2-bdce-f4738b588bec";
        public const string ADMIN_ROLE = "Admin";
        public const string USER_ROLE_ID = "eb6b2a41-9e08-4243-bf9b-74f5ac6d9297";
        public const string USER_ROLE = "User";

        public const string ROOT_USER_ID = "3a32e868-9191-4c77-a8ea-4c825571b5bf";
        public const string ROOT_USER_NAME = "R. Root";
        public const string ROOT_USER_EMAIL = "root@example.com";

        public const string JOHN_USER_ID = "4b43c757-9e01-4243-bf9b-f4738b588bec";
        public const string JOHN_USER_NAME = "John Doe";
        public const string JOHN_USER_EMAIL = "john.doe@example.com";
        
        // Syst3m
        public const string DEFAULT_PWD_HASH = "AQAAAAIAAYagAAAAEI9bnzxidZZ+yhCWxSEb3S6FK1cSyK/2GPjRLnssQErapeLrjxRDdlzL22WyyowLRA==";

        public List<IdentityRole> Roles =>
        [
            new IdentityRole
            {
                Id = ADMIN_ROLE_ID,
                Name = ADMIN_ROLE,
                NormalizedName = ADMIN_ROLE.ToUpper()
            },
            new IdentityRole
            {
                Id = USER_ROLE_ID,
                Name = USER_ROLE,
                NormalizedName = USER_ROLE.ToUpper()
            },
        ];

        public List<IdentityUser> Users =>
        [
            new IdentityUser
            {
                Id = ROOT_USER_ID,
                UserName = ROOT_USER_NAME,
                NormalizedUserName = ROOT_USER_NAME.ToUpper(),
                Email = ROOT_USER_EMAIL,
                NormalizedEmail = ROOT_USER_EMAIL.ToUpper(),
                PasswordHash = DEFAULT_PWD_HASH
            },
            new IdentityUser
            {
                Id = JOHN_USER_ID,
                UserName = JOHN_USER_NAME,
                NormalizedUserName = JOHN_USER_NAME.ToUpper(),
                Email = JOHN_USER_EMAIL,
                NormalizedEmail = JOHN_USER_EMAIL.ToUpper(),
                PasswordHash = DEFAULT_PWD_HASH
            }
        ];

        public List<IdentityUserRole<string>> UsersRoles =>
        [
            new IdentityUserRole<string>
            {
                RoleId = ADMIN_ROLE_ID,
                UserId = ROOT_USER_ID
            },
            new IdentityUserRole<string>
            {
                RoleId = USER_ROLE_ID,
                UserId = JOHN_USER_ID
            }
        ];

        internal Seed InitIdentityData(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(Roles);
            builder.Entity<IdentityUser>().HasData(Users);
            builder.Entity<IdentityUserRole<string>>().HasData(UsersRoles);

            return this;
        }

        #endregion
    }
}
