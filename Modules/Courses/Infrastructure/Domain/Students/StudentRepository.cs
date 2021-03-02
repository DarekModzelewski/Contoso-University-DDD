using System.Linq;
using System.Threading.Tasks;
using ContosoUniversity.Modules.Courses.Domain.Students;
using ContosoUniversity.SharedKernel.Domain;
using ContosoUniversity.SharedKernel.Infrastructure;
using LinqBuilder;
using Microsoft.EntityFrameworkCore;

namespace ContosoUniversity.Modules.Courses.Infrastructure.Domain.Students
{
    internal class StudentRepository : IStudentRepository
    {
        private readonly CoursesContext _coursesContext;

        internal StudentRepository(CoursesContext coursesContext)
        {
            _coursesContext = coursesContext;
        }
        public async Task AddAsync(Student student)
        {
            await _coursesContext.Students.AddAsync(student);
        }
        public Student Find(ISpecification<Student> specification)
        {
            return _coursesContext.Students.ExeSpec(specification).FirstOrDefault();
        }
        public async Task<Student> FindAsync(ISpecification<Student> specification)
        {
            return await _coursesContext.Students
                .Include(s => s.Enrollments)
                .ThenInclude(e => e.Course)
                .ExeSpec(specification)
                .FirstOrDefaultAsync();
        }
        public async Task<Student> GetByIdAsync(StudentId studentId)
        {
            return await _coursesContext.Students
                .Include(s => s.Enrollments)
                .ThenInclude(e => e.Course)
                .FirstOrDefaultAsync(x => x.Id == studentId);
        }
        public async Task<IPagedList<Student>> GetAsync(int? pageNumber = null, int? pageSize = null)
        {
            return await _coursesContext.Students
                .AsNoTracking()
                .ToPagedListAsync(pageNumber?? 1, pageSize ?? int.MaxValue);
        }
        public async Task<IPagedList<Student>> GetAsync(ISpecification<Student> specification, int? pageNumber = null, int? pageSize = null)
        {
            return await _coursesContext.Students
                .AsNoTracking()
                .ExeSpec(specification)
                .ToPagedListAsync(pageNumber ?? 1,pageSize ?? int.MaxValue);                                   
        }

        
    }


}