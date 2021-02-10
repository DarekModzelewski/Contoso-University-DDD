using ContosoUniversity.SharedKernel.Domain;
using System;
using System.Collections.Generic;
using ContosoUniversity.Modules.Courses.Domain.Instructors.Events;
using ContosoUniversity.Modules.Courses.Domain.Common;
using ContosoUniversity.Modules.Courses.Domain.Departments;
using ContosoUniversity.Modules.Courses.Domain.Instructors.Services;
using ContosoUniversity.Modules.Courses.Domain.Instructors.Rules;

namespace ContosoUniversity.Modules.Courses.Domain.Instructors
{
    public class Instructor : Entity, IAggregateRoot
    {
        public InstructorId Id { get; private set; }
        private PersonName _personName;
        private DateTime _hireDate;
        private OfficeLocation _officeLocation;
        private List<Assignment> _assignments;
        private int _version;
        private DateTime? _modificationDate;
        private bool _isDeleted;

        public PersonName PersonName => _personName;
        public DateTime HireDate => _hireDate;
        public OfficeLocation OfficeLocation => _officeLocation;
        public IReadOnlyCollection<Assignment> Assignments => _assignments;

        private Instructor()
        {
            _assignments = new List<Assignment>();
        }

        private Instructor(string firstName,string lastName,DateTime hireDate)
        {
            Id = new InstructorId(Guid.NewGuid());
            _personName = PersonName.CreateNew(firstName,lastName);     
            _hireDate = hireDate;
            _assignments = new List<Assignment>();

            AddDomainEvent(new InstructorCreatedDomainEvent(Id));

        }

        public static Instructor Create(
            string firstName,
            string lastName,
            DateTime hireDate,
            IInstructorUniquenessChecker instructorUniquenessChecker)
        {
            CheckRule(new InstructorMustBeUniqueRule(firstName, lastName, instructorUniquenessChecker));
            return new Instructor(firstName, lastName,hireDate);
        }
       
        public void Edit(string firstName, string lastName,string address,string postalCode,string city)
        {
            _personName = PersonName.CreateNew(firstName, lastName);
            _officeLocation = OfficeLocation.CreateNew(address, postalCode, city);
            AddDomainEvent(new InstructorEditedDomainEvent(
                Id,
                _personName.First,
                _personName.Last,
                _officeLocation.Address,
                _officeLocation.PostalCode,
                _officeLocation.City));
        }
        public void AssignToOffice(string address, string postalCode, string city)
        {
            _officeLocation = OfficeLocation.CreateNew(address,postalCode,city);
            AddDomainEvent(new InstructorAssignedToOfficeDomainEvent(Id,_officeLocation.Address,_officeLocation.PostalCode,_officeLocation.City));
        }
        public void AssignToCourse(CourseId courseId)
        {
            CheckRule(new CannotAssignInstructorToTheSameCourseTwiceRule(Id,courseId, _assignments));
            _assignments.Add(Assignment.CreateNew(Id, courseId));
        }
        public void IncreaseVersion()
        {
            _version++;
            _modificationDate = SystemClock.Now;
        }
        public void SoftDelete()
        {
            _isDeleted = true;
            foreach (var assignment in _assignments)
            {
                assignment.SoftDelete();
            }
        }

    }
}
