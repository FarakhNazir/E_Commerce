using E_Commerce.Data.Enum;
using E_Commerce.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.Data
{
    public class AppDbInitilizer
    {
        public static void Seed(IApplicationBuilder applicatonBuilder)
        {
            using (var serviceScope = applicatonBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                context.Database.EnsureCreated();

                //Cenima
                if (!context.Cenimas.Any())
                {
                    context.Cenimas.AddRange(new List<Cenima>()
                    {
                        new Cenima()
                        { Name = "Cenima 1",
                           Logo = "http://dotnethow.net/images/cenimas/cenima-1.jpeg",
                           Discription = "This is DEscription of Cenima one"
                        },
                         new Cenima()
                        { Name = "Cenima 2",
                           Logo = "http://dotnethow.net/images/cenimas/cenima-2.jpeg",
                           Discription = "This is DEscription of Cenima Two"
                        },
                          new Cenima()
                        { Name = "Cenima 3",
                           Logo = "http://dotnethow.net/images/cenimas/cenima-3.jpeg",
                           Discription = "This is DEscription of Cenima Three"
                        },
                           new Cenima()
                        { Name = "Cenima 4",
                           Logo = "http://dotnethow.net/images/cenimas/cenima-4.jpeg",
                           Discription = "This is DEscription of Cenima Four"
                        },
                            new Cenima()
                        { Name = "Cenima 5",
                           Logo = "http://dotnethow.net/images/cenimas/cenima-5.jpeg",
                           Discription = "This is DEscription of Cenima Five"
                        },
                    });
                    context.SaveChanges();
                }

                //Actors

                if (!context.Actors.Any())
                {
                    context.Actors.AddRange(new List<Actor>()
                    {
                         new Actor()
                        { FullName = "Actor 1",
                        Bio = "This is Bio of Actor one" ,
                          ProfilePictureURL = "http://dotnethow.net/images/actors/actor-1.jpeg",

                        },
                          new Actor()
                        { FullName = "Actor 2",
                        Bio = "This is Bio of Actor two" ,
                          ProfilePictureURL = "http://dotnethow.net/images/actors/actor-2.jpeg",

                        },
                           new Actor()
                        { FullName = "Actor 3",
                        Bio = "This is Bio of Actor three" ,
                          ProfilePictureURL = "http://dotnethow.net/images/actors/actor-3.jpeg",
                           },
                           new Actor()
                        { FullName = "Actor 4",
                        Bio = "This is Bio of Actor four" ,
                          ProfilePictureURL = "http://dotnethow.net/images/actors/actor-4.jpeg",
                           },
                           new Actor()
                        { FullName = "Actor 5",
                        Bio = "This is Bio of Actor five" ,
                          ProfilePictureURL = "http://dotnethow.net/images/actors/actor-5.jpeg",

                        }



                    });

                    context.SaveChanges();
                }

                //Producer
                if (!context.Producers.Any())
                {

                    context.Producers.AddRange(new List<Producer>()
                    {
                         new Producer()
                        {
                             FullName = "Producer 1",
                             Bio = "This is Bio of Producer one" ,
                             ProfilePictureURL = "http://dotnethow.net/images/producers/producer-1.jpeg"
                        },
                          new Producer()
                        {
                             FullName = "Producer 2",
                             Bio = "This is Bio of Producer two" ,
                             ProfilePictureURL = "http://dotnethow.net/images/producers/producer-2.jpeg"
                        },
                           new Producer()
                        {
                             FullName = "Producer 3",
                             Bio = "This is Bio of Producer three" ,
                             ProfilePictureURL = "http://dotnethow.net/images/producers/producer-3.jpeg"
                        },
                            new Producer()
                        {
                             FullName = "Producer 4",
                             Bio = "This is Bio of Producer four" ,
                             ProfilePictureURL = "http://dotnethow.net/images/producers/producer-4.jpeg"
                        },
                             new Producer()
                        {
                             FullName = "Producer 5",
                             Bio = "This is Bio of Producer five" ,
                             ProfilePictureURL = "http://dotnethow.net/images/producers/producer-5.jpeg"
                        }
                    });
                    context.SaveChanges();
                }

                //Movies
                if (!context.Movies.Any())
                {
                    context.Movies.AddRange(new List<Movie>()
                    {
                         new Movie()
                        {
                             Name = "Daram ",
                             Description ="This is Drama Movies Decription",
                             Price = 30.5,
                             ImgaeURL = "http://dotnethow.net/images/movies/movie-1.jpeg",
                             StartDate = DateTime.Now.AddDays(3),
                             EndDate = DateTime.Now.AddDays(20),
                             CenimaId= 1,
                             ProducerId = 1,
                             MoviesCategory = MoviesCategory.Drama

                        },
                          new Movie()
                        {
                             Name = "Horror ",
                             Description = "This is Horror Movies Decription",
                             Price = 15.5,
                             ImgaeURL = "http://dotnethow.net/images/movies/movie-2.jpeg",
                             StartDate = DateTime.Now.AddDays(3),
                             EndDate = DateTime.Now.AddDays(20),
                             CenimaId= 2,
                             ProducerId = 2,
                             MoviesCategory = MoviesCategory.Harror

                        },
                           new Movie()
                        {
                             Name = "Documentry ",
                             Description = "This is documentry Movies Decription" ,
                             Price = 30.5,
                             ImgaeURL = "http://dotnethow.net/images/movies/movie-3.jpeg",
                             StartDate = DateTime.Now.AddDays(2),
                             EndDate = DateTime.Now.AddDays(10),
                             CenimaId= 3,
                             ProducerId = 3,
                             MoviesCategory = MoviesCategory.Documentry

                        },
                            new Movie()
                        {
                             Name = "Cartoon ",
                             Description = "This is Cartoon Movies Decription",
                             Price = 50.5,
                             ImgaeURL = "http://dotnethow.net/images/movies/movie-4.jpeg",
                             StartDate = DateTime.Now.AddDays(3),
                             EndDate = DateTime.Now.AddDays(10),
                             CenimaId= 2,
                             ProducerId = 1,
                             MoviesCategory = MoviesCategory.Cartoon

                        },
                             new Movie()
                        {
                             Name = "Comedy ",
                             Description = "This is Comedy Movies Decription" ,
                             Price = 40.5,
                             ImgaeURL = "http://dotnethow.net/images/movies/movie-5.jpeg",
                             StartDate = DateTime.Now.AddDays(3),
                             EndDate = DateTime.Now.AddDays(30),
                             CenimaId= 1,
                             ProducerId = 2,
                             MoviesCategory = MoviesCategory.Comedy

                        },

                    });
                    context.SaveChanges();
                }
                //Actors_Movies

                if (!context.Actors_Movies.Any())
                {

                    context.Actors_Movies.AddRange(new List<Actor_Movie>()
                    {
                        new Actor_Movie()
                        {
                            ActorId = 1 ,
                            MovieId= 4
                        },
                        new Actor_Movie()
                        {
                            ActorId = 2 ,
                            MovieId= 4
                        },
                        new Actor_Movie()
                        {
                            ActorId = 3 ,
                            MovieId= 6
                        },
                        new Actor_Movie()
                        {
                            ActorId = 2 ,
                            MovieId= 7
                        },
                        new Actor_Movie()
                        {
                            ActorId = 3,
                            MovieId= 4
                        }

                    });
                    context.SaveChanges();
                }

            }


        }

        //public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        //{
        //    using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
        //    {

        //        //Roles
        //        var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

        //        if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
        //            await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
        //        if (!await roleManager.RoleExistsAsync(UserRoles.User))
        //            await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

        //        //Users
        //        var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
        //        string adminUserEmail = "admin@etickets.com";

        //        var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
        //        if (adminUser == null)
        //        {
        //            var newAdminUser = new ApplicationUser()
        //            {
        //                FullName = "Admin User",
        //                UserName = "admin-user",
        //                Email = adminUserEmail,
        //                EmailConfirmed = true
        //            };
        //            await userManager.CreateAsync(newAdminUser, "Coding@1234?");
        //            await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
        //        }


        //        string appUserEmail = "user@etickets.com";

        //        var appUser = await userManager.FindByEmailAsync(appUserEmail);
        //        if (appUser == null)
        //        {
        //            var newAppUser = new ApplicationUser()
        //            {
        //                FullName = "Application User",
        //                UserName = "app-user",
        //                Email = appUserEmail,
        //                EmailConfirmed = true
        //            };
        //            await userManager.CreateAsync(newAppUser, "Coding@1234?");
        //            await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
        //        }
        //    }
        //}
    }
}
