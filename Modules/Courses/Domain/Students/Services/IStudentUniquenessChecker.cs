namespace ContosoUniversity.Modules.Courses.Domain.Students.Services
{
    public interface IStudentUniquenessChecker
    {
        bool Exist(string firstName, string lastName );
    }
}
