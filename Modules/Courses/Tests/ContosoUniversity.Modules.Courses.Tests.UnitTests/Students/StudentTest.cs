using ContosoUniversity.Modules.Courses.Domain.Students;
using ContosoUniversity.Modules.Courses.Domain.Students.Events;
using ContosoUniversity.Modules.Courses.Domain.Students.Services;
using ContosoUniversity.Modules.Courses.Tests.Domain.UnitTests.Utils;
using NSubstitute;
using NUnit.Framework;
using Shouldly;
using System;

namespace ContosoUniversity.Modules.Courses.Tests.Domain.UnitTests
{
    [TestFixture]
    public class StudentTests : TestBase
    {
     
        [Test]
        public void EditStudent_IsSuccessful()
        {
            //Arrange
            var studentUniquenessChecker = Substitute.For<IStudentUniquenessChecker>();
            var existingStudent = Student.Create("John", "Doe", DateTime.Now,studentUniquenessChecker);

            //Act
            existingStudent.Edit("Johny","Does",DateTime.Now);

            //Assert
            var studentEdited = AssertPublishedDomainEvent<StudentEditedDomainEvent>(existingStudent);
            studentEdited.FirstName.ShouldBe("Johny");
            studentEdited.LastName.ShouldBe("Does");
        }
        
    }
}
