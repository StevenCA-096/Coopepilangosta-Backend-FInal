using AutoMapper;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTO
{
    public class CostumerOrderDTO
    {
        public double Total { get; set; }
        public int CostumerId { get; set; }
        public DateTime ConfirmedDate { get; set; }
        public DateTime PaidDate { get; set; }
        public DateTime DeliveredDate { get; set; }
        public string Detail { get; set; }
        public string Stage { get; set; }
        public string Address { get; set; }


        public class CostumerOrderMapper : Profile
        {
            public CostumerOrderMapper()
            {
                CreateMap<CostumerOrderDTO, CostumerOrder>()
                    .ForMember(dest => dest.Total, opt => opt.MapFrom(src => src.Total))
                    .ForMember(dest => dest.CostumerId, opt => opt.MapFrom(src => src.CostumerId))
                    .ForMember(dest => dest.ConfirmedDate, opt => opt.MapFrom(src => src.ConfirmedDate))
                    .ForMember(dest => dest.PaidDate, opt => opt.MapFrom(src => src.PaidDate))
                    .ForMember(dest => dest.DeliveredDate, opt => opt.MapFrom(src => src.DeliveredDate))
                    .ForMember(dest => dest.Detail, opt => opt.MapFrom(src => src.Detail))
                    .ForMember(dest => dest.Stage, opt => opt.MapFrom(src => src.Stage))
                    .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))

                    //.ForMember(dest => dest.Paid, opt => opt.Ignore())
                    //.ForMember(dest => dest.Delivered, opt => opt.Ignore())

                    .ForMember(dest => dest.Costumer, opt => opt.Ignore())
                    .ForMember(dest => dest.sales, opt => opt.Ignore());
            }
        }
    }
}
