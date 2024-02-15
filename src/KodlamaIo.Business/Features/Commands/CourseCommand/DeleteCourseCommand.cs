using AutoMapper;
using KodlamaIo.Business.Abstract;
using KodlamaIo.Core.Util.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIo.Business.Features.Commands.CourseCommand
{
    public class DeleteCourseCommand : IRequest<IResult>
    {
        public int Id { get; set; }

        public class DeleteCourseCommandHandler : IRequestHandler<DeleteCourseCommand, IResult>
        {
            private readonly ICourseService _courseService;
            private readonly IMapper _mapper;

            public DeleteCourseCommandHandler(ICourseService courseService, IMapper mapper)
            {
                _courseService = courseService;
                _mapper = mapper;
            }

            public async Task<IResult> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
            {
                var course = await _courseService.GetByIdAsync(request.Id);

                return await _courseService.DeleteAsync(course.Data);
            }
        }
    }
}
