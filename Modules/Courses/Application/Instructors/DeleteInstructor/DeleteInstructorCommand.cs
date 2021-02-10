using ContosoUniversity.Modules.Courses.Application.Contracts;
using MediatR;
using System;

namespace ContosoUniversity.Modules.Courses.Application.Instructors.DeleteInstructor
{
    public class DeleteInstructorCommand : CommandBase<Unit>
    {
        public Guid InstructorId { get; }

        public DeleteInstructorCommand(Guid instructorId) => InstructorId = instructorId;

    }
   
}
