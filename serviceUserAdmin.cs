using laptopMarket.Data;
using laptopMarket.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace laptopMarket
{
    public class serviceUserAdmin:IserviceUserAdmin
    {
        private readonly laptopMarketContext context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public serviceUserAdmin(laptopMarketContext db, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            context = db;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public void Initializar()
        {
            try
            {


                if (context.Database.GetPendingMigrations().Count() > 0)
                {
                    context.Database.Migrate();
                }
            }
            catch (Exception ex)
            {

            }
            // create necessary user roles 

            if (_roleManager.RoleExistsAsync("superadmin").GetAwaiter().GetResult())
            {
                return;
            }

            _roleManager.CreateAsync(new IdentityRole("superadmin")).GetAwaiter().GetResult();
           

            // Create Admin User
            _userManager.CreateAsync(new AppUser
            {
                UserName = "ameer_hani@gmail.com",
                Email = "ameer_hani@gmail.com",
                EmailConfirmed = true,
                PhoneNumber = "1233456456",
               
            }, "Qwer!234"
            ).GetAwaiter().GetResult();

            // assign role to admin user
            IdentityUser user = context.AppUser.FirstOrDefaultAsync(u => u.Email == "ameer_hani@gmail.com").GetAwaiter().GetResult();
            _userManager.AddToRoleAsync(user, "superadmin").GetAwaiter().GetResult();
        }
    }
}
