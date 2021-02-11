using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ContosoUniversity.Modules.Courses.Application.Contracts;
using ContosoUniversity.Modules.Courses.Application.Students.GetStudentsByPage;
using ContosoUniversity.Modules.Courses.Application.Students.GetStudentDetails;
using ContosoUniversity.Modules.Courses.Application.Students.CreateStudent;
using System;
using ContosoUniversity.Modules.Courses.Application.Students.EditStudent;
using ContosoUniversity.Modules.Courses.Application.Students.DeleteStudent;

namespace ContosoUniversity.Web.Features.Courses.Students
{
    public class StudentsController : Controller
    {
        private readonly ICoursesModule _coursesModule;

        public StudentsController(ICoursesModule coursesModule) => _coursesModule = coursesModule;
        public async Task<IActionResult> Index(
            int? pageNumber,
            int? pageSize,
            string sortOrder,
            string currentFiler,
            string searchString)
        {
            var model = await _coursesModule.ExecuteQueryAsync(new GetStudentsByPageQuery(
                pageNumber,
                pageSize,
                sortOrder,
                currentFiler,
                searchString));

            return View(model);
        }


        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LastName", "FirstName", "EnrollmentDate")] CreateStudentRequest request)
        {
             if (!ModelState.IsValid) return View(request);

              await _coursesModule.ExecuteCommandAsync(new CreateStudentCommand(
              request.FirstName,
              request.LastName,
              request.EnrollmentDate));

            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id) => View(await _coursesModule.ExecuteQueryAsync(new GetStudentDetailsQuery(id)));

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("Id","LastName", "FirstName","EnrollmentDate")] EditStudentRequest request)
        {
            if (!ModelState.IsValid) return View(request);

            await _coursesModule.ExecuteCommandAsync(new EditStudentCommand(
            request.Id,
            request.FirstName,
            request.LastName,
            request.EnrollmentDate));

            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Details(Guid id) => View(await _coursesModule.ExecuteQueryAsync(new GetStudentDetailsQuery(id)));

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id) => View(await _coursesModule.ExecuteQueryAsync(new GetStudentDetailsQuery(id)));

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(DeleteStudentRequest request)
        {
            await _coursesModule.ExecuteCommandAsync(new DeleteStudentCommand(request.Id));
            return RedirectToAction("Index");
        }

       
    }
}
