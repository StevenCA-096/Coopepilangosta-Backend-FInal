using AutoMapper;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTO
{
    public class ForesightProducerDTO
    {
        public int ProducerId { get; set; }
        public int ForesightId { get; set; }

        public class ForesightProducerDTOMapper : Profile
        {
            public ForesightProducerDTOMapper()
            {
                CreateMap<ForesightProducerDTO, ForesightProducer>()
                    .ForMember(dest => dest.ForesightId, opt => opt.MapFrom(src => src.ForesightId))
                    .ForMember(dest => dest.ProducerId, opt => opt.MapFrom(src => src.ProducerId));
                    
            }
        }
    }
}
