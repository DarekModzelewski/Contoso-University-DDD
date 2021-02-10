using ContosoUniversity.Modules.Courses.Application.Contracts;
using MediatR;
using System;

namespace ContosoUniversity.Modules.Courses.Application.Departments.EditCourse
{
    public class EditCourseCommand : CommandBase<Unit>
    {
        public Guid CourseId { get; }
        public string Title { get; }
        public int Credits { get; }

        public EditCourseCommand(Guid courseId, string title, int credits)
        {
            CourseId = courseId;
            Title = title;
            Credits = credits;
        }
    }
   
}
