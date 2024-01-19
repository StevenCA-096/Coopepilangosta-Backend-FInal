using AutoMapper;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTO
{
    public class ReviewDTO
    {
        public string Description { get; set; }
        public int Stars { get; set; }
        public int ProductId { get; set; }
        public int CostumerId { get; set; }
        public DateTime ReviewDate { get; set; }

    }

    public class ReviewMapper : Profile
    {
        public ReviewMapper()
        {
            CreateMap<ReviewDTO, Review>()
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Stars, opt => opt.MapFrom(src => src.Stars))
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
                .ForMember(dest => dest.CostumerId, opt => opt.MapFrom(src => src.CostumerId))
                .ForMember(dest => dest.product, opt => opt.Ignore())
                .ForMember(dest => dest.costumer, opt => opt.Ignore());
        }
    }
}
