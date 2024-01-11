using AutoMapper;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTO
{
    public class ProducerDTO
    {
        public int Cedula { get; set; }
        public string Name { get; set; }
        public string Lastname1 { get; set; }
        public string Lastname2 { get; set; }
        public int PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Province { get; set; }
        public string Canton { get; set; }
        public string District { get; set; }
        public string Address { get; set; }
        public int BankAccount { get; set; }

    }

    public class ProducerMapper : Profile
    {
        public ProducerMapper()
        {
            CreateMap<ProducerDTO, Producer>()
                .ForMember(dest => dest.Cedula, opt => opt.MapFrom(src => src.Cedula))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Lastname1, opt => opt.MapFrom(src => src.Lastname1))
                .ForMember(dest => dest.Lastname2, opt => opt.MapFrom(src => src.Lastname2))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Province, opt => opt.MapFrom(src => src.Province))
                .ForMember(dest => dest.Canton, opt => opt.MapFrom(src => src.Canton))
                .ForMember(dest => dest.District, opt => opt.MapFrom(src => src.District))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
                .ForMember(dest => dest.producersorders, opt => opt.Ignore())
                .ForMember(dest => dest.productsproducers, opt => opt.Ignore());
        }
    }
}
