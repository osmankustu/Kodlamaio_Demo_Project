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

namespace KodlamaIo.Business.Features.Commands.CourseCategoryCommand
{
    public class CreateCourseCategoryCommand : IRequest<IResult>
    {
        public string Name { get; set; }

        public class CreateCourseCategoryCommandHandler : IRequestHandler<CreateCourseCategoryCommand, IResult>
        {
            private readonly ICourseCategoryService _courseCategoryService;
            private readonly IMapper _mapper;

            public CreateCourseCategoryCommandHandler(ICourseCategoryService courseCategoryService, IMapper mapper)
            {
                _courseCategoryService = courseCategoryService;
                _mapper = mapper;
            }

            public async Task<IResult> Handle(CreateCourseCategoryCommand request, CancellationToken cancellationToken)
            {
                var courseCategory = _mapper.Map<CourseCategory>(request);

                return await _courseCategoryService.Add(courseCategory);
            }
        }
    }
}
