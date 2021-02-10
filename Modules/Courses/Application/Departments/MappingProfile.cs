using AutoMapper;
using ContosoUniversity.Modules.Courses.Application.Departments.GetDepartmentDetails;
using ContosoUniversity.Modules.Courses.Domain.Departments;

namespace ContosoUniversity.Modules.Courses.Application.Departments
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Department, DepartmentDto>()
                .ForMember(d => d.Id, o => o.MapFrom(src => src.Id.Value))
                .ForMember(d => d.Administrator, o => o.MapFrom(src => src.Administrator.PersonName.Full))
                .ForMember(d => d.Budget, o => o.MapFrom(src => src.Budget.Value))
                .ForMember(d => d.Currency, o => o.MapFrom(src => src.Budget.Currency));
        }
    }
}
