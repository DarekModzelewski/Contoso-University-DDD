using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ContosoUniversity.Modules.Courses.Application.Contracts;
using System;
using ContosoUniversity.Modules.Courses.Application.Departments.GetDepartments;
using ContosoUniversity.Modules.Courses.Application.Departments.CreateDepartment;
using ContosoUniversity.Modules.Courses.Application.Departments.GetDepartmentDetails;
using ContosoUniversity.Modules.Courses.Application.Departments.EditDepartment;
using ContosoUniversity.Modules.Courses.Application.Departments.DeleteDepartment;

namespace ContosoUniversity.Web.Features.Courses.Departments
{
    public class DepartmentsController : Controller
    {
        private readonly ICoursesModule _coursesModule;

        public DepartmentsController(ICoursesModule coursesModule) => _coursesModule = coursesModule;
        public async Task<IActionResult> Index() => View(await _coursesModule.ExecuteQueryAsync(new GetDepartmentsQuery()));

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name", "Budget","Currency", "StartDate")] CreateDepartmentRequest request)
        {
             if (!ModelState.IsValid) return View(request);

              await _coursesModule.ExecuteCommandAsync(new CreateDepartmentCommand(
              request.Name,
              request.Budget,
              request.Currency,
              request.StartDate));

            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id) => View(await _coursesModule.ExecuteQueryAsync(new GetDepartmentDetailsQuery(id)));

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([Bind("Id", "Name", "Budget", "Currency", "StartDate")] EditDepartmentRequest request)
        {
            if (!ModelState.IsValid) return View(request);

            await _coursesModule.ExecuteCommandAsync(new EditDepartmentCommand(
            request.Id,
            request.Name,
            request.Budget,
            request.Currency,
            request.StartDate));

            return RedirectToAction("Index");
        }
        [HttpGet]
        public async Task<IActionResult> Details(Guid id) => View(await _coursesModule.ExecuteQueryAsync(new GetDepartmentDetailsQuery(id)));

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id) => View(await _coursesModule.ExecuteQueryAsync(new GetDepartmentDetailsQuery(id)));

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(DeleteDepartmentRequest request)
        {
            await _coursesModule.ExecuteCommandAsync(new DeleteDepartmentCommand(request.Id));
            return RedirectToAction("Index");
        }

       
    }
}
