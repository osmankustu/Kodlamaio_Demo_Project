using AutoMapper;
using KodlamaIo.Business.Abstract;
using KodlamaIo.Core.Util.Result;
using KodlamaIo.Entities.Concrete;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIo.Business.Features.Commands.CourseCommand
{
    public class CreateCourseCommand : IRequest<IResult>
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int CourseCategoryId { get; set; }

        public int InstructorId { get; set; }

        public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommand, IResult>
        {
            private readonly ICourseService _courseService;
            private readonly IMapper _mapper;

            public CreateCourseCommandHandler(ICourseService courseService, IMapper mapper)
            {
                _courseService = courseService;
                _mapper = mapper;
            }

            public async Task<IResult> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
            {
                var course = _mapper.Map<Course>(request);
                
                course.CreateDate = DateTime.Now;

                return await _courseService.AddAsync(course);
            }
        }
    }
}
