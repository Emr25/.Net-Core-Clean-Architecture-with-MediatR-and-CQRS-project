using Application.Dto;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            //CATEGORY MAPPİNG

            CreateMap<Category,CategoryDto>()
                .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.Products));
            CreateMap<CategoryDto, Category>();


            //PRODUCT MAPPİNG
           CreateMap<Product,ProductDto>()
                .ForMember(dest => dest.CategoryId , opt => opt.MapFrom(src => src.Category.CategoryId));
           CreateMap<ProductDto, Product>();


        }
    }
}
