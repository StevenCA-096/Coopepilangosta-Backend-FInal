using AutoMapper;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTO
{
    public class WarehouseDTO
    {
        public int Id { get; set; }
        public int Code { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public bool State { get; set; }
    }

    public class WarehouseMapper : Profile
    {
        public WarehouseMapper()
        {
            CreateMap<WarehouseDTO, Warehouse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Code))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Address ,opt => opt.MapFrom(src => src.Address))
                .ForMember(dest => dest.entries, opt => opt.Ignore());
        }
    }
}
