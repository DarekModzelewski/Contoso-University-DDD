using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ContosoUniversity.Modules.Courses.Application.Configuration.Queries;
using ContosoUniversity.Modules.Courses.Domain.Students;

namespace ContosoUniversity.Modules.Courses.Application.Students.GetStudentDetails
{
    internal class GetStudentDetailsQueryHandler : IQueryHandler<GetStudentDetailsQuery, StudentDto>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        internal GetStudentDetailsQueryHandler(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        public async Task<StudentDto> Handle(GetStudentDetailsQuery query, CancellationToken cancellationToken)
        {
            var student = await _studentRepository.GetByIdAsync(new StudentId(query.StudentId));
            return _mapper.Map<StudentDto>(student);          
        }

    }
}