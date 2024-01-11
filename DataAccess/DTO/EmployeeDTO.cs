using AutoMapper;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTO
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public int cedula { get; set; }
        public string Name { get; set; }
        public string lastName1 { get; set; }
        public string lastName2 { get; set; }
        public string department { get; set; }
        public int idUser { get; set; }
    }
    public class EmployeeMapper : Profile
    {
        public EmployeeMapper()
        {
            CreateMap<EmployeeDTO, Employee>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.cedula, opt => opt.MapFrom(src => src.cedula))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.lastName1, opt => opt.MapFrom(src => src.lastName1))
                .ForMember(dest => dest.lastName2, opt => opt.MapFrom(src => src.lastName2))
                .ForMember(dest => dest.department, opt => opt.MapFrom(src => src.department))
                .ForMember(dest => dest.idUser, opt => opt.MapFrom(src => src.idUser))
                .ForMember(dest => dest.user, opt => opt.Ignore());
        }
    }
}
