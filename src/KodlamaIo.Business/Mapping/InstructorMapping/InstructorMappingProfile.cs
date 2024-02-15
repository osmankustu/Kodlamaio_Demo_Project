using AutoMapper;
using KodlamaIo.Business.DTOs.InstructorDTOs;
using KodlamaIo.Business.Features.Commands.InstructorCommand;
using KodlamaIo.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIo.Business.Mapping.InstructorMapping
{
    public class InstructorMappingProfile : Profile
    {
        public InstructorMappingProfile()
        {
            CreateMap<Instructor, InstructorViewModel>().ReverseMap();
            CreateMap<Instructor,CreateInstructorCommand>().ReverseMap();
            CreateMap<Instructor,DeleteInstructorCommand>().ReverseMap();
            CreateMap<Instructor,UpdateInstructorCommand>().ReverseMap();
            
        }
    }
}
