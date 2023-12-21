using laptopMarket.Data;
using laptopMarket.Model;
using laptopMarket.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace laptopMarket.Repository
{
    public class CartItemRepo : IcartItemRepo
    {
        private readonly laptopMarketContext Context;
        public CartItemRepo(laptopMarketContext context)
        {
            Context = context;
        }

        public async Task<bool> addQuantity(int quantity, int prodid, int cartid)
        {
            var get = await getProductitem(prodid, cartid);
            if (get == null)
            {
                return false;
            }
            get.Quantity= quantity;
           await updateitem(get);
            return true;
        }

        public async  Task<string> deleteitem(Cart_item ca)
        {
            Context.Cart_items.Remove(ca);
            await Context.SaveChangesAsync();
            return "item is delete";
        }

        public async  Task<Cart_item> getProductitem(int proid,int cartid)
        {
            var Get = await Context.Cart_items.FirstOrDefaultAsync(x => x.ProductId == proid&& x.Cart_tableId==cartid);

            return Get;
        }

        public async Task<bool> makeitem(Cart_item cat)
        {
            await Context.Cart_items.AddAsync(cat);
            await Context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> updateitem(Cart_item cat)
        {
            Context.Cart_items.Update(cat);
            await Context.SaveChangesAsync();
            return true;
        }
    }
}
