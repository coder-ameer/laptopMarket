using laptopMarket.Data;
using laptopMarket.Model;
using laptopMarket.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace laptopMarket.Repository
{
    public class CartTableRepo : IcartTableRepo
    {
        private readonly laptopMarketContext Context;
        public CartTableRepo(laptopMarketContext context)
        {
            Context= context;   
        }

        public async Task<string> deletecart(Cart_table ca)
        {
            Context.Cart_tables.Remove(ca);
            await Context.SaveChangesAsync();
            return "cart is delete";
        }

        public async Task<Cart_table> getcart(string userid)
        {
            var Get = await Context.Cart_tables.Include(x=>x.appuser).FirstOrDefaultAsync(x => x.AppUserID == userid);

            return Get;
        }

        public async Task<bool> makecart(Cart_table cat)
        {
            await Context.Cart_tables.AddAsync(cat);
            await Context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> updatecart(Cart_table cat)
        {
            Context.Cart_tables.Update(cat);
            await Context.SaveChangesAsync();
            return true;
        }
    }
}
