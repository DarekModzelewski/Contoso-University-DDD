using FluentValidation;

namespace ContosoUniversity.Modules.Courses.Application.Departments.AddCourse
{
    public class AddCourseCommandValidator : AbstractValidator<AddCourseCommand>
    {
        public AddCourseCommandValidator()
        {
            RuleFor(c => c.Title).NotNull().NotEmpty()
                .WithMessage("Title cannot be null or empty.");

            RuleFor(c => c.Credits).GreaterThan(0)
               .WithMessage("Credits cannot be equal zero.");

        }
    }
}