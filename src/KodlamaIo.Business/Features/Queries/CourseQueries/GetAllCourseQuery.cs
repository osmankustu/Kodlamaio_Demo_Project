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
    public class GetAllCourseQuery : IRequest<IDataResult<List<CourseViewModel>>>
    {

        public class GetAllCourseQueryHandler : IRequestHandler<GetAllCourseQuery, IDataResult<List<CourseViewModel>>>
        {
            private readonly ICourseService _courseService;
            private readonly IMapper _mapper;

            public GetAllCourseQueryHandler(ICourseService courseService,IMapper mapper)
            {
                _courseService = courseService;
                _mapper = mapper;
            }

            public async Task<IDataResult<List<CourseViewModel>>> Handle(GetAllCourseQuery request, CancellationToken cancellationToken)
            {
                var courses = await _courseService.GetAllAsync();
                
                var viewModel =_mapper.Map<List<CourseViewModel>>(courses.Data);

                return new SuccessDataResult<List<CourseViewModel>>(viewModel);
            }
        }
    }
}
