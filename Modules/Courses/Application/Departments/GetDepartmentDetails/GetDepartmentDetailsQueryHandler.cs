using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ContosoUniversity.Modules.Courses.Application.Configuration.Queries;
using ContosoUniversity.Modules.Courses.Domain.Departments;

namespace ContosoUniversity.Modules.Courses.Application.Departments.GetDepartmentDetails
{
    internal class GetDepartmentDetailsQueryHandler : IQueryHandler<GetDepartmentDetailsQuery, DepartmentDto>
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;

        internal GetDepartmentDetailsQueryHandler(IDepartmentRepository departmentRepository, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }

        public async Task<DepartmentDto> Handle(GetDepartmentDetailsQuery query, CancellationToken cancellationToken)
        {
            var department = await _departmentRepository.GetByIdAsync(new DepartmentId(query.DepartmentId));
            return _mapper.Map<DepartmentDto>(department);          
        }

    }
}