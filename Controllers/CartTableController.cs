using AutoMapper;
using laptopMarket.Model;
using laptopMarket.model_dto;
using laptopMarket.Repository.IRepository;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace laptopMarket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartTableController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly IcartTableRepo Cart;
        private readonly IMapper mapper;
        public CartTableController(IcartTableRepo cart, IMapper mapper, UserManager<IdentityUser> UserManager)
        {
            Cart = cart;
            this.mapper = mapper;
            userManager = UserManager;
        }

        // GET api/<CartTableController>/5
        [HttpGet("get cart")]
        public async Task<ActionResult> Get(string userid)
        {
            var result = await Cart.getcart(userid);

            if (result == null)
            {
                return Ok("NOT found cart");
            }
            var getres = mapper.Map<CartTableGetDto>(result);
            return Ok(getres);
        }

        // POST api/<CartTableController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PostcartTabledto ca)
        {
            var resuser=await userManager.FindByIdAsync(ca.AppUserID);
            if(resuser == null)
            {
                return Ok("user not found");
            }
            var FoundCart = await Cart.getcart(ca.AppUserID);
            if(FoundCart != null)
            {
                return Ok("cart is already exist");
            }
             var postres = mapper.Map<Cart_table>(ca);
            DateTime date= DateTime.Now;
            postres.Created_at = date.ToString();
            var res = await Cart.makecart(postres);

            return Ok(res) ;
        }

        // PUT api/<CartTableController>/5
        [HttpPut("update")]
        public async Task<ActionResult> Put([FromBody] CartTableGetDto ca)
        {
            var getres = mapper.Map<Cart_table>(ca);
            var res = await Cart.updatecart(getres);
            return Ok(res);
        }

        // DELETE api/<CartTableController>/5
        [HttpDelete]
        public async Task<ActionResult> Delete(string userid)
        {
            var get = await Cart.getcart(userid);
            if (get == null)
            {
                return Ok("cart not found!");
            }
            
            var res = await Cart.deletecart(get);
            return Ok(res);
        }
    }
}
