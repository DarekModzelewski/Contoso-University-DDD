using ContosoUniversity.Modules.Courses.Application.Contracts;
using MediatR;
using System;

namespace ContosoUniversity.Modules.Courses.Application.Departments.CreateDepartment
{
    public class CreateDepartmentCommand : CommandBase<Unit>
    {
        public string Name { get; }
        public decimal Budget { get; }
        public string Currency { get; }
        public DateTime StartDate { get; }

        public CreateDepartmentCommand(string name, decimal budget,string currency, DateTime startDate)
        {
            Name = name;
            Budget = budget;
            Currency = currency;
            StartDate = startDate;
        }
    }
   
}
