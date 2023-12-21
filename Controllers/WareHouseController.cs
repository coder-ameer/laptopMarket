using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using laptopMarket.Model;
using laptopMarket.model_dto;
using laptopMarket.Repository.IRepository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace phoneMarket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WareHouseController : ControllerBase
    {
        private readonly IwareHouse warehousRep;
        private readonly IMapper Mapper;
        public WareHouseController(IwareHouse warehousRep, IMapper mapper)
        {
            this.warehousRep = warehousRep;
            this.Mapper = mapper;
        }

        // GET: api/<WareHouseController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<WareHouseController>/5
        [HttpGet("id")]
        public async Task<ActionResult>  Get(int id)
        {
            var result = await warehousRep.Getwarehouse(id);

            if (result == null)
            {
                return Ok("NOT found product");
            }
            var getres = Mapper.Map<GetwarehouseDto>(result);
            return Ok(getres);
        }

        // POST api/<WareHouseController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PostwarehouseDto war)
        {
            
          
                var check = await warehousRep.check_name(war.WarehouseName);
           if(check != null)
            {
                return Ok("please enter another name");
            }
            var postres = Mapper.Map<Warehouse>(war);
            var res = await warehousRep.Makewarehouse(postres);
            return Ok(res);
        }

        // PUT api/<WareHouseController>/5
        [HttpPut("id")]
        public async Task<bool> Put( [FromBody] Warehouse war)
        {
         
            var res = await warehousRep.UpdateWarehouse(war);
            return res;
        }

        // DELETE api/<WareHouseController>/5
        [HttpDelete("id")]
        public async Task<string> Delete(int id)
        {
            var get = await warehousRep.Getwarehouse(id);
            if (get == null)
            {
                return "item not found!";
            }
            var res = await warehousRep.Deletewarehouse(get);
            return res;
        }

    }
}
