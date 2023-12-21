using laptopMarket.Model;

namespace laptopMarket.Repository.IRepository
{
    public interface IwarehouseProRepo
    {
        Task<Warehouse_pro_qu> getwarehousePro(int id);
        Task<string> deletewarehousePro(Warehouse_pro_qu ware);
        Task<bool> updatewarehousePro(Warehouse_pro_qu ware);
        Task<bool> makewarehousePro(Warehouse_pro_qu ware);
        Task<bool>IncreaseQuantity(int quantity,int id);
        Task<bool> decreaseQuantity(int quantity, int id);
        Task<Warehouse_pro_qu> checkwarehouse(int id);
        Task<bool> ifexist(int proid, int warid);
    }
}
