using laptopMarket.Model;

namespace laptopMarket.Repository.IRepository
{
    public interface Iproduct
    {
        Task<Product>getproduct(int id);
        Task<string> deleteproduct(Product pro);
        Task<bool> updateprod(Product pro);
        Task<bool> makeproduct(Product pro);
        Task<bool> add_copon_toProduct(string coponname,int id);
        Task<bool> delete_copon_fromProduct(int id);
        Task<Product> check_name(string productename);
        Task<bool> UploadImage(IFormFile imageFile, int id);
    }
}
