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
    public class GetByIdInstructorQuery : IRequest<IDataResult<InstructorViewModel>>
    {
        public int Id { get; set; }

        public class GetByIdInstructorQueryHandler : IRequestHandler<GetByIdInstructorQuery, IDataResult<InstructorViewModel>>
        {
            private readonly IInstructorService _instructorService;
            private readonly IMapper _mapper;

            public GetByIdInstructorQueryHandler(IInstructorService instructorService, IMapper mapper)
            {
                _instructorService = instructorService;
                _mapper = mapper;
            }

            public async Task<IDataResult<InstructorViewModel>> Handle(GetByIdInstructorQuery request, CancellationToken cancellationToken)
            {
                var instructor = await _instructorService.GetByIdAsync(request.Id);

                var viewModel = _mapper.Map<InstructorViewModel>(instructor.Data);

                return new SuccessDataResult<InstructorViewModel>(viewModel);
            }
        }
    }
}
