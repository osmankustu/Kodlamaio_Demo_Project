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

namespace KodlamaIo.Business.Features.Commands.InstructorCommand
{
    public class CreateInstructorCommand : IRequest<IResult>
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public class CreateInstructorCommandHandler : IRequestHandler<CreateInstructorCommand, IResult>
        {
            private readonly IInstructorService _instructorService;
            private readonly IMapper _mapper;

            public CreateInstructorCommandHandler(IInstructorService instructorService, IMapper mapper)
            {
                _instructorService = instructorService;
                _mapper = mapper;
            }

            public async Task<IResult> Handle(CreateInstructorCommand request, CancellationToken cancellationToken)
            {
                var instructor = _mapper.Map<Instructor>(request);

                return await _instructorService.AddAsync(instructor);
            }
        }
    }
}
