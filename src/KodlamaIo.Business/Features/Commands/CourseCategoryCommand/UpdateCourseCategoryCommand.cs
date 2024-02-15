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
    public class UpdateCourseCategoryCommand : IRequest<IResult>
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public class UpdateCourseCategoryCommandHandler : IRequestHandler<UpdateCourseCategoryCommand, IResult>
        {
            private readonly ICourseCategoryService _courseCategoryService;
            private readonly IMapper _mapper;

            public UpdateCourseCategoryCommandHandler(ICourseCategoryService courseCategoryService, IMapper mapper)
            {
                _courseCategoryService = courseCategoryService;
                _mapper = mapper;
            }

            public async Task<IResult> Handle(UpdateCourseCategoryCommand request, CancellationToken cancellationToken)
            {
                var category = _mapper.Map<CourseCategory>(request);

                return await _courseCategoryService.Update(category);
            }
        }
    }
}
