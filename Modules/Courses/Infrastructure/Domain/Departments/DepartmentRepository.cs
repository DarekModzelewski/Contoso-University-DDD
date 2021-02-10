using System.Linq;
using System.Threading.Tasks;
using ContosoUniversity.Modules.Courses.Domain.Departments;
using ContosoUniversity.SharedKernel.Domain;
using ContosoUniversity.SharedKernel.Infrastructure;
using LinqBuilder;
using Microsoft.EntityFrameworkCore;

namespace ContosoUniversity.Modules.Courses.Infrastructure.Domain.Departments
{
    internal class DepartmentRepository : IDepartmentRepository
    {
        private readonly CoursesContext _coursesContext;

        internal DepartmentRepository(CoursesContext coursesContext)
        {
            _coursesContext = coursesContext;
        }
        public async Task AddAsync(Department department)
        {
            await _coursesContext.Departments.AddAsync(department);
        }       
        public async Task<Department> FindAsync(ISpecification<Department> specification)
        {
            return await _coursesContext.Departments.ExeSpec(specification).FirstOrDefaultAsync();
        }
        public async Task<Department> GetByIdAsync(DepartmentId departmentId)
        {
            return await _coursesContext.Departments.FirstOrDefaultAsync(x => x.Id == departmentId);
        }
        public async Task<IPagedList<Department>> GetAsync(int? pageNumber = null, int? pageSize = null)
        {
            return await _coursesContext.Departments
                .AsNoTracking()
                .ToPagedListAsync(pageNumber ?? 1, pageSize ?? int.MaxValue);
        }
        public  async Task<IPagedList<Department>> GetAsync(ISpecification<Department> specification, int? pageNumber = null, int? pageSize = null)
        {
            return await _coursesContext.Departments
                .AsNoTracking()
                .ExeSpec(specification)
                .ToPagedListAsync(pageNumber ?? 1,pageSize ?? int.MaxValue);                                   
        }

       
    }


}