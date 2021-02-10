using ContosoUniversity.Modules.Courses.Application.Contracts;
using MediatR;
using System;

namespace ContosoUniversity.Modules.Courses.Application.Departments.DeleteCourse
{
    public class DeleteCourseCommand : CommandBase<Unit>
    {
        public Guid CourseId { get; }

        public DeleteCourseCommand(Guid courseId) => CourseId = courseId;

    }
   
}
