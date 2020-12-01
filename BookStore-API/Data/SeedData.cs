using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace BookStore_API.Data
{
    public static class SeedData
    {
        private const string AdminRoleName = "Administrator";
        public const string CustomerRoleName = "Customer";
        private const string Password = "P@ssw0rd";

        public static async Task Seed(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            await SeedRoles(roleManager);
            await SeedUsers(userManager);
        }

        private static async Task SeedUsers(UserManager<IdentityUser> userManager)
        {
            const string adminMail = "admin@bookstore.com";
            if (await userManager.FindByEmailAsync(adminMail) == null)
            {
                var user = new IdentityUser()
                {
                    UserName = "admin@bookstore.com",
                    Email = adminMail
                };

                var result = await userManager.CreateAsync(user, Password);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, AdminRoleName);
                }
            }

            const string customerMail1 = "customer1@gmail.com";
            if (await userManager.FindByEmailAsync(customerMail1) == null)
            {
                var user = new IdentityUser()
                {
                    UserName = "customer1@gmail.com",
                    Email = customerMail1
                };

                var result = await userManager.CreateAsync(user, Password);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, CustomerRoleName);
                }
            }

            const string customerMail2 = "customer2@gmail.com";
            if (await userManager.FindByEmailAsync(customerMail2) == null)
            {
                var user = new IdentityUser()
                {
                    UserName = "customer2@gmail.com",
                    Email = customerMail2
                };

                var result = await userManager.CreateAsync(user, Password);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, CustomerRoleName);
                }
            }
        }

        private static async Task SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!await roleManager.RoleExistsAsync(AdminRoleName))
            {
                var role = new IdentityRole
                {
                    Name = AdminRoleName
                };

                var result = await roleManager.CreateAsync(role);
            }

            if (!await roleManager.RoleExistsAsync(CustomerRoleName))
            {
                var role = new IdentityRole
                {
                    Name = CustomerRoleName
                };

                var result = await roleManager.CreateAsync(role);
            }
        }
    }
}
