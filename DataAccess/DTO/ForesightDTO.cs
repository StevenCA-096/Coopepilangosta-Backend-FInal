using AutoMapper;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTO
{
    public class ForesightDTO
    {
        public int Id { get; set; }
        public DateTime initialDate { get; set; }
        public DateTime endDate { get; set; }
        public int IdProduct { get; set; }
    }
    public class ForesightMapper : Profile
    {
        public ForesightMapper()
        {
            CreateMap<ForesightDTO, Foresight>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.initialDate, opt => opt.MapFrom(src => src.initialDate))
                .ForMember(dest => dest.endDate, opt => opt.MapFrom(src => src.endDate))
                .ForMember(dest => dest.IdProduct, opt => opt.MapFrom(src => src.IdProduct));
                
        }
    }
}
