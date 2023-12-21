
using Microsoft.EntityFrameworkCore;
using laptopMarket.Model;
using laptopMarket.Repository.IRepository;
using laptopMarket.Data;

namespace laptopMarket.Repository
{
    public class ProductRepo : Iproduct
    {
        private readonly laptopMarketContext Context;
        private readonly Icopon coponrep;
        public ProductRepo(laptopMarketContext context, Icopon coponrep)
        {
            Context = context;
            this.coponrep = coponrep;
        }

        public async Task<string> deleteproduct(Product pro)
        {
            
             Context.Products.Remove(pro);
            await Context.SaveChangesAsync();
            return "item is delete";


        }

        public async Task<Product> getproduct(int id)
        {
            var Get= await Context.Products.Include(p => p.Copons).FirstOrDefaultAsync(x=>x.Id==id);
            return Get;
        }

        public async Task<bool> makeproduct(Product pro)
        {
            await Context.Products.AddAsync(pro);
            await Context.SaveChangesAsync();
            return true;    
        }

        public async Task<bool> updateprod(Product pro)
        {
            Context.Products.Update(pro);
            await Context.SaveChangesAsync();
            return true;
        }

        public async Task<bool>add_copon_toProduct(string coponname,int id)
        {
           var res= await coponrep.check_name(coponname);

            var getpro = await getproduct( id);
            if (res == null|| getpro == null) { return false; }
            
            getpro.CoponId = res.Id;
            
            await updateprod(getpro);
           
            return true;    

        }
        public async Task<bool> delete_copon_fromProduct( int id)
        {
            var getpro = await getproduct(id);
            if ( getpro == null) { return false; }
            getpro.CoponId = null;
            await updateprod(getpro);
            return true;    
        }
        public async Task<Product> check_name(string productename)
        {
            var res = await Context.Products.FirstOrDefaultAsync(x => x.Name == productename);
            return res;
        }
        public async Task<bool> UploadImage(IFormFile imageFile, int id)
        {
            var getpro = await Context.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (imageFile != null && imageFile.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await imageFile.CopyToAsync(memoryStream);
                    var ImageData = memoryStream.ToArray();
                    if(getpro!= null)
                    {
                        
                        getpro.Imageurl = ImageData;
                        await updateprod(getpro);
                        return true;
                    }
                    
                }
               
            }

           
            return false;
        }
    }
}
