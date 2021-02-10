using FluentValidation;
using System;

namespace ContosoUniversity.Modules.Courses.Application.Students.CreateStudent
{
    public class CreateStudentCommandValidator : AbstractValidator<CreateStudentCommand>
    {
        public CreateStudentCommandValidator()
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