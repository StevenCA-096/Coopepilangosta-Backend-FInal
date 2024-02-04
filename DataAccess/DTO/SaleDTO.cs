using AutoMapper;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTO
{
    public class SaleDTO
    {
        public int ProductId { get; set; }
        public double Quantity { get; set; }
        public double PurchaseTotal { get; set; }
        public int CostumerOrderId { get; set; }
        public double UnitPrice { get; set; }
        public string Unit { get; set; }

    }

    public class SaleMapper : Profile
    {
        public SaleMapper()
        {
            CreateMap<SaleDTO, Sale>()
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
                .ForMember(dest => dest.PurchaseTotal, opt => opt.MapFrom(src => src.PurchaseTotal))
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
                .ForMember(dest => dest.CostumerOrderId, opt => opt.MapFrom(src => src.CostumerOrderId))
                .ForMember(dest => dest.UnitPrice, opt => opt.MapFrom(src => src.UnitPrice))
                .ForMember(dest => dest.Unit, opt => opt.MapFrom(src => src.Unit))
                .ForMember(dest => dest.Product, opt => opt.Ignore())
                .ForMember(dest => dest.CostumerOrder, opt => opt.Ignore());
        }
    }
}
