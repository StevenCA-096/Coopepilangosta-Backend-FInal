using AutoMapper;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTO
{
    public class EntryDTO
    {
        public double Quantity { get; set; }
        public DateTime EntryDate { get; set; }
        public DateTime ExpireDate { get; set; }
        public int ProducerOrderId { get; set; }
        public int ProductId { get; set; }
        public int WarehouseId { get; set; }

    }

    public class EntryMapper : Profile
    {
        public EntryMapper()
        {
            CreateMap<EntryDTO, Entry>()
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
                .ForMember(dest => dest.EntryDate, opt => opt.MapFrom(src => src.EntryDate))
                .ForMember(dest => dest.ExpireDate, opt => opt.MapFrom(src => src.ExpireDate))
                .ForMember(dest => dest.ProducerOrderId, opt => opt.MapFrom(src => src.ProducerOrderId))
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
                .ForMember(dest => dest.WarehouseId, opt => opt.MapFrom(src => src.WarehouseId))
                .ForMember(dest => dest.Warehouse, opt => opt.Ignore())
                .ForMember(dest => dest.ProducerOrder, opt => opt.Ignore())
                .ForMember(dest => dest.Product, opt => opt.Ignore());
        }
    }
}
