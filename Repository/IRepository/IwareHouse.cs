using laptopMarket.Model;

namespace laptopMarket.Repository.IRepository
{
    public interface IwareHouse
    {
        Task<Warehouse> Getwarehouse(int id);
        Task<string> Deletewarehouse(Warehouse pro);
        Task<bool> UpdateWarehouse(Warehouse pro);
        Task<bool> Makewarehouse(Warehouse pro);
        Task<Warehouse> check_name(string warehousename);
    }
}
