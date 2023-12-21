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
    public class ProductController : ControllerBase
    {
        private readonly Iproduct? ProductRepo;
        private readonly IMapper Mapper;
        private readonly Icategory cate;
       
        public ProductController(Iproduct? productRepo, IMapper mapper, Icategory cate)
        {
           
            Mapper = mapper;
            ProductRepo = productRepo;
            this.cate = cate;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ProductController>/5
        [HttpGet("id")]
        public async Task<ActionResult> Get(int id)
        {
            var result = await ProductRepo.getproduct(id);


            if (result == null)
            {
                return Ok("NOT found product");
            }
            var getres = Mapper.Map<GetProductDto>(result);
            return Ok(getres);
        }

        // POST api/<ProductController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PostProductDto pro)
        {
            var get = await ProductRepo.check_name(pro.Name);
            var foundCate = await cate.getcategory(pro.CategoryId);
            if (foundCate == null)
            {
                return Ok("please enter right category ID");
            }
            if (get != null) { return Ok("change name please"); }
          
            var postres = Mapper.Map<Product>(pro);
            //postres.Imageurl = new byte[];
            postres.CoponId = null;
            var res = await ProductRepo.makeproduct(postres);
            return Ok(res);
        }


        // PUT api/<ProductController>/5
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] PutProductDto pro)
        {
            var result = await ProductRepo.getproduct(pro.ProductId);
            if (result == null)
            {
                return Ok("NOT found product");
            }
            var postres = Mapper.Map<Product>(pro);
            var res = await ProductRepo.updateprod(postres);
            return Ok(res);
        }

        // DELETE api/<ProductController>/5
        [HttpDelete]
        public async Task<string> Delete(int id)
        {
            var get = await ProductRepo.getproduct(id);
            if (get == null)
            {
                return "item not found!";
            }
            var res = await ProductRepo.deleteproduct(get);
            return res;
        }
        [HttpPost("add-copon-toProduct")]
        public async Task<string> addcopon(string coponname, int productId)
        {
            var res = await ProductRepo.add_copon_toProduct(coponname, productId);
            if (res == false)
            {
                return "somthing error in input!!";
            }
            return "done";
        }
        [HttpDelete("delete-copon-fromProduct")]
        public async Task<string> deletecopon(int productId)
        {
            var res = await ProductRepo.delete_copon_fromProduct(productId);
            if (res == false)
            {
                return "item not found!";
            }
            return "done";
        }
        [HttpPost("add image")]
        public async Task<string> add_image(IFormFile imageFile, int id)
        {
            var res = await ProductRepo.UploadImage(imageFile, id);
            if(res==false)
            {
                return "not send";
            }
            return "image send";
        }
    }
}
