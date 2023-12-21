using System.ComponentModel.DataAnnotations;

namespace laptopMarket.Model
{
    public class Category
    {
         [Key]
        public int Id { get; set; }
        public string? CategoryName { get; set; }
        public string? CategoryDescription { get; set; }
        public int Icon { get; set; }
        public string? Keyword { get; set; }
       public virtual ICollection<Product>? Product { get; set; }
    }
}
