using FluentValidation;
using System;

namespace ContosoUniversity.Modules.Courses.Application.Departments.EditCourse
{
    public class EditCourseCommandValidator : AbstractValidator<EditCourseCommand>
    {
        public EditCourseCommandValidator()
        {
            RuleFor(c => c.Title).NotNull().NotEmpty()
                .WithMessage("Title cannot be null or empty.");

            RuleFor(c => c.Credits).GreaterThan(0)
               .WithMessage("Credits cannot be equal zero.");


        }
    }
}