using ContosoUniversity.SharedKernel.Domain;
using LinqBuilder;
using System.Threading.Tasks;

namespace ContosoUniversity.Modules.Courses.Domain.Departments
{
    public interface IDepartmentRepository 
    {
        Task AddAsync(Department department);
        Task<Department> GetByIdAsync(DepartmentId departmentId);
        Task<Department> FindAsync(ISpecification<Department> specification);
        Task<IPagedList<Department>> GetAsync(int? pageNumber = null, int? pageSize = null);
        Task<IPagedList<Department>> GetAsync(ISpecification<Department> specification, int? pageNumber, int? pageSize);
       
    }
}