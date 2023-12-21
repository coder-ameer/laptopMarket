using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using laptopMarket.Model;
using laptopMarket.model_dto;
using laptopMarket.Repository.IRepository;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace phoneMarket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoponController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly Icopon cop;
        public CoponController(Icopon co,IMapper mapper)
        {
            cop= co;
            this.mapper=mapper;
        }
        // GET: api/<CoponController>
        [HttpGet("usability")]
        public async  Task<IActionResult> Get()
        {
            var getcopons = await cop.check_allusage();
            if (getcopons == null)
            {
                return Ok("no found copon unusable");
            }

            var getmap = mapper.Map<IEnumerable<GetCoponDto>>(getcopons);
         
            return Ok(getmap);
        }

        // GET api/<CoponController>/5
        [HttpGet("id")]
        public async Task<Copon> Get(int id)
        {
            var get=await cop.readcopon(id);  
            return get;
        }

        // POST api/<CoponController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PostCopon co)
        {
            
            var postres=mapper.Map<Copon>(co);
            postres.Coponcode = await cop.hashcode(postres.Coponcode);
            var postfi = await cop.Comparecode(postres.Coponcode);
            if(postfi==true)
            {
                return Ok("please enter another copon code");
            }
            var res = await cop.writecopon(postres);
            return Ok(res);


        }
        [HttpPost("write copon(valdation)")]
        public async Task<string> validation( string coponcode)
        {

            var res = await cop.check_Ifvalid(coponcode);
            return res;
        }
        
        // PUT api/<CoponController>/5
        [HttpPut]
        public async Task<bool> Put( [FromBody] PutcoponDto co)
        {
            var putres=mapper.Map<Copon>(co);
            var res = await cop.updatecopon(putres);
            return res;
        }

        // DELETE api/<CoponController>/5
        [HttpDelete("write to delete copon")]
        public async Task<string> check_delete_copon(string coponcode)//to delet copon from database by hashcode 
        {
            var val = await cop.hashcode(coponcode);
          var res= await cop.check_delete(val);
            if(res==false)
            {
                return "copon is wrong!";
            }
            return "copon is deleted";

        }
        // DELETE api/<CoponController>/5
        [HttpDelete]
        public async Task<string> Delete(int id)
        {
            var res=await cop.deletecopon(id);
            return res;
        }
        
    }
}
