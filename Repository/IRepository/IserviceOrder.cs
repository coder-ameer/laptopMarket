namespace laptopMarket.Repository.IRepository
{
    public interface IserviceOrder
    {
        Task<bool> OrderTransaction(string UserId);
    }
}
