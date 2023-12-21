using laptopMarket.Model;
using laptopMarket.model_dto;
using AutoMapper;
namespace laptopMarket.ModelMapping
{
    public class ModelMapping: Profile
    {
        public ModelMapping()
        {
            CreateMap<Product,GetProductDto>().ReverseMap();
            CreateMap<Product, PostProductDto>().ReverseMap();
            CreateMap<Product, PutProductDto>().ReverseMap();
            CreateMap<Copon, GetCoponDto>().ReverseMap();
            CreateMap<Copon,PostCopon>().ReverseMap();
            CreateMap<Copon, PutcoponDto>().ReverseMap();
            CreateMap<Warehouse, PostwarehouseDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<WarehouseproDto, Warehouse_pro_qu>().ReverseMap();
            CreateMap<Cart_item, CartItemdto>().ReverseMap();
            CreateMap<PostcartTabledto, Cart_table>().ReverseMap();
            CreateMap<CartTableGetDto, Cart_table>().ReverseMap();
            CreateMap<UserCartDto, AppUser>().ReverseMap();
        }
    }
}
