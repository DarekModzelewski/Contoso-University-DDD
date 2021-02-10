using FluentValidation;
using System;

namespace ContosoUniversity.Modules.Courses.Application.Departments.CreateDepartment
{
    public class CreateDepartmentCommandValidator : AbstractValidator<CreateDepartmentCommand>
    {
        public CreateDepartmentCommandValidator()
        {
            RuleFor(c => c.Name).NotNull().NotEmpty()
                .WithMessage("Name cannot be null or empty.");

            RuleFor(c => c.Currency).NotNull().NotEmpty()
                .WithMessage("Currency cannot be null or empty.");

            RuleFor(c => c.Budget).GreaterThan(0)
               .WithMessage("Budget cannot be equal zero.");

            RuleFor(c => c.StartDate).Cascade(CascadeMode.Stop).NotEmpty()
                    .Must(date => date != default(DateTime))
                    .WithMessage("Start date is required");

        }
    }
}