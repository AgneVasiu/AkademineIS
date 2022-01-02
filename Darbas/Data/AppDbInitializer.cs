using Darbas.Data.Static;
using Darbas.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Darbas.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();

                //Teachers
                if (!context.Teachers.Any())
                {
                    context.Teachers.AddRange(new List<Teacher>()
                    {
                       new Teacher
                       {
                           FullName = "Aldonas Ponas",
                           Sex = Sex.Male,
                           DateOfBirth = DateTime.FromOADate(1986/03/09),
                           Email = "Aldonas@Teach.com",
                           PhoneNumber = 865876352,
                           ProfilePicture = "https://dotnethow.net/images/producers/producer-3.jpeg"
                       },
                       new Teacher
                       {
                           FullName = "Lina Lina",
                           Sex = Sex.Female,
                           DateOfBirth = DateTime.FromOADate(1981/01/09),
                           Email = "Lina@Teach.com",
                           PhoneNumber = 861487963,
                           ProfilePicture = "https://dotnethow.net/images/actors/actor-3.jpeg"
                       }
                    });

                    context.SaveChanges();
                }

                //Students
                if (!context.Students.Any())
                {
                    context.Students.AddRange(new List<Student>()
                    {
                       new Student
                       {
                           FullName = "Jonas Jonaitis",
                           Class = "S20",
                           Sex = Sex.Male,
                           DateOfBirth = DateTime.FromOADate(2012/03/10),
                           Email = "Jonas@Stud.com",
                           PhoneNumber = 965876352,
                           ProfilePicture = "https://dotnethow.net/images/actors/actor-4.jpeg"
                       },
                        new Student
                        {
                           FullName = "Laura Laura",
                           Class = "S21",
                           Sex = Sex.Female,
                           DateOfBirth = DateTime.FromOADate(2010/06/11),
                           Email = "Laura@Stud.com",
                           PhoneNumber = 789676352,
                           ProfilePicture = "https://dotnethow.net/images/actors/actor-3.jpeg"
                        }
                    });

                    context.SaveChanges();
                }
                // student & teachers
                if (!context.Student_Teachers.Any())
                {
                    context.Student_Teachers.AddRange(new List<Student_Teacher>()
                    {
                        new Student_Teacher()
                        {
                           StudentId = 4,
                            TeacherId = 1,
                        },

                        new Student_Teacher()
                        {
                            StudentId = 5,
                            TeacherId = 2,
                        },

                        new Student_Teacher()
                        {
                            StudentId = 13,
                            TeacherId = 1,
                        },
                    });
                    context.SaveChanges();
                }
                //Subjects
                if (!context.Subjects.Any())
                {
                    context.Subjects.AddRange(new List<Subject>()
                    {
                        new Subject()
                        {
                            SubjectName = "Operacinės sistemos",
                            Creditsnumber = 6,

                        },
                        new Subject()
                        {
                            SubjectName = "Informacinės sistemos",
                            Creditsnumber = 3
                        }
                    });
                    context.SaveChanges();
                }
                //Grade
                if (!context.Grades.Any())
                {
                    context.Grades.AddRange(new List<Grade>()
                    {
                        new Grade()
                        {
                            Grade1 = 10,
                            Grade2 = 6,
                            Grade3 = 8,
                            Grade4 = 9,
                            Grade5 = 10,
                            SubjectId = 1
                        },
                        new Grade()
                        {
                            Grade1 = 9,
                            Grade2 = 7,
                            Grade3 = 3,
                            Grade4 = 7,
                            Grade5 = 10,
                            SubjectId = 2,
                        },

                    });
                    context.SaveChanges();
                }
              


            }
        }
        //changes seed
        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                //Roles 
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));

               /* if (!await roleManager.RoleExistsAsync(UserRoles.Student))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Student));*/

                if (!await roleManager.RoleExistsAsync(UserRoles.Teacher))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Teacher));

                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));



                //Users

                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                string adminUserEmail = "admin@darbas.com";
                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
                        FullName = "Admin-User",
                        UserName = "admin-user",
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "Admin@1234?");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }

                string appUserEmail = "user@darbas.com";
                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
                        FullName = "Aplication-User",
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "User@1235?");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }
}
