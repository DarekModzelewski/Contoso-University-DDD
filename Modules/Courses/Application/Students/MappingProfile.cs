using AutoMapper;
using ContosoUniversity.Modules.Courses.Application.Students.GetStudentDetails;
using ContosoUniversity.Modules.Courses.Domain.Students;

namespace ContosoUniversity.Modules.Courses.Application.Students
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Student, StudentDto>()
                .ForMember(d => d.Id, o => o.MapFrom(src => src.Id.Value))
                .ForMember(d => d.FirstName, o => o.MapFrom(src => src.PersonName.First))
                .ForMember(d => d.LastName, o => o.MapFrom(src => src.PersonName.Last));
            CreateMap<Enrollment, StudentDto.Enrollment>()
                .ForMember(d => d.Title, o => o.MapFrom(src => src.Course.Title))
                .ForMember(d => d.Grade, o => o.MapFrom(src => src.Grade.Value));


        }
    }
}
