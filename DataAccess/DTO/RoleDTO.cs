using AutoMapper;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTO
{
    public class RoleDTO
    {
        public string Name { get; set; }
    }
    public class RoleMapper : Profile
    {
        public RoleMapper()
        {
            CreateMap<RoleDTO, Role>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.users, opt => opt.Ignore());
        }
    }
}
