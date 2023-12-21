using Microsoft.AspNetCore.Identity;
namespace laptopMarket.Model
{
    public class AppUser:IdentityUser
    {
        public string? FirstName { get; set; }  
        public string? LastName { get; set;}
        public string? Address { get; set; }
        
       
    }
}
