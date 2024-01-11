using AutoMapper;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTO
{
    public class ProductDTO
    {
        public int Code { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Stock { get; set; }
        public string Unit { get; set; }
        public double Margin { get; set; }
        public double Iva { get; set; }
        public bool State { get; set; }
        public int CategoryId { get; set; }
        public string image { get; set; }
    }

    public class ProductMapper : Profile
    {
        public ProductMapper()
        {
            CreateMap<ProductDTO, Product>()
                .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Code))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Stock, opt => opt.MapFrom(src => src.Stock))
                .ForMember(dest => dest.Unit, opt => opt.MapFrom(src => src.Unit))
                .ForMember(dest => dest.Margin, opt => opt.MapFrom(src => src.Margin))
                .ForMember(dest => dest.Iva, opt => opt.MapFrom(src => src.Iva))
                .ForMember(dest => dest.State, opt => opt.MapFrom(src => src.State))
                .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CategoryId))
                .ForMember(dest => dest.image, opt => opt.MapFrom(src => src.image))
                .ForMember(dest => dest.Category, opt => opt.Ignore())
                .ForMember(dest => dest.entries, opt => opt.Ignore())
                .ForMember(dest => dest.purchases, opt => opt.Ignore())
                .ForMember(dest => dest.productsproducers, opt => opt.Ignore());
        }
    }
}
