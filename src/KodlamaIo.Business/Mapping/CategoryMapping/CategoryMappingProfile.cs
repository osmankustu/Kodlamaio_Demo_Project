using AutoMapper;
using KodlamaIo.Business.DTOs.CourseCategoryDTOs;
using KodlamaIo.Business.Features.Commands.CourseCategoryCommand;
using KodlamaIo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIo.Business.Mapping.CategoryMapping
{
    public class CategoryMappingProfile : Profile
    {
        public CategoryMappingProfile()
        {
            CreateMap<CourseCategory, CourseCategoryViewModel>().ReverseMap();  
            CreateMap<CourseCategory,CreateCourseCategoryCommand>().ReverseMap();
            CreateMap<CourseCategory,UpdateCourseCategoryCommand>().ReverseMap();
        }
    }
}
