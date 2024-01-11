using AutoMapper;
using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTO
{
    public class CategoryDTO
    {
        public string Name { get; set; }
    }

    public class CategoryMapper : Profile
    {
        public CategoryMapper()
        {
            CreateMap<CategoryDTO, Category>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.products, opt => opt.Ignore()); 
        }
    }
}
