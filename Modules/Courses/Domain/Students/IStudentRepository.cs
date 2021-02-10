using LinqBuilder;
using System.Threading.Tasks;
using ContosoUniversity.SharedKernel.Domain;

namespace ContosoUniversity.Modules.Courses.Domain.Students
{
    public interface IStudentRepository 
    {
        Task AddAsync(Student student);
        Task<Student> GetByIdAsync(StudentId studentId);
        Student Find(ISpecification<Student> specification);
        Task<Student> FindAsync(ISpecification<Student> specification);
        Task<IPagedList<Student>> GetAsync(int? pageNumber = null, int? pageSize = null);
        Task<IPagedList<Student>> GetAsync(ISpecification<Student> specification,int? pageNumber = null,int? pageSize = null);           
    }
}