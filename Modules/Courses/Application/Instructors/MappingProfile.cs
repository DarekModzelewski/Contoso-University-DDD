using AutoMapper;
using ContosoUniversity.Modules.Courses.Application.Instructors.GetInstructorDetails;
using ContosoUniversity.Modules.Courses.Domain.Instructors;
using System.Linq;

namespace ContosoUniversity.Modules.Courses.Application.Instructors
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Instructor, InstructorDto>()
                .ForMember(d => d.Id, o => o.MapFrom(src => src.Id.Value))
                .ForMember(d => d.FirstName, o => o.MapFrom(src => src.PersonName.First))
                .ForMember(d => d.LastName, o => o.MapFrom(src => src.PersonName.Last))
                .ForMember(d => d.Courses, opt => opt.MapFrom(src => src.Assignments.Select(a => a.Course).ToList()));
        }
    }
}
