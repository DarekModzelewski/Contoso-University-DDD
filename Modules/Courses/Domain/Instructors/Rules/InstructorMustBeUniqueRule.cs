using ContosoUniversity.Modules.Courses.Domain.Instructors.Services;
using ContosoUniversity.SharedKernel.Domain;

namespace ContosoUniversity.Modules.Courses.Domain.Instructors.Rules
{
    internal class InstructorMustBeUniqueRule : IDomainRule
    {
        private readonly string _firstName;
        private readonly string _lastName;
        private readonly IInstructorUniquenessChecker _instructorUniquenessChecker;

        public InstructorMustBeUniqueRule(
            string firstName,
            string lastName,
            IInstructorUniquenessChecker instructorUniquenessChecker)
        {          
            _firstName = firstName;
            _lastName = lastName;
            _instructorUniquenessChecker = instructorUniquenessChecker;
        }

        public bool IsViolated() => _instructorUniquenessChecker.Exist(_firstName,_lastName);
        public string Message => $"Instructor {_firstName} {_lastName} already exists.";
    }
}
