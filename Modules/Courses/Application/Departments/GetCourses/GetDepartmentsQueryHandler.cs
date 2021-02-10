using AutoMapper;
using ContosoUniversity.Modules.Courses.Application.Configuration.Queries;
using ContosoUniversity.Modules.Courses.Application.Departments.GetCourseDetails;
using ContosoUniversity.Modules.Courses.Domain.Departments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ContosoUniversity.Modules.Courses.Application.Departments.GetCourses
{
    internal class GetCoursesQueryHandler : IQueryHandler<GetCoursesQuery, IEnumerable<CourseDto>>
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;

        internal GetCoursesQueryHandler(IDepartmentRepository departmentRepository, IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CourseDto>> Handle(GetCoursesQuery query, CancellationToken cancellationToken)
        {
            var departments = await _departmentRepository.GetAsync();
            var courses = departments.SelectMany(d => d.Courses);
            return _mapper.Map<IEnumerable<CourseDto>>(courses); 
        }

    }
}
