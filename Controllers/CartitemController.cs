using AutoMapper;
using laptopMarket.Model;
using laptopMarket.model_dto;
using laptopMarket.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace laptopMarket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartitemController : ControllerBase
    {
        private readonly IcartItemRepo Cart;
        private readonly IMapper Mapper;

        public CartitemController(IcartItemRepo cart, IMapper mapper)
        {
            Cart = cart;
            Mapper = mapper;
        }

        // POST api/<CartitemController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CartItemdto ca)
        {

            var postres = Mapper.Map<Cart_item>(ca);
            DateTime? date = DateTime.Now;
            postres.Added_at = date.ToString();
            var res = await Cart.makeitem(postres);
            return Ok(res);
        }
        [HttpPost("change quantity")]
        public async Task<ActionResult> changequantity(int quantity, int prodid, int cartid)
        {
            var res = await Cart.addQuantity(quantity, prodid, cartid);
            if(res==false)
            {
                return Ok("wrong in input");
            }
            return Ok(res);

        }
        // DELETE api/<CartitemController>/5
        [HttpDelete("delete item")]
        public async Task<ActionResult> Delete(int proid, int cartid)
        {
            var get = await Cart.getProductitem( proid,  cartid);
            if (get == null)
            {
                return Ok("item not found!");
            }
            var res = await Cart.deleteitem(get);
            return Ok(res);
        }
    }
}
