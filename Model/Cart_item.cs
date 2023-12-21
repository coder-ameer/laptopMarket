using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace laptopMarket.Model
{
    public class Cart_item
    {
        [Key]
        public int Id { get; set; }
        public int ProductId { get; set; }
        public double? Quantity { get; set; }
        public string? Added_at { get; set;}
       
        public int Cart_tableId { get; set; }//this property without migration because make error
        [ForeignKey("ProductId")]
        public Product? Product { get; set; }
    }
}
