using AutoMapper;
using KodlamaIo.Business.Abstract;
using KodlamaIo.Core.Util.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIo.Business.Features.Commands.CourseCategoryCommand
{
    public class DeleteCourseCategoryCommand : IRequest<IResult>
    {
        public int Id { get; set; }

        public class DeleteCourseCategoryCommandHandler : IRequestHandler<DeleteCourseCategoryCommand, IResult>
        {
            private readonly ICourseCategoryService _courseCategoryService;
            private readonly IMapper _mapper;

            public DeleteCourseCategoryCommandHandler(ICourseCategoryService courseCategoryService, IMapper mapper)
            {
                _courseCategoryService = courseCategoryService;
                _mapper = mapper;
            }

            public async Task<IResult> Handle(DeleteCourseCategoryCommand request, CancellationToken cancellationToken)
            {
                var course = await _courseCategoryService.GetById(request.Id);

                return await _courseCategoryService.Delete(course.Data);
            }
        }
    }
}
