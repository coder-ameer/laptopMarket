using laptopMarket.Model;
namespace laptopMarket.model_dto
{
    public class GetProductDto
    {
        public string? Name { get; set; }
        public double Price { get; set; }
        public string? Description { get; set; }
        public int CategoryId { get; set; } 
        public byte[]? Imageurl { get; set; }
        public string? brand { get; set; }
        public string? Processor { get; set; }
        public string? RAM_Memory { get; set; }
        public string? Storage { get; set; }
        public string? Graphics_Card { get; set; }
        public string? Display_Size { get; set; }
        public string? Operating_System { get; set; }
        public string? Availability { get; set; }
        public string? Weight { get; set; }
        public string? Connectivity { get; set; }
        public string? Battery_Life { get; set; }
        public GetCoponDto? coPons { get; set; }

        
    }
}
