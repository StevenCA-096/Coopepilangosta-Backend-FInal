using AutoMapper;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTO
{
    public class CostumerContactDTO
    {
        public int id { get; set; }
        public string name { get; set; }
        public string department { get; set; }
        public string contact { get; set; }
        public int costumerId { get; set; }
    }

    public class CostumerContactMapper : Profile
    {
        public CostumerContactMapper()
        {
            CreateMap<CostumerContactDTO, CostumersContact>()
                .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.id))
                .ForMember(dest => dest.name, opt => opt.MapFrom(src => src.name))
                .ForMember(dest => dest.department, opt => opt.MapFrom(src => src.department))
                .ForMember(dest => dest.contact, opt => opt.MapFrom(src => src.contact))
                .ForMember(dest => dest.costumerId, opt => opt.MapFrom(src => src.costumerId))
                .ForMember(dest => dest.costumer, opt => opt.Ignore());
        }
    }
}
