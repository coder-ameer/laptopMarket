using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace laptopMarket.Model
{
    public class Warehouse_pro_qu
    {
        [Key]
        public int Id { get; set; }
        public int WarehouseId { get; set; }//is property without migration because make error
        public int ProductId { get; set; }//is property without migration because make error
        public double? Quantity { get; set;}
        
    }
}
