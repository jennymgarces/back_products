using srv_products.DTOs;
using srv_products.Models;
using AutoMapper;

namespace srv_products.Profiles
{
    public class MappingProfile : Profile
    {
         public MappingProfile()
         {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Product, ProductCreateDto>().ReverseMap();

            CreateMap<ProductImage, ProductImageDto>().ReverseMap();
            CreateMap<ProductImage, ProductImageCreateDto>().ReverseMap();

        }
        
    }
}
