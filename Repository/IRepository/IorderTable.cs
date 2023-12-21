using laptopMarket.Model;

namespace laptopMarket.Repository.IRepository
{
    public interface IorderTable
    {
        Task<Order_table> getorder( int userid);
        Task<string> deleteOrder(Order_table ca);
        Task<bool> makeOrder(Order_table cat);
    }
}
