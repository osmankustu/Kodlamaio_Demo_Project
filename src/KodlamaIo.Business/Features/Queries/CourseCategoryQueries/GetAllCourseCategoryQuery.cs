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
    public class GetAllCourseCategoryQuery : IRequest<IDataResult<List<CourseCategoryViewModel>>>
    {

        public class GetAllCourseCategoryQueryHandler : IRequestHandler<GetAllCourseCategoryQuery, IDataResult<List<CourseCategoryViewModel>>>
        {
            private readonly ICourseCategoryService _courseCategoryService;
            private readonly IMapper _mapper;

            public GetAllCourseCategoryQueryHandler(ICourseCategoryService courseCategoryService, IMapper mapper)
            {
                _courseCategoryService = courseCategoryService;
                _mapper = mapper;
            }

            public async Task<IDataResult<List<CourseCategoryViewModel>>> Handle(GetAllCourseCategoryQuery request, CancellationToken cancellationToken)
            {
                var categories = await _courseCategoryService.GetAll();

                var viewModel = _mapper.Map<List<CourseCategoryViewModel>>(categories.Data);

                return new SuccessDataResult<List<CourseCategoryViewModel>>(viewModel);
            }
        }
    }
}
