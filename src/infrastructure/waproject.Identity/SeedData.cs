using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace waproject.Identity
{
    public static class SeedData
    {
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetService<UserManager<IdentityUser>>();

            await CreateUser(userManager!);
        }

        private static async Task CreateUser(UserManager<IdentityUser> userManager)
        {
            var userName = "admin";
            var userEmail = "admin@gmail.com";
            var userPassword = "Pa$$w0rd";
            var user = await userManager.FindByNameAsync(userName);

            if (user == null)
            {
                user = new IdentityUser(userName)
                {
                    Email = userEmail,
                    EmailConfirmed = true
                };
                await userManager.CreateAsync(user, userPassword);
            }
        }
    }
}
