using Microsoft.EntityFrameworkCore;
using laptopMarket.Data;
using laptopMarket.Repository.IRepository;
using laptopMarket.Model;
namespace laptopMarket.Repository
{
    public class CategoryRep : Icategory
    {
        private readonly laptopMarketContext Context;
        public CategoryRep(laptopMarketContext context)
        {
            Context = context;
        }

        public async Task<Category> check_name(string categoryename)
        {
            var res = await Context.Categorys.FirstOrDefaultAsync(x => x.CategoryName == categoryename);
            return res;
        }

        public async Task<string> deletecategory(Category ca)
        {
            
            Context.Categorys.Remove(ca);
            await Context.SaveChangesAsync();
            return "category is delete";
        }

        public async Task<Category> getcategory(int id)
        {
            var Get = await Context.Categorys.FirstOrDefaultAsync(x => x.Id == id);

            return Get;
        }

        public async Task<bool> makecategory(Category cat)
        {
            await Context.Categorys.AddAsync(cat);
            await Context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> updatecategory(Category cat)
        {
            Context.Categorys.Update(cat);
            await Context.SaveChangesAsync();
            return true;
        }
        public async Task<Category> getcategory_product(int id)
        {
            var Get = await Context.Categorys.Include(x => x.Product)
                .FirstOrDefaultAsync(x => x.Id == id);

            return Get;
        }

    }
}
