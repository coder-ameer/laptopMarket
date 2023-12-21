using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace laptopMarket.Model
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public double? Quantity { get; set; }
        public string? Added_at { get; set; }
        public int Order_tableId { get; set; }//is property without migration because make error
        [ForeignKey("ProductId")]
        public Product? Product { get; set; }
    }
}
