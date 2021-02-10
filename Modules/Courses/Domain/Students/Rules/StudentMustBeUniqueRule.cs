using ContosoUniversity.Modules.Courses.Domain.Students.Services;
using ContosoUniversity.SharedKernel.Domain;

namespace ContosoUniversity.Modules.Courses.Domain.Students.Rules
{
    internal class StudentMustBeUniqueRule : IDomainRule
    {
        private readonly string _firstName;
        private readonly string _lastName;
        private readonly IStudentUniquenessChecker _studentUniquenessChecker;

        public StudentMustBeUniqueRule(
            string firstName,
            string lastName,
            IStudentUniquenessChecker studentUniquenessChecker)
        {          
            _firstName = firstName;
            _lastName = lastName;
            _studentUniquenessChecker = studentUniquenessChecker;
        }

        public bool IsViolated() => _studentUniquenessChecker.Exist(_firstName,_lastName);
        public string Message => $"Student {_firstName} {_lastName} already exists.";
    }
}
