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
    public class UpdateCourseCommand : IRequest<IResult>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public int CourseCategoryId { get; set; }

        public int InstructorId { get; set; }

        public class UpdateCourseCommandHandler : IRequestHandler<UpdateCourseCommand,IResult>
        {
            private readonly ICourseService _courseService;
            private readonly IMapper _mapper;

            public UpdateCourseCommandHandler(ICourseService courseService, IMapper mapper)
            {
                _courseService = courseService;
                _mapper = mapper;
            }

            public async Task<IResult> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
            {
                var course = _mapper.Map<Course>(request);
                
                return await _courseService.UpdateAsync(course);
            }
        }
    }
}
