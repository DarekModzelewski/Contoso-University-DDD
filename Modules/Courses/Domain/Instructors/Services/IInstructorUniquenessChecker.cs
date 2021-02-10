namespace ContosoUniversity.Modules.Courses.Domain.Instructors.Services
{
    public interface IInstructorUniquenessChecker
    {
        bool Exist(string firstName, string lastName );
    }
}
