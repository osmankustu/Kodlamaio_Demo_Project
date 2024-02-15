using AutoMapper;
using KodlamaIo.Business.Abstract;
using KodlamaIo.Business.DTOs.CourseDTOs;
using KodlamaIo.Core.Util.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIo.Business.Features.Queries.CourseQueries
{
    public class GetByIdCourseQuery : IRequest<IDataResult<CourseViewModel>>
    {
        public int Id { get; set; }

        public class GetByIdCourseQueryHandler : IRequestHandler<GetByIdCourseQuery, IDataResult<CourseViewModel>>
        {
            private readonly ICourseService _courseService;
            private readonly IMapper _mapper;

            public GetByIdCourseQueryHandler(ICourseService courseService, IMapper mapper)
            {
                _courseService = courseService;
                _mapper = mapper;
            }

            public async Task<IDataResult<CourseViewModel>> Handle(GetByIdCourseQuery request, CancellationToken cancellationToken)
            {
                var course = await _courseService.GetByIdAsync(request.Id);
                
                var viewModel = _mapper.Map<CourseViewModel>(course.Data);

                return new SuccessDataResult<CourseViewModel>(viewModel);
            }
        }
    }
}
