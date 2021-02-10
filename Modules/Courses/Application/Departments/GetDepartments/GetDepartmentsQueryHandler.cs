using AutoMapper;
using ContosoUniversity.Modules.Courses.Application.Configuration.Queries;
using ContosoUniversity.Modules.Courses.Application.Departments.GetDepartmentDetails;
using ContosoUniversity.Modules.Courses.Domain.Departments;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ContosoUniversity.Modules.Courses.Application.Departments.GetDepartments
{
    internal class GetDepartmentsQueryHandler : IQueryHandler<GetDepartmentsQuery, IEnumerable<DepartmentDto>>
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;

        internal GetDepartmentsQueryHandler(IDepartmentRepository departmentRepository, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DepartmentDto>> Handle(GetDepartmentsQuery query, CancellationToken cancellationToken)
        {
            var departments = await _departmentRepository.GetAsync();
            return _mapper.Map<IEnumerable<DepartmentDto>>(departments); 
        }

    }
}
