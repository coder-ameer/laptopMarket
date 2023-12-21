using laptopMarket.Repository.IRepository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace laptopMarket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrederServiceController : ControllerBase
    {
        private readonly IserviceOrder order;

        public OrederServiceController(IserviceOrder order)
        {
            this.order = order;
        }



        // POST api/<OrederServiceController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] string userId)
        {
            var res = await order.OrderTransaction(userId);
            return Ok(res); 
        }

       

        
    }
}
