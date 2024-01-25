using AutoMapper;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTO
{
    public class CostumerDTO
    {
        public int id { get; set; }
        public int cedulaJuridica { get; set; }
        public string name { get; set; }
        public string province { get; set; }
        public string canton { get; set; }
        public string district { get; set; }
        public string address { get; set; }
        public int postalCode { get; set; }
        public string bankAccount { get; set; }
        public string verified { get; set; }


        //relations
        public int userId { get; set; }
    }

    public class CostumerMapper : Profile
    {
        public CostumerMapper()
        {
            CreateMap<CostumerDTO, Costumer>()
                .ForMember(dest => dest.id, opt => opt.MapFrom(src => src.id))
                .ForMember(dest => dest.cedulaJuridica, opt => opt.MapFrom(src => src.cedulaJuridica))
                .ForMember(dest => dest.name, opt => opt.MapFrom(src => src.name))
                .ForMember(dest => dest.province, opt => opt.MapFrom(src => src.province))
                .ForMember(dest => dest.district, opt => opt.MapFrom(src => src.district))
                .ForMember(dest => dest.address, opt => opt.MapFrom(src => src.address))
                .ForMember(dest => dest.postalCode, opt => opt.MapFrom(src => src.postalCode))
                .ForMember(dest => dest.bankAccount, opt => opt.MapFrom(src => src.bankAccount))
                .ForMember(dest => dest.verified, opt => opt.MapFrom(src => src.verified))
                .ForMember(dest => dest.costumersContacts, opt => opt.Ignore())
                .ForMember(dest => dest.costumersorders, opt => opt.Ignore())
                .ForMember(dest => dest.productscostumers, opt => opt.Ignore())
                .ForMember(dest => dest.reviews, opt => opt.Ignore())
                .ForMember(dest => dest.user, opt => opt.Ignore());
                
        }
    }

}
