using laptopMarket.Model;

namespace laptopMarket.Repository.IRepository
{
    public interface Icopon
    {
        Task<Copon> readcopon (int id);
        Task<bool> writecopon (Copon copo);
        Task<string> deletecopon (int id);
        Task<bool> updatecopon (Copon copo);
        Task<string> hashcode(string code);
        Task<bool> Comparecode(string code);
        Task<bool> check_delete(string hashcode);
        Task<bool> check_Ifexpire(DateTime da);
        Task<string> check_Ifvalid(string coponcode);
        Task<IEnumerable<Copon>> check_allusage();
        Task<Copon> check_name(string coponname);


    }
}
