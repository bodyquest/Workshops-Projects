using DevApp.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using static DevApp.Common.GlobalConstants;

namespace DevApp.Data
{
    public class DbContextSeed
    {
        public static async Task SeedAsync(
            ApplicationDbContext context,
            IServiceProvider serviceProvider,
            ILoggerFactory loggerFactory)
        {
            try
            {
                if (!context.Users.Any())
                {
                    var productData = File.ReadAllText("./Data/Seed/users.json");

                    var users = JsonSerializer.Deserialize<List<User>>(productData);
                    var userManager = serviceProvider.GetRequiredService<UserManager<User>>();

                    foreach (var user in users)
                    {
                        var userInDb = await userManager.FindByEmailAsync(user.Email);
                        if (userInDb == null)
                        {
                            var newUser = new User
                            {
                                UserName = user.UserName,
                                FirstName = user.FirstName,
                                LastName = user.LastName,
                                Email = user.Email,
                                EmailConfirmed = true,
                                SecurityStamp = securityStamp,
                            };

                            var result = await userManager.CreateAsync(newUser, defaultPassword);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                var logger = loggerFactory.CreateLogger<DbContextSeed>();
                logger.LogError(ex.Message);
            }
        }
    }
}
