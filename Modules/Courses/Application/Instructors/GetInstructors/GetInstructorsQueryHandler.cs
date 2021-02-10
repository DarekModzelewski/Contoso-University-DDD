using AutoMapper;
using ContosoUniversity.Modules.Courses.Application.Configuration.Queries;
using ContosoUniversity.Modules.Courses.Application.Instructors.GetInstructorDetails;
using ContosoUniversity.Modules.Courses.Domain.Instructors;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ContosoUniversity.Modules.Courses.Application.Instructors.GetInstructors
{
    internal class GetInstructorsQueryHandler : IQueryHandler<GetInstructorsQuery, IEnumerable<InstructorDto>>
    {
        private readonly IInstructorRepository _instructorRepository;
        private readonly IMapper _mapper;

        internal GetInstructorsQueryHandler(IInstructorRepository instructorRepository, IMapper mapper)
        {
            _instructorRepository = instructorRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<InstructorDto>> Handle(GetInstructorsQuery query, CancellationToken cancellationToken)
        {
            var instructors = await _instructorRepository.GetAsync();
            return _mapper.Map<IEnumerable<InstructorDto>>(instructors); 
        }

    }
}
