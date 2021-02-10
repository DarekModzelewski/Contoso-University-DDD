using System;
using System.Collections.Generic;
using ContosoUniversity.SharedKernel.Domain;
using ContosoUniversity.Modules.Courses.Domain.Departments.Events;
using ContosoUniversity.Modules.Courses.Domain.Departments.Rules;
using ContosoUniversity.Modules.Courses.Domain.Common;
using ContosoUniversity.Modules.Courses.Domain.Instructors;
using System.Linq;

namespace ContosoUniversity.Modules.Courses.Domain.Departments
{
    public class Department : Entity, IAggregateRoot
    {
        public DepartmentId Id { get; private set; }
        private Instructor _administrator;
        private InstructorId _administratorId;
        private string _name;
        private MoneyValue _budget;
        private DateTime _startDate;
        private List<Course> _courses;
        private int _version;
        private DateTime? _modificationDate;
        private bool _isDeleted;

        public Instructor Administrator => _administrator;
        public string Name => _name;
        public MoneyValue Budget => _budget;
        public DateTime StartDate => _startDate;
        public IReadOnlyCollection<Course> Courses => _courses;
      

        private Department()
        {
            _courses = new List<Course>();
        }
        private Department(string name, MoneyValue budget,DateTime startDate)
        {
            CheckRule(new DepartmentMustHavePositiveBudgetRule(budget));

            Id = new DepartmentId(Guid.NewGuid());
            _name = name;
            _budget = budget;
            _startDate = startDate;

            var departmentCreatedDomainEvent = new DepartmentCreatedDomainEvent(
                Id.Value,
                _name,
                _budget.Value,
                _budget.Currency,
                _budget.Moment,
                _startDate);

            AddDomainEvent(departmentCreatedDomainEvent);
        }
        public static Department Create(string name, decimal budget,string currency,DateTime startDate)
        {
            return new Department(name, MoneyValue.Of(budget,currency),startDate);
        }
        public void Edit(string name, decimal budget, string currency, DateTime startDate)
        {
            _name = name;
            _budget = MoneyValue.Of(budget, currency);
            _startDate = startDate;            
        }
        public void AssignAdministrator(InstructorId instructorId)
        {
            _administratorId = instructorId;
            AddDomainEvent(new AdministratorAssignedDomainEvent(Id,instructorId));
        }
        public void AddNewCourse(string title,int credits)
        {
            CheckRule(new CourseCannotBeAddedTwiceRule(_courses, title));
            _courses.Add(Course.CreateNew(Id, title, credits));
        }
        public void EditCourse(CourseId courseId,string title, int credits)
        {
            CheckRule(new CourseMustExistRule(_courses, courseId));
            _courses.SingleOrDefault(x => x.Id == courseId).Edit(title,credits);
        }
        public void DeleteCourse(CourseId courseId)
        {
            CheckRule(new CourseMustExistRule(_courses, courseId));
            _courses.SingleOrDefault(x => x.Id == courseId).SoftDelete();
        }
        public void IncreaseVersion()
        {
            _version++;
            _modificationDate = SystemClock.Now;
        }
        public void SoftDelete()
        {
            _isDeleted = true;
            foreach (var course in _courses)
            {
                course.SoftDelete();
            }
        }


    }
}
