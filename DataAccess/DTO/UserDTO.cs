using AutoMapper;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }

        public string Password { get; set; }
        public int idRole { get; set; }
    }

    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<UserDTO, User>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.UserName))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
                .ForMember(dest => dest.idRole, opt => opt.MapFrom(src => src.idRole))
                .ForMember(dest => dest.role, opt => opt.Ignore())
                .ForMember(dest => dest.costumer, opt => opt.Ignore())
                .ForMember(dest => dest.employee, opt => opt.Ignore());
        }
    }
}
