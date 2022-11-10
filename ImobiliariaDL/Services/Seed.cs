using Microsoft.AspNetCore.Identity;

namespace ImobiliariaDL.Services
{
    public class Seed : ISeed
    {
        private readonly UserManager<IdentityUser> _userManager;
        //private readonly RoleManager<IdentityUser> _roleManager;

       public Seed(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
            //_roleManager = roleManager;
        }
        public void SeedUser()
        {
            if(_userManager.FindByEmailAsync("admindiogods@gmail.com").Result == null)
            {
                IdentityUser user = new IdentityUser();
                user.UserName = "admindiogods@gmail.com";
                user.Email = "admindiogods@gmail.com";
                user.NormalizedUserName = "ADMINDIOGODS@GMAIL.COM";
                user.NormalizedEmail = "ADMINDIOGODS@GMAIL.COM";
                user.EmailConfirmed = true;
                user.LockoutEnabled = false;
                user.SecurityStamp = Guid.NewGuid().ToString();

                IdentityResult result = _userManager.CreateAsync(user,"xxxx").Result;

                if (result.Succeeded)
                {
                    _userManager.AddToRoleAsync(user, "Admin").Wait(); 
                }
            }
        }
    }
}
