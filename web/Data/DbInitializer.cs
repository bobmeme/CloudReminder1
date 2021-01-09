using web.Models;
using System;
using System.Linq;
using Microsoft.AspNetCore.Identity;

namespace web.Data
{
    public static class DbInitializer
    {
        public static void Initialize(CloudContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Events.Any())
            {
                return;   // DB has been seeded
            }

            var Events = new Event[]
            {
            new Event{Name="Carson", DateCreated=DateTime.Parse("2005-09-01"),EventDate=DateTime.Parse("2005-09-01")},
            };
            foreach (Event s in Events)
            {
                context.Events.Add(s);
            }
            context.SaveChanges();

            var Groups = new Group[]
            {
            new Group{Name="movies"},
            };
            foreach (Group c in Groups)
            {
                context.Groups.Add(c);
            }
            context.SaveChanges();

            var roles = new IdentityRole[] {
                new IdentityRole{Id="1", Name="Administrator"},
                new IdentityRole{Id="2", Name="Manager"},
                new IdentityRole{Id="3", Name="Staff"}
            };

            foreach (IdentityRole r in roles)
            {
                context.Roles.Add(r);
            }

            var user = new User
            {
                FirstName = "Bob",
                LastName = "Dilon",
                Email = "bob@example.com",
                NormalizedEmail = "XXXX@EXAMPLE.COM",
                UserName = "bob@example.com",
                NormalizedUserName = "bob@example.com",
                PhoneNumber = "+111111111111",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString("D")
            };


            if (!context.Users.Any(u => u.UserName == user.UserName))
            {
                var password = new PasswordHasher<User>();
                var hashed = password.HashPassword(user,"Testni123!");
                user.PasswordHash = hashed;
                context.Users.Add(user);
                
            }

            context.SaveChanges();
            

            var UserRoles = new IdentityUserRole<string>[]
            {
                new IdentityUserRole<string>{RoleId = roles[0].Id, UserId=user.Id},
                new IdentityUserRole<string>{RoleId = roles[1].Id, UserId=user.Id},
            };

            foreach (IdentityUserRole<string> r in UserRoles)
            {
                context.UserRoles.Add(r);
            }

            context.SaveChanges();

        }
    }
}