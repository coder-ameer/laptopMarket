using laptopMarket.Model;

namespace laptopMarket.Repository.IRepository
{
    public interface Icategory
    {
        Task<Category> getcategory(int id);
        Task<string> deletecategory(Category ca);
        Task<bool> updatecategory(Category cat);
        Task<bool> makecategory(Category cat);
        Task<Category> check_name(string productename);
        Task<Category> getcategory_product(int id);
    }
}
