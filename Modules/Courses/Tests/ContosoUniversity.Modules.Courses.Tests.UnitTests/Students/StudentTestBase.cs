using ContosoUniversity.Modules.Courses.Domain.Students;
using ContosoUniversity.Modules.Courses.Domain.Students.Services;
using ContosoUniversity.Modules.Courses.Tests.Domain.UnitTests.Utils;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ContosoUniversity.Modules.Courses.Tests.Domain.UnitTests
{
    public class CoursesTestsBase : TestBase
    {
        protected class StudentTestDataOptions
        {
            internal StudentId StudentId { get; set; }
            internal string  FirstName { get; set; }
            internal string LastName { get; set; }
            internal IEnumerable<Enrollment> Enrollments { get; set; } = Enumerable.Empty<Enrollment>();
        }

        protected class StudentTestData
        {
            public StudentTestData(Student student)
            {
                Student = student;
            }

            internal Student Student { get; }
        }

        protected StudentTestData CreateStudentTestData(StudentTestDataOptions options)
        {
            var studentUniquenessChecker = Substitute.For<IStudentUniquenessChecker>();
            var student = Student.Create("John","Doe",DateTime.Now,studentUniquenessChecker);
            
            DomainEventsTestHelper.ClearAllDomainEvents(student);

            return new StudentTestData(student);
        }
    }
}
