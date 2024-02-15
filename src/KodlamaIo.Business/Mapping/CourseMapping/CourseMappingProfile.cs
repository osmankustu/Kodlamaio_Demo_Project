using AutoMapper;
using KodlamaIo.Business.DTOs.CourseDTOs;
using KodlamaIo.Business.Features.Commands.CourseCommand;
using KodlamaIo.Business.Features.Queries.CourseQueries;
using KodlamaIo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIo.Business.Mapping.CourseMapping
{
    public class CourseMappingProfile : Profile
    {

        public CourseMappingProfile()
        {
            CreateMap<Course, CourseViewModel>().ReverseMap()
                .ForMember(x=>x.Instructor,y=>y.MapFrom(z=>z.Instructor))
                .ForMember(x=>x.CourseCategory,x=>x.MapFrom(z=>z.CourseCategory));
            
            CreateMap<Course, GetByIdCourseQuery>().ReverseMap();

            CreateMap<Course,CreateCourseCommand>().ReverseMap();

            CreateMap<Course, UpdateCourseCommand>().ReverseMap();

            

        }
    }
}
