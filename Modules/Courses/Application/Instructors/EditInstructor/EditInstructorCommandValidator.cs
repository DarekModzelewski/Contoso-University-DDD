using FluentValidation;
using System;

namespace ContosoUniversity.Modules.Courses.Application.Instructors.EditInstructor
{
    public class EditInstructorCommandValidator : AbstractValidator<EditInstructorCommand>
    {
        public EditInstructorCommandValidator()
        {
            RuleFor(c => c.FirstName).NotNull().NotEmpty()
                .WithMessage("First Name cannot be null or empty.");

            RuleFor(c => c.LastName).NotNull().NotEmpty()
                .WithMessage("Last Name cannot be null or empty.");

            RuleFor(c => c.HireDate).Cascade(CascadeMode.Stop).NotEmpty()
                    .Must(date => date != default(DateTime))
                    .WithMessage("Hire date is required");

            RuleFor(c => c.Address).NotNull().NotEmpty()
               .WithMessage("Address cannot be null or empty.");

            RuleFor(c => c.PostalCode).NotNull().NotEmpty()
               .WithMessage("Postal code cannot be null or empty.");

            RuleFor(c => c.City).NotNull().NotEmpty()
               .WithMessage("City cannot be null or empty.");


        }
    }
}