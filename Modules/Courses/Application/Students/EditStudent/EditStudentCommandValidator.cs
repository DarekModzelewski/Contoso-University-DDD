using FluentValidation;
using System;

namespace ContosoUniversity.Modules.Courses.Application.Students.EditStudent
{
    public class EditStudentCommandValidator : AbstractValidator<EditStudentCommand>
    {
        public EditStudentCommandValidator()
        {
            RuleFor(c => c.FirstName).NotNull().NotEmpty()
                .WithMessage("First Name cannot be null or empty.");

            RuleFor(c => c.LastName).NotNull().NotEmpty()
                .WithMessage("Last Name cannot be null or empty.");

            RuleFor(c => c.EnrollementDate).Cascade(CascadeMode.Stop).NotEmpty()
                   .Must(date => date != default(DateTime))
                   .WithMessage("Enrollment date is required");
        }
    }
}