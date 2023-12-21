
namespace laptopMarket.Model
{
    public class Copon
    {
        public int Id { get; set; }
        public string? CoponName { get; set; }
        public string? CoponEvent { get; set; }
        public string? CoponDescription { get; set;} 
        public string? Coponvalue { get; set; }
        public string? Coponcode { get; set; }
        public int UsageLimit { get; set; }
        public int Usagecount { get; set; }
        public DateTime Expired { get; set; }
    }
}
