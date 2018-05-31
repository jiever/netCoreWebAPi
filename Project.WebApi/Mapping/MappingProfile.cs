using AutoMapper;
using Project.Model;
using Project.Model.Dtos;
using System.Collections.Generic;

namespace Project.WebApi.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<ProductDto, Product>();

            CreateMap<Menus, MenusDto>();
            CreateMap<MenusDto, Menus>();

            CreateMap<Menus, MenusTreeDto>();

            CreateMap<Areas, AreasDto>();
            CreateMap<AreasDto, Areas>();
        }
    }
}