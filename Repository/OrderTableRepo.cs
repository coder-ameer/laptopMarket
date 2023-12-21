using laptopMarket.Data;
using laptopMarket.Model;
using laptopMarket.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace laptopMarket.Repository
{
    public class OrderTableRepo : IorderTable
    {
        private readonly laptopMarketContext Context;
        public OrderTableRepo(laptopMarketContext context)
        {
            Context = context;
        }

        public async Task<string> deleteOrder(Order_table ca)
        {
            Context.Order_tables.Remove(ca);
            await Context.SaveChangesAsync();
            return "order is delete";
        }
        public async Task<Order_table> getorder(int userid)
        {
            var Get = await Context.Order_tables.FirstOrDefaultAsync(x => x.Id == userid);
            return Get;
        }

        public async Task<bool> makeOrder(Order_table cat)
        {
            await Context.Order_tables.AddAsync(cat);
            await Context.SaveChangesAsync();
            return true;
        }
    }
}
