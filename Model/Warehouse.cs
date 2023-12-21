using System.ComponentModel.DataAnnotations;
namespace laptopMarket.Model
{
    public class Warehouse
    {
        [Key]
        public int Id { get; set; } 
        public string? WarehouseName { get; set; }
        public string? WarehouseDescription { get; set; }
        public string? Location_map { get; set; }
        public byte[]? Imageurl { get; set; }
        public string? Warehous_hours { get; set; }
        public string? City { get; set; }
        public string? Region { get; set; }
        public int Phone_number { get; set;}
        public virtual ICollection<Warehouse_pro_qu>? Warehouse_pro_qu { get; set; }

    }
}
