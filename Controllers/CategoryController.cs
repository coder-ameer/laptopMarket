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
    public class CategoryController : ControllerBase
    {
        private readonly Icategory cat;
        private readonly IMapper Mapper;
        public CategoryController(Icategory cat, IMapper mapper)
        {
            this.cat = cat;
            this.Mapper = mapper;
        }
    
        // GET: api/<CategoryController>
        [HttpGet("get-category-product")]
        public async Task<Category> Getall(int id)
        {
            var get = await cat.getcategory_product(id);
            return get;
        }

        // GET api/<CategoryController>/5
        [HttpGet("id")]
        public async Task<ActionResult> Get(int id)
        {
            var result = await cat.getcategory(id);

            if (result == null)
            {
                return Ok("NOT found category");
            }
           var getres = Mapper.Map<CategoryDto>(result);
            return Ok(getres);
        }
        

        // POST api/<CategoryController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CategoryDto ca)
        {
            var check = await cat.check_name(ca.CategoryName);
            if (check != null)
            {
                return Ok("please enter another name");
            }
            var postres = Mapper.Map<Category>(ca);
            var res = await cat.makecategory(postres);
            return Ok(res);
        }

        // PUT api/<CategoryController>/5
        [HttpPut("id")]
        public async Task<ActionResult> Put( [FromBody] Category ca)
        {
            var res = await cat.updatecategory(ca);
            return Ok(res);
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("id")]
        public async Task<ActionResult> Delete(int id)
        {
            var get = await cat.getcategory(id);
            if (get == null)
            {
                return Ok("item not found!");
            }
            var res = await cat.deletecategory(get);
            return Ok(res);
        }
    }
}
