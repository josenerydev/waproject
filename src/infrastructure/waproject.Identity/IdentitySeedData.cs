using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace waproject.Identity
{
    public static class IdentitySeedData
    {
        private const string userName = "Admin";
        private const string userEmail = "admin@gmail.com";
        private const string userPassword = "Secret123$";

        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetService<UserManager<IdentityUser>>();
            var user = await userManager!.FindByNameAsync(userName);

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
