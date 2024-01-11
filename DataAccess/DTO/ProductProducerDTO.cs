using AutoMapper;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTO
{
    public class ProductProducerDTO
    {
        public int ProductId { get; set; }
        public int ProducerId { get; set; }
        public double PurchasePrice { get; set; }

    }

    public class ProductProducerMapper : Profile
    {
        public ProductProducerMapper()
        {
            CreateMap<ProductProducerDTO, ProductProducer>()
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
                .ForMember(dest => dest.ProducerId, opt => opt.MapFrom(src => src.ProducerId))
                .ForMember(dest => dest.PurchasePrice, opt => opt.MapFrom(src => src.PurchasePrice))
                .ForMember(dest => dest.Product, opt => opt.Ignore())
                .ForMember(dest => dest.Producer, opt => opt.Ignore());        
        }
    }
}
