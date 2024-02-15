using AutoMapper;
using KodlamaIo.Business.Abstract;
using KodlamaIo.Business.DTOs.CourseCategoryDTOs;
using KodlamaIo.Core.Util.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIo.Business.Features.Queries.CourseCategoryQueries
{
    public class GetByIdCourseCategoryQuery : IRequest<IDataResult<CourseCategoryViewModel>>
    {
        public int Id { get; set; }

        public class GetByIdCourseCategoryQueryHandler : IRequestHandler<GetByIdCourseCategoryQuery, IDataResult<CourseCategoryViewModel>>
        {

            private readonly ICourseCategoryService _courseCategoryService;
            private readonly IMapper _mapper;

            public GetByIdCourseCategoryQueryHandler(ICourseCategoryService courseCategoryService, IMapper mapper)
            {
                _courseCategoryService = courseCategoryService;
                _mapper = mapper;
            }

            public async Task<IDataResult<CourseCategoryViewModel>> Handle(GetByIdCourseCategoryQuery request, CancellationToken cancellationToken)
            {
                var category = await _courseCategoryService.GetById(request.Id);

                var viewModel = _mapper.Map<CourseCategoryViewModel>(category.Data);

                return new SuccessDataResult<CourseCategoryViewModel>(viewModel);
            }
        }
    }
}
