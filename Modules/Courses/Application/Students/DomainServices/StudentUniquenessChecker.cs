using ContosoUniversity.Modules.Courses.Domain.Students;
using ContosoUniversity.Modules.Courses.Domain.Students.Services;
using ContosoUniversity.Modules.Courses.Domain.Students.Specifications;

namespace ContosoUniversity.Modules.Courses.Application.Students.DomainServices
{
    public class StudentUniquenessChecker : IStudentUniquenessChecker
    {
        private readonly IStudentRepository _studentRepository;
        public StudentUniquenessChecker(IStudentRepository studentRepository) => _studentRepository = studentRepository;
        public bool Exist(string firstName, string lastName)
        {
            var student = _studentRepository.Find(StudentSpecification.FirstAndLastName(firstName, lastName));
            if (student != null)
            {
                return true;
            }
            return false;
        }
    }
}
