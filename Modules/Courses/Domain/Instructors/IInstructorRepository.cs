using ContosoUniversity.SharedKernel.Domain;
using LinqBuilder;
using System.Threading.Tasks;

namespace ContosoUniversity.Modules.Courses.Domain.Instructors
{
    public interface IInstructorRepository 
    {
        Task AddAsync(Instructor instructor);
        Task<Instructor> GetByIdAsync(InstructorId instructorId);
        Instructor Find(ISpecification<Instructor> specification);
        Task<Instructor> FindAsync(ISpecification<Instructor> specification);
        Task<IPagedList<Instructor>> GetAsync(int? pageNumber = null, int? pageSize = null);
        Task<IPagedList<Instructor>> GetAsync(ISpecification<Instructor> specification, int? pageNumber = null, int? pageSize = null);
    }
}
