using AutoMapper;
using KodlamaIo.Business.Abstract;
using KodlamaIo.Business.DTOs.InstructorDTOs;
using KodlamaIo.Core.Util.Result;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIo.Business.Features.Queries.InstructorQueries
{
    public class GetAllInstructorQuery  : IRequest<IDataResult<List<InstructorViewModel>>>
    {

        public class GetAllInstructorQueryHandler : IRequestHandler<GetAllInstructorQuery, IDataResult<List<InstructorViewModel>>>
        {
            private readonly IInstructorService _instructorService;
            private readonly IMapper _mappper;

            public GetAllInstructorQueryHandler(IInstructorService instructorService, IMapper mappper)
            {
                _instructorService = instructorService;
                _mappper = mappper;
            }

            public async Task<IDataResult<List<InstructorViewModel>>> Handle(GetAllInstructorQuery request, CancellationToken cancellationToken)
            {
                var instructors = await _instructorService.GetAllAsync();

                var viewModel = _mappper.Map<List<InstructorViewModel>>(instructors.Data);

                return new SuccessDataResult<List<InstructorViewModel>>(viewModel,instructors.Message);
            }
        }
    }
}
