using ContosoUniversity.Modules.Courses.Application.Contracts;
using MediatR;
using System;

namespace ContosoUniversity.Modules.Courses.Application.Departments.AddCourse
{
    public class AddCourseCommand : CommandBase<Unit>
    {
        public Guid DepartmentId { get; }
        public string Title { get; }
        public int Credits { get; }
        public AddCourseCommand(Guid departmentId,string title,int credits)
        {
            DepartmentId = departmentId;
            Title = title;
            Credits = credits;
        }
    }
}
