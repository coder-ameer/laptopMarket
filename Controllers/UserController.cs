using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using laptopMarket.Model;
using laptopMarket.Repository.IRepository;
using laptopMarket.model_dto;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace phoneMarket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IuserRepo? Userrepo;
        public UserController(IuserRepo userrepo)
        {
            Userrepo = userrepo;
        }



        // POST api/<UserController>
        [HttpPost("regester customer")]
        public async Task<IActionResult> Post([FromBody] CrappUser user)
        {
            var result = await Userrepo.Regestercustomer(user);
            return Ok(result);


        }

        [HttpPost("regester super admin")]
        public async Task<IActionResult> regestersuper([FromBody] CrappUser user)
        {
            var result = await Userrepo.Regestersuperadmin(user);
            return Ok(result);


        }

        [HttpPost("regester admin")]
        [Authorize(Roles = "superadmin")]
        public async Task<IActionResult> regesteradmin([FromBody] CrappUser user)
        {
            var result = await Userrepo.RegesterAdmin(user);
            return Ok(result);
        }

        [HttpPost("authinticated")]
        public async Task<IActionResult> authinticateduser([FromBody] loginUser us)
        {
            var result = await Userrepo.Aunthitecation(us.UserName, us.Password);
            return Ok(result);


        }
        [HttpPost("logout")]
        public async Task<IActionResult> logoutUser()
        {
            var result = await Userrepo.logout();
            return Ok(result);


        }
        
        [HttpPost("creatrole")]
        
        public async Task<IActionResult> creatrole([FromBody] string role)
        {
            var result = await Userrepo.creatrole(role);
            return Ok(result);


        }
        [HttpPost("change role")]
      
        public async Task<IActionResult> ChangeRole ( string username, string newrolename, string oldrolename)
        {
            var result = await Userrepo.Change_role(username,newrolename,oldrolename);
            return Ok(result);


        }
        [HttpDelete]
        public async Task<IActionResult> Deleteuser([FromBody] string name)
        {
            var result = await Userrepo.DeleteUser(name);
            return Ok(result);


        }
        [HttpGet("get all admins")]
        public async Task<IActionResult> GetAdmins()
        {
            var result = await Userrepo.getadmins();
            return Ok(result);
        }
    }
}
