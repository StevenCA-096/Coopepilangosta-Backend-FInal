using AutoMapper;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTO
{
    public class ProductCostumerDTO
    {
        public int ProductId { get; set; }
        public int CostumerId { get; set; }
        public double PurchasePrice { get; set; }
        public string Description { get; set; }
        public double Margin { get; set; }
        public string Unit { get; set; }

    }

    public class ProductCostumerMapper : Profile
    {
        public ProductCostumerMapper()
        {
            CreateMap<ProductCostumerDTO, ProductCostumer>()
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
                .ForMember(dest => dest.CostumerId, opt => opt.MapFrom(src => src.CostumerId))
                .ForMember(dest => dest.PurchasePrice, opt => opt.MapFrom(src => src.PurchasePrice))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Margin, opt => opt.MapFrom(src => src.Margin))
                .ForMember(dest => dest.Unit, opt => opt.MapFrom(src => src.Unit))
                .ForMember(dest => dest.Product, opt => opt.Ignore())
                .ForMember(dest => dest.volumediscounts, opt => opt.Ignore())
                .ForMember(dest => dest.Costumer, opt => opt.Ignore());
        }
    }
}
