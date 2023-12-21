using laptopMarket.Data;
using laptopMarket.Model;
using laptopMarket.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace laptopMarket.Repository
{
    public class OrderitemRepo : IorderItem
    {
        private readonly laptopMarketContext Context;
        public OrderitemRepo(laptopMarketContext context)
        {
            Context = context;
        }

        public async Task<string> deleteitem(OrderItem or)
        {
            Context.OrderItems.Remove(or);
            await Context.SaveChangesAsync();
            return "item is delete";
        }

        public async Task<OrderItem> getProductitem(int proid, int orderid)
        {
            var Get = await Context.OrderItems.FirstOrDefaultAsync(x => x.ProductId == proid&&x.Order_tableId== orderid);

            return Get;
        }

        public async Task<bool> makeitem(OrderItem or)
        {
            await Context.OrderItems.AddAsync(or);
            await Context.SaveChangesAsync();
            return true;
        }

       
    }
}
