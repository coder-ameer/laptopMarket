using laptopMarket.Data;
using laptopMarket.Model;
using laptopMarket.Repository.IRepository;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace laptopMarket.Repository
{
    public class warehouseProRepo : IwarehouseProRepo
    {
        private readonly laptopMarketContext context;
        public warehouseProRepo(laptopMarketContext context)
        {
            this.context = context;
        }

        public async  Task<bool> decreaseQuantity(int quantity,int id)
        {
            var get = await getwarehousePro(id);
            if (get == null)
            {
                return false;
            }
            if(get.Quantity==0&& get.Quantity>quantity)
            {
                return false;
            }
           
            get.Quantity-= quantity;
            await updatewarehousePro(get);
            return true;

        }

        public async Task<string> deletewarehousePro(Warehouse_pro_qu ware)
        {
            context.Warehouse_pro_qus.Remove(ware);
            await context.SaveChangesAsync();
            return "warehouse  is delete";
        }

        public async Task<Warehouse_pro_qu> getwarehousePro(int id)
        {
            var Get = await context.Warehouse_pro_qus.FirstOrDefaultAsync(x => x.ProductId == id);
            return Get;
        }

        public async Task<bool> IncreaseQuantity(int quantity,int id)
        {
            var get = await getwarehousePro(id);
            if (get == null)
            {
                return false;
            }
            get.Quantity+=quantity;
            return true;
        }

        public async  Task<bool> makewarehousePro(Warehouse_pro_qu ware)
        {
            await context.Warehouse_pro_qus.AddAsync(ware);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> updatewarehousePro(Warehouse_pro_qu ware)
        {
            context.Warehouse_pro_qus.Update(ware);
            await context.SaveChangesAsync();
            return true;
        }
        public async Task<Warehouse_pro_qu> checkwarehouse(int id)
        {
            var Get = await context.Warehouse_pro_qus.FirstOrDefaultAsync(x => x.WarehouseId == id);
            return Get;
        }
        public async Task<bool>ifexist(int proid,int warid)
        {
            var check = await getwarehousePro(proid);
            var checkware = await checkwarehouse(warid);
            if(check.Id==checkware.Id)
            {
                return false;
            }
            return true;


        }
    }
}
