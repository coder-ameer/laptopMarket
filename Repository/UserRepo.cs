using Microsoft.AspNetCore.Identity;
using laptopMarket.Model;
using laptopMarket.Repository.IRepository;
using laptopMarket.model_dto;
namespace laptopMarket.Repository
{
    public class UserRepo:IuserRepo
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        public UserRepo(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            this.roleManager = roleManager;
        }
        public async Task<bool> Aunthitecation(string username, string pw)
        {
            var resulte = await _signInManager.PasswordSignInAsync(username, pw, true, lockoutOnFailure: false);
            if (resulte.Succeeded)
            {
                return true;
            }
            return false;

        }
        public async Task<string> Regestersuperadmin(CrappUser user)
        {
            var usern = new AppUser
            {
                
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.username,
                Email = user.Email,
                Address = user.Address,
                EmailConfirmed = true,
                PhoneNumber =user.phonenumber,

            };
            //find user name and return if found  if was already exist
            var result = await _userManager.FindByNameAsync(usern.UserName);
            //if password is  weak so return value in resultpass
            bool resultpass = await _userManager.CheckPasswordAsync(usern, user.Password);

            if (result != null)
            {
                return "user name is already exist!";
            }
            else if (resultpass == true)
            {
                return "password is weak!!";
            }
            else
            {
                //creat new user
                var R = await _userManager.CreateAsync(usern, user.Password);
                //add role to user 
                var e=await _userManager.AddToRoleAsync(usern, "superadmin");

                if (R.Succeeded)
                {
                    return "true";
                }
                return "false";
            }
        }

        public async Task<string> Regestercustomer(CrappUser user)
        {
         
            var usern = new AppUser
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.username,
                Email = user.Email,
                Address = user.Address,
                EmailConfirmed = true,
                PhoneNumber = user.phonenumber,
            };

            var result = await _userManager.FindByNameAsync(usern.UserName);
            bool resultpass =await _userManager.CheckPasswordAsync(usern, user.Password);
            if (result != null)
            {
                return "user name is already exist!";
            }
            else if (resultpass==true) 
            { 
                return "password is weak!!"; 
            }

            var R = await _userManager.CreateAsync(usern, user.Password);
            await _userManager.AddToRoleAsync(usern, "customer");
            if (R.Succeeded)
            {

                return "true";
            }
            return "false";

        }
        public async Task<string> RegesterAdmin(CrappUser user)
        {
            var usern = new AppUser
            {

                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.username,
                Email = user.Email,
                Address = user.Address,
                EmailConfirmed = true,
                PhoneNumber = user.phonenumber,
            };
            var result = await _userManager.FindByNameAsync(usern.UserName);
            bool resultpass = await _userManager.CheckPasswordAsync(usern, user.Password);
            if (result != null)
            {
                return "user name is already exist!";
            }
            else if (resultpass ==true)
            {
                return "password is weak!!";
            }
            var R = await _userManager.CreateAsync(usern, user.Password);
            await _userManager.AddToRoleAsync(usern, "admin");
            if (R.Succeeded)
            {

                return "true";
            }
            return "false";

        }
        
        public async Task<bool> creatrole(string rolename)
        {
            var resulte = await roleManager.RoleExistsAsync(rolename);
            if (resulte == true)
            {
                return false;
            }
            var roleresulte = await roleManager.CreateAsync(new IdentityRole(rolename));
            return true;
        }

        public async Task<bool> logout()
        {
            await _signInManager.SignOutAsync();
            return true;

        }
        public async Task<bool>DeleteUser(string username)
        {
            var resultname = await _userManager.FindByNameAsync(username);
            await _userManager.DeleteAsync(resultname);
            return true;
        }

        public async Task<string> Change_role(string username, string newrolename,string oldrolename)
        {
            var resname=await _userManager.FindByNameAsync(username);
            if(resname==null)
            {
                return "not found user";
            }
            var isrole=await _userManager.IsInRoleAsync(resname, newrolename);
            if(isrole == true) 
            {
                return $"the role: {newrolename} is already exist";
            }
             await _userManager.RemoveFromRoleAsync(resname, oldrolename); 
            await _userManager.AddToRoleAsync(resname, newrolename);
            return "it change";

        }

        public async Task<IList<IdentityUser>> getadmins()
        {
         
            var adminuser = await _userManager.GetUsersInRoleAsync("admin");
            return adminuser;


        }
    }
}
