using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Movies.Data;
using System;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;


namespace Movies.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MoviesContext(serviceProvider.GetRequiredService<DbContextOptions<MoviesContext>>()))
            {
                if (!context.Movie.Any())
                {

                    context.Movie.AddRange(
                        new Movie
                        {
                            Title = "When Harry Met Sally",
                            ReleaseDate = DateTime.Parse("1989-2-12"),
                            Genre = "Romantic Comedy",
                            Rating = "R",
                            Price = 7.99M
                        },
                        new Movie
                        {
                            Title = "Ghostbusters ",
                            ReleaseDate = DateTime.Parse("1984-3-13"),
                            Genre = "Comedy",
                            Rating = "R",
                            Price = 8.99M
                        },
                         new Movie
                         {
                             Title = "Ghostbusters 2",
                             ReleaseDate = DateTime.Parse("1986-2-23"),
                             Genre = "Comedy",
                             Rating = "R",
                             Price = 9.99M
                         },
                         new Movie
                         {
                             Title = "Rio Bravo",
                             ReleaseDate = DateTime.Parse("1959-4-15"),
                             Genre = "Western",
                             Price = 3.99M
                         }
                    );
                    context.SaveChanges();
                }

            }
            using (var userManager = serviceProvider.GetService<UserManager<User>>())
            {
                if (!userManager.Users.Any())
                {


                    var user = new User
                    {
                        UserName = "Admin",
                        Role = "Admin"
                    };
                    var result = userManager.CreateAsync(user, "123qwe").GetAwaiter().GetResult();
                    if (result.Succeeded)
                    {
                        userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, "Admin")).GetAwaiter().GetResult();
                    }
                    var user2 = new User
                    {
                        UserName = "Manager",
                        Role = "Manager"
                    };
                    var result2 = userManager.CreateAsync(user2, "123qwe").GetAwaiter().GetResult();
                    if (result2.Succeeded)
                    {
                        userManager.AddClaimAsync(user2, new Claim(ClaimTypes.Role, "Manager")).GetAwaiter().GetResult();
                    }
                }
            }
            return;
        }
    }
}
