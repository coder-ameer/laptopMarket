using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace laptopMarket.Model
{
    public class Cart_table
    {
        [Key]
        public int Id { get; set; }
        public string? AppUserID { get; set; }
        public string? Created_at { get; set; }
        [ForeignKey("AppUserID")]
        public AppUser? appuser { get; set; }
        public virtual ICollection<Cart_item>? Cart_item { get; set; }
    }
}
