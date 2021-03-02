using AutoMapper;
using ContosoUniversity.Modules.Courses.Application.Configuration.Queries;
using ContosoUniversity.Modules.Courses.Application.Students.GetStudentDetails;
using ContosoUniversity.Modules.Courses.Domain.Students;
using ContosoUniversity.Modules.Courses.Domain.Students.Specifications;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ContosoUniversity.Modules.Courses.Application.Students.GetStudentsByPage
{
    internal class GetStudentsByPageQueryHandler : IQueryHandler<GetStudentsByPageQuery, PagedStudentsDto>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        internal GetStudentsByPageQueryHandler(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        public async Task<PagedStudentsDto> Handle(GetStudentsByPageQuery query, CancellationToken cancellationToken)
        {      
            var result = await _studentRepository.
                GetAsync(StudentSpecification.FirstOrLastName(query.SearchString,query.SortOrder),
                query.PageNumber ?? 1,query.PageSize ?? 3);

            return new PagedStudentsDto
            {
                ItemsPerPage = query.PageSize,
                HasNextPage = result.HasNextPage,
                HasPreviousPage = result.HasPreviousPage,
                TotalItems = result.TotalItemCount,
                CurrentSort = query.SortOrder,
                CurrentFilter = query.CurrentFilter,
                SearchString = query.SearchString,
                Students = _mapper.Map<IEnumerable<StudentDto>>(result),
                DateSortParm = query.SortOrder == "Date" ? "date_desc" : "Date",
                NameSortParm = String.IsNullOrEmpty(query.SortOrder) ? "name_desc" : "",
                PreviousPage = result.PreviousPageNumber,
                NextPage = result.NextPageNumber,
            };
           


        }

    }
}
