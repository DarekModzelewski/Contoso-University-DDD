using ContosoUniversity.Modules.Courses.Domain.Instructors;
using ContosoUniversity.Modules.Courses.Domain.Instructors.Services;
using ContosoUniversity.Modules.Courses.Domain.Instructors.Specifications;

namespace ContosoUniversity.Modules.Courses.Application.DomainServices
{
    public class InstructorUniquenessChecker : IInstructorUniquenessChecker
    {
        private readonly IInstructorRepository _instructorRepository;
        public InstructorUniquenessChecker(IInstructorRepository instructorRepository) => _instructorRepository = instructorRepository;
        public bool Exist(string firstName, string lastName)
        {
            var instructor = _instructorRepository.Find(InstructorSpecification.FirstAndLastName(firstName, lastName));
            if (instructor != null)
            {
                return true;
            }
            return false;
        }
    }
}
