using laptopMarket.Model;

namespace laptopMarket.Repository.IRepository
{
    public interface IcartItemRepo
    {
        Task<Cart_item> getProductitem(int proid, int cartid);
        Task<string> deleteitem(Cart_item ca);
        Task<bool> updateitem(Cart_item cat);
        Task<bool> makeitem(Cart_item cat);
        Task<bool> addQuantity(int quantity, int prodid, int cartid);
       

    }
}
