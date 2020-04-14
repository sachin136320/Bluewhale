using aptmgt.entity.user;
using Microsoft.AspNetCore.Identity;

public static class UserAndRoleDataInitializer
    {
        public static void SeedData(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager);
        }
 
        private static void SeedUsers (UserManager<ApplicationUser> userManager)
        {
            if (userManager.FindByEmailAsync("sachin@localhost").Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = "sachin@localhost";
                user.Email = "sachin@localhost"; 
 
                IdentityResult result = userManager.CreateAsync(user, "P@ssw0rd1!").Result;
 
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "User").Wait();
                }
            }
 
 
            if (userManager.FindByEmailAsync("manager@localhost").Result == null)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = "manager@localhost";
                user.Email = "manager@localhost"; 
 
                IdentityResult result = userManager.CreateAsync(user, "P@ssw0rd1!").Result;
 
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(user, "Admin").Wait();
                }
            }
        }
 
        private static void SeedRoles (RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("User").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "User";
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }
 
 
            if (!roleManager.RoleExistsAsync("Admin").Result)
            {
                IdentityRole role = new IdentityRole();
                role.Name = "Admin";
                IdentityResult roleResult = roleManager.
                CreateAsync(role).Result;
            }
        }
    }