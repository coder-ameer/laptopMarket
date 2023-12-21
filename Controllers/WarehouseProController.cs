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
    public class WarehouseProController : ControllerBase
    {
        private readonly IwarehouseProRepo warehousRep;
        private readonly IMapper mapper;
        public WarehouseProController(IwarehouseProRepo warehousRep, IMapper mapper)
        {
            this.warehousRep = warehousRep;
            this.mapper = mapper;
        }

        // GET: api/<WarehouseProController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<WarehouseProController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            var result = await warehousRep.getwarehousePro(id);

            if (result == null)
            {
                return Ok("NOT found warehousePro");
            }
            
            return Ok(result);
        }

        // POST api/<WarehouseProController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] WarehouseproDto war)
        {
            var check = await warehousRep.ifexist(war.ProductId,war.WarehouseId);
          
            if (check ==false)
            {
                return Ok("this collection is already exist");
            }
            var get=mapper.Map<Warehouse_pro_qu>(war);
            var res = await warehousRep.makewarehousePro(get);
            return Ok(res);
        }

        // PUT api/<WarehouseProController>/5
        [HttpPut("{id}")]
        public async Task<bool> Put( [FromBody] Warehouse_pro_qu war)
        {

            var res = await warehousRep.updatewarehousePro(war);
            return res;
        }

        // DELETE api/<WarehouseProController>/5
        [HttpDelete("{id}")]
        public async Task<string> Delete(int id)
        {
            var get = await warehousRep.getwarehousePro(id);
            if (get == null)
            {
                return "item not found!";
            }
            var res = await warehousRep.deletewarehousePro(get);
            return res;
        }
        [HttpPost("increase")]
        
        public async Task<string> increasepro(  int quantity,int id)
        {
            var res=await warehousRep.IncreaseQuantity(quantity,id);
            if (res == false)
            {
                return "something error in input";
            }
            return "product is increase";
            
        }
        [HttpPost("decrease")]
        public async Task<string> decreasepro( int quantity, int id)
        {
            var res = await warehousRep.decreaseQuantity(quantity, id);
            if(res==false)
            {
                return "something error in input";
            }
            return "product is decrease";
        }

    }
}
