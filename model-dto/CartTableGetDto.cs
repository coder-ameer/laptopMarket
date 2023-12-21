using laptopMarket.Model;

namespace laptopMarket.model_dto
{
    public class CartTableGetDto
    {
        public int Id { get; set; }
        public string? Created_at { get; set; }
        public UserCartDto? appuser { get; set; }
    }
}
