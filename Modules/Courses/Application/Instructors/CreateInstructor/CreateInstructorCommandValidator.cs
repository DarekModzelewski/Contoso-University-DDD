using FluentValidation;
using System;

namespace ContosoUniversity.Modules.Courses.Application.Instructors.CreateInstructor
{
    public class CreateInstructorCommandValidator : AbstractValidator<CreateInstructorCommand>
    {
        public CreateInstructorCommandValidator()
        {
            RuleFor(c => c.FirstName).NotNull().NotEmpty()
                .WithMessage("First Name cannot be null or empty.");

            RuleFor(c => c.LastName).NotNull().NotEmpty()
                .WithMessage("Last Name cannot be null or empty.");

            RuleFor(c => c.HireDate).Cascade(CascadeMode.Stop).NotEmpty()
                    .Must(date => date != default(DateTime))
                    .WithMessage("Hire date is required");

        }
    }
}