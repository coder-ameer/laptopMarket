using laptopMarket.Model;

namespace laptopMarket.Repository.IRepository
{
    public interface IorderItem
    {
        Task<OrderItem> getProductitem(int proid, int orderid);
        Task<string> deleteitem(OrderItem or);
        Task<bool> makeitem(OrderItem or);
    }
}
