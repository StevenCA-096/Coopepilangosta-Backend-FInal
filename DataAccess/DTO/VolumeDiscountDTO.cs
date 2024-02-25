using AutoMapper;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTO
{
    public class VolumeDiscountDTO
    {
        public double Price { get; set; }
        public double Volume { get; set; }
        public double ProductCostumerId { get; set; }

    }

    public class VolumeDiscountMapper : Profile
    {
        public VolumeDiscountMapper()
        {
            CreateMap<VolumeDiscountDTO, VolumeDiscount>()
                .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
                .ForMember(dest => dest.Volume, opt => opt.MapFrom(src => src.Volume))
                .ForMember(dest => dest.ProductCostumerId, opt => opt.MapFrom(src => src.ProductCostumerId))
                .ForMember(dest => dest.ProductCostumer, opt => opt.Ignore()); 
        }
    }
}
