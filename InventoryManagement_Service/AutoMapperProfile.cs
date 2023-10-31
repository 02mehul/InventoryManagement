using AutoMapper;
using InventoryManagement.Common.DTOs.Master;
using InventoryManagement.Entity.Master;

namespace InventoryManagement.Service
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ProductDTO, ProductEntity>().ReverseMap();

        }
    }
}
