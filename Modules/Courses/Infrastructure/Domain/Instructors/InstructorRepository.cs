using System.Linq;
using System.Threading.Tasks;
using ContosoUniversity.Modules.Courses.Domain.Instructors;
using ContosoUniversity.SharedKernel.Domain;
using ContosoUniversity.SharedKernel.Infrastructure;
using LinqBuilder;
using Microsoft.EntityFrameworkCore;

namespace ContosoUniversity.Modules.Courses.Infrastructure.Domain.Instructors
{
    internal class InstructorRepository : IInstructorRepository
    {
        private readonly CoursesContext _coursesContext;

        internal InstructorRepository(CoursesContext coursesContext)
        {
            _coursesContext = coursesContext;
        }
        public async Task AddAsync(Instructor instructor)
        {
            await _coursesContext.Instructors.AddAsync(instructor);
        }
        public Instructor Find(ISpecification<Instructor> specification)
        {
            return _coursesContext.Instructors.ExeSpec(specification).FirstOrDefault();
        }
        public async Task<Instructor> FindAsync(ISpecification<Instructor> specification)
        {
            return await _coursesContext.Instructors.ExeSpec(specification).FirstOrDefaultAsync();
        }
        public async Task<Instructor> GetByIdAsync(InstructorId instructorId)
        {
            return await _coursesContext.Instructors.FirstOrDefaultAsync(x => x.Id == instructorId);
        }
        public async Task<IPagedList<Instructor>> GetAsync(int? pageNumber = null, int? pageSize = null)
        {
            return await _coursesContext.Instructors
                .AsNoTracking()
                .ToPagedListAsync(pageNumber ?? 1, pageSize ?? int.MaxValue);
        }
        public  async Task<IPagedList<Instructor>> GetAsync(ISpecification<Instructor> specification, int? pageNumber = null, int? pageSize = null)
        {
            return await _coursesContext.Instructors
                .AsNoTracking()
                .ExeSpec(specification)
                .ToPagedListAsync(pageNumber ?? 1,pageSize ?? int.MaxValue);                                   
        }

       
    }


}