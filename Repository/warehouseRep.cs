
using Microsoft.EntityFrameworkCore;
using laptopMarket.Model;
using laptopMarket.Repository.IRepository;
using laptopMarket.Data;

namespace laptopMarket.Repository
{
    public class warehouseRep : IwareHouse
    {
        private readonly laptopMarketContext Context;
       
        public warehouseRep(laptopMarketContext context)
        {
            Context = context;
        }

        public async Task<string> Deletewarehouse(Warehouse pro)
        {
           
            Context.Warehouses.Remove(pro);
            await Context.SaveChangesAsync();
            return "item is delete";
        }

        public async Task<Warehouse> Getwarehouse(int id)
        {
            var Get = await Context.Warehouses.FirstOrDefaultAsync(x => x.Id == id);

            return Get;
        }

        public async Task<bool> Makewarehouse(Warehouse pro)
        {
            await Context.Warehouses.AddAsync(pro);
            await Context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateWarehouse(Warehouse pro)
        {
            Context.Warehouses.Update(pro);
            await Context.SaveChangesAsync();
            return true;
        }
        public async Task<Warehouse> check_name(string warehousename)
        {
            var res = await Context.Warehouses.FirstOrDefaultAsync(x => x.WarehouseName == warehousename);
            return res;
        }
       
    }
}
