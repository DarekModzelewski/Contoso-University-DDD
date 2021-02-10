using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ContosoUniversity.Modules.Courses.Application.Configuration.Queries;
using ContosoUniversity.Modules.Courses.Domain.Instructors;

namespace ContosoUniversity.Modules.Courses.Application.Instructors.GetInstructorDetails
{
    internal class GetInstructorDetailsQueryHandler : IQueryHandler<GetInstructorDetailsQuery, InstructorDto>
    {
        private readonly IInstructorRepository _instructorRepository;
        private readonly IMapper _mapper;

        internal GetInstructorDetailsQueryHandler(IInstructorRepository instructorRepository, IMapper mapper)
        {
            _instructorRepository = instructorRepository;
            _mapper = mapper;
        }

        public async Task<InstructorDto> Handle(GetInstructorDetailsQuery query, CancellationToken cancellationToken)
        {
            var Instructor = await _instructorRepository.GetByIdAsync(new InstructorId(query.InstructorId));
            return _mapper.Map<InstructorDto>(Instructor);          
        }

    }
}