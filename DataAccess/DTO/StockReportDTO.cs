using AutoMapper;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTO
{
    public class StockReportDTO
    {
        public string ProductName { get; set; }
        public DateTime CambioFecha { get; set; }
        public int OldStock { get; set; }
        public int NewStock { get; set; }
        public string motive { get; set; }
        public string Email { get; set; }
        public int ProductId { get; set; }
    }

    public class StockReportMapper : Profile
    {
        public StockReportMapper()
        {
            CreateMap<StockReportDTO, StockReport>()
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.ProductName))
                .ForMember(dest => dest.CambioFecha, opt => opt.MapFrom(src => src.CambioFecha))
                .ForMember(dest => dest.OldStock, opt => opt.MapFrom(src => src.OldStock))
                .ForMember(dest => dest.NewStock, opt => opt.MapFrom(src => src.NewStock))
                .ForMember(dest => dest.motive, opt => opt.MapFrom(src => src.motive))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
                .ForMember(dest => dest.Product, opt => opt.Ignore());
        }
    }
}
