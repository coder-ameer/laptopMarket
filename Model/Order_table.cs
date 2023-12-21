using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace laptopMarket.Model
{
    public class Order_table
    {
        [Key]
        public int Id { get; set; }
        public string? Order_date { get; set;}
        public string? Status { get; set;}
        public double Total_amount { get; set; }
        public string? AppUserID { get; set; }
        [ForeignKey("AppUserID")]
        public AppUser? appuser { get; set; }
        public virtual ICollection<OrderItem>? OrderItem { get; set; }

    }
}
