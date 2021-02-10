using ContosoUniversity.SharedKernel.Domain;
using System;
using ContosoUniversity.Modules.Courses.Domain.Common;
using System.Collections.Generic;
using ContosoUniversity.Modules.Courses.Domain.Students;
using ContosoUniversity.Modules.Courses.Domain.Instructors;
using ContosoUniversity.Modules.Courses.Domain.Departments.Events;

namespace ContosoUniversity.Modules.Courses.Domain.Departments
{
    public class Course : Entity
    {
        public CourseId Id { get; private set; }
        private DepartmentId _departmentId;
        private Department _department;
        private string _title;
        private int _credits;
        private int _version;
        private DateTime? _modificationDate;
        private List<Enrollment> _studentEnrollments;
        private List<Assignment> _instructorAssignments;
        private bool _isDeleted;

        public string Title => _title;
        public int Credits => _credits;
        public Department Department => _department;
        public IReadOnlyCollection<Enrollment> StudentEnrollments => _studentEnrollments;
        public IReadOnlyCollection<Assignment> InstructorAssignments => _instructorAssignments;

        private Course()
        {
            _studentEnrollments = new List<Enrollment>();
            _instructorAssignments = new List<Assignment>();
        }

        private Course(DepartmentId departmentid,string title,int credits)
        {
            Id = new CourseId(Guid.NewGuid());
            _departmentId = departmentid;
            _title = title;
            _credits = credits;
            _studentEnrollments = new List<Enrollment>();
            _instructorAssignments = new List<Assignment>();

            AddDomainEvent(new CourseAddedDomainEvent(Id));
            
        }
        internal static Course CreateNew(DepartmentId departmentId, string title, int credits)
        {
            return new Course(departmentId, title, credits);
        }
        internal void Edit(string title, int credits)
        {
            _title = title;
            _credits = credits;
        }
        internal void IncreaseVersion()
        {
            _version++;
            _modificationDate = SystemClock.Now;
        }
        internal void SoftDelete()
        {
            _isDeleted = true;
        }

    }
}

