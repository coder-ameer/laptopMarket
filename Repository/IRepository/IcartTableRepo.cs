using laptopMarket.Model;

namespace laptopMarket.Repository.IRepository
{
    public interface IcartTableRepo
    {
        Task<Cart_table> getcart(string  userid);
        Task<string> deletecart(Cart_table ca);
        Task<bool> updatecart(Cart_table cat);
        Task<bool> makecart(Cart_table cat);
       
    }
}
