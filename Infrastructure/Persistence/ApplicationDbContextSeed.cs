using CoinMarketCap.Domain.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CoinMarketCap.Infrastructure.Persistence
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedDefaultUserAsync(UserManager<ApplicationUser> userManager)
        {
            var admin = new ApplicationUser
            {
                UserName = "administrator@localhost",
                Email = "administrator@localhost",
            };

            if (!await userManager.Users.AnyAsync())
                await userManager.CreateAsync(admin, "Administrator1!");
        }
    }
}
