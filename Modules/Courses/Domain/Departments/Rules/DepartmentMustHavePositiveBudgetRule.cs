using ContosoUniversity.SharedKernel.Domain;

namespace ContosoUniversity.Modules.Courses.Domain.Departments.Rules
{
    internal class DepartmentMustHavePositiveBudgetRule :IDomainRule
    {
        private readonly MoneyValue _budget;

        internal DepartmentMustHavePositiveBudgetRule(MoneyValue budget)
        {
            _budget = budget;
        }

        public bool IsViolated() => _budget.Value <= 0;

        public string Message => "Department must have positive budget.";
    }
}
