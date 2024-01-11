using AutoMapper;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTO
{
    public class ProducerOrderDTO
    {
        public double Total { get; set; }
        public int ProducerId { get; set; }
        public DateTime ConfirmedDate { get; set; }
        public DateTime PaidDate { get; set; }
        public DateTime DeliveredDate { get; set; }
        public string Detail { get; set; }
    

        public class ProducerOrderMapper : Profile
        {
            public ProducerOrderMapper()
            {
                CreateMap<ProducerOrderDTO, ProducerOrder>()
                    .ForMember(dest => dest.Total, opt => opt.MapFrom(src => src.Total))
                    .ForMember(dest => dest.ProducerId, opt => opt.MapFrom(src => src.ProducerId))
                    .ForMember(dest => dest.ConfirmedDate, opt => opt.MapFrom(src => src.ConfirmedDate))
                    .ForMember(dest => dest.PaidDate, opt => opt.MapFrom(src => src.PaidDate))
                    .ForMember(dest => dest.DeliveredDate, opt => opt.MapFrom(src => src.DeliveredDate))
                    .ForMember(dest => dest.Detail, opt => opt.MapFrom(src => src.Detail))


                    //.ForMember(dest => dest.Paid, opt => opt.Ignore())
                    //.ForMember(dest => dest.Delivered, opt => opt.Ignore())

                    .ForMember(dest => dest.Producer, opt => opt.Ignore())
                    .ForMember(dest => dest.purchases, opt => opt.Ignore())
                    .ForMember(dest => dest.entries, opt => opt.Ignore());
            }
        }
    }

}
