using System;
using System.Collections.Generic;
using System.Linq;
using ContosoUniversity.Modules.Courses.Domain.Common;
using ContosoUniversity.Modules.Courses.Domain.Departments;
using ContosoUniversity.Modules.Courses.Domain.Students.Events;
using ContosoUniversity.Modules.Courses.Domain.Students.Rules;
using ContosoUniversity.Modules.Courses.Domain.Students.Services;
using ContosoUniversity.SharedKernel.Domain;

namespace ContosoUniversity.Modules.Courses.Domain.Students
{
    public class Student : Entity, IAggregateRoot
    {
        public StudentId Id { get; private set; }
        private PersonName _personName;
        private DateTime _enrollmentDate;
        private DateTime _createDate;
        private List<Enrollment> _enrollments;
        private int _version;
        private DateTime? _modificationDate;
        private bool _isDeleted;

        public PersonName PersonName => _personName;
        public DateTime EnrollmentDate => _enrollmentDate;
        public DateTime CreateDate => _createDate;
        public IReadOnlyCollection<Enrollment> Enrollments => _enrollments;
        private Student()
        {
            _enrollments = new List<Enrollment>();
        }

        private Student(string firstName, string lastName, DateTime enrollmentDate)
        {
            Id = new StudentId(Guid.NewGuid());
            _personName = new PersonName(firstName, lastName);
            _createDate = SystemClock.Now;
            _enrollmentDate = enrollmentDate;
            _enrollments = new List<Enrollment>();

            AddDomainEvent(new StudentCreatedDomainEvent(Id));
        }

        public static Student Create(
            string firstName,
            string lastName,
            DateTime enrollmentDate,
            IStudentUniquenessChecker studentUniquenessChecker)
        {
            CheckRule(new StudentMustBeUniqueRule(firstName, lastName, studentUniquenessChecker));
            return new Student(firstName, lastName,enrollmentDate);
        }
        public void Edit(string firstName, string lastName,DateTime enrollmentDate)
        {
            _personName = new PersonName(firstName, lastName);
            _enrollmentDate = enrollmentDate;
           
            AddDomainEvent(new StudentEditedDomainEvent(Id,_personName.First,_personName.Last,enrollmentDate));
            IncreaseVersion();
        }
        public void EnrollToCourse(CourseId courseId)
        {
            //TBD validate
            if (!_enrollments.Any(p => p.CourseId == courseId))
            {
                _enrollments.Add(Enrollment.CreateNew(Id, courseId));
            }                    
        }
        public void AddGrade(CourseId courseId,Grade grade)
        {
            //TBD validate
            var enrollment = _enrollments.SingleOrDefault(e => e.CourseId == courseId);
            if (enrollment != null)
            {
                enrollment.AddGrade(grade);
            }
        }
        public void SoftDelete()
        {
            _isDeleted = true;
            foreach (var enrollment in _enrollments)
            {
                enrollment.SoftDelete();
            }
        }
        private void IncreaseVersion()
        {
            _version++;
            _modificationDate = SystemClock.Now;
        }

    }
}