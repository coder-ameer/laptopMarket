using Microsoft.AspNetCore.Identity;
using laptopMarket.model_dto;
using laptopMarket.Model;

namespace laptopMarket.Repository.IRepository
{
    public interface IuserRepo
    {
        Task<string> Regestercustomer(CrappUser user);
        Task<bool> Aunthitecation(string username, string pw);
        Task<bool> creatrole(string rolename);
        Task<string> RegesterAdmin(CrappUser user);
        Task<string> Regestersuperadmin(CrappUser user);
        Task<bool> logout();
        Task<bool> DeleteUser(string username);
        Task<string> Change_role(string username, string newrolename, string oldrolename);
        Task<IList<IdentityUser>> getadmins();
    }
}
