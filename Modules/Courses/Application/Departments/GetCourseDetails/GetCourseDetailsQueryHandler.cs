using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ContosoUniversity.Modules.Courses.Application.Configuration.Queries;
using ContosoUniversity.Modules.Courses.Domain.Departments;

namespace ContosoUniversity.Modules.Courses.Application.Departments.GetCourseDetails
{
    internal class GetCourseDetailsQueryHandler : IQueryHandler<GetCourseDetailsQuery, CourseDto>
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;

        internal GetCourseDetailsQueryHandler(IDepartmentRepository departmentRepository, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }

        public async Task<CourseDto> Handle(GetCourseDetailsQuery query, CancellationToken cancellationToken)
        {
            var department = await _departmentRepository.GetByIdAsync(new DepartmentId(query.DepartmentId));
            var course = department.Courses.SingleOrDefault(c => c.Id == new CourseId(query.CourseId));
            return _mapper.Map<CourseDto>(course);          
        }

    }
}