using AutoMapper;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTO
{
    public class PurchaseDTO
    {
        public int ProductId { get; set; }
        public double Quantity { get; set; }
        public double PurchaseTotal { get; set; }
       
        public int ProducerOrderId { get; set; }

    }

    public class PurchaseMapper : Profile
    {
        public PurchaseMapper()
        {
            CreateMap<PurchaseDTO, Purchase>()
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
                //.ForMember(dest => dest.PurchaseFinal, opt => opt.MapFrom(src => src.PurchaseFinal))
                .ForMember(dest => dest.PurchaseTotal, opt => opt.MapFrom(src => src.PurchaseTotal))
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
                .ForMember(dest => dest.ProducerOrderId, opt => opt.MapFrom(src => src.ProducerOrderId))
                .ForMember(dest => dest.Product, opt => opt.Ignore())
                .ForMember(dest => dest.ProducerOrder, opt => opt.Ignore()); 
         }
    }
}
