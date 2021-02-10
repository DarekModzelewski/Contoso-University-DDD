using LinqBuilder;
using LinqBuilder.OrderBy;
using System;
using System.Linq;

namespace ContosoUniversity.Modules.Courses.Domain.Students.Specifications
{
    public class StudentSpecification : Specification<Student>
    {
        public static ISpecification<Student> FirstOrLastName(string searchString,string sortOrder)
        {
            ISpecification<Student> orderSpecification;

            switch (sortOrder)
            {
                case "name_desc":
                    orderSpecification = OrderSpec<Student, string>.New(s => s.PersonName.Last, Sort.Descending);
                    break;
                case "Date":
                    orderSpecification = OrderSpec<Student, DateTime>.New(s => s.EnrollmentDate, Sort.Ascending);
                    break;
                case "date_desc":
                    orderSpecification = OrderSpec<Student, DateTime>.New(s => s.EnrollmentDate, Sort.Descending);
                    break;
                default:
                    orderSpecification = OrderSpec<Student, string>.New(s => s.PersonName.Last, Sort.Ascending);
                    break;
            }

            if (!String.IsNullOrEmpty(searchString))
            {
                return Spec<Student>
                    .New(s => s.PersonName.First.Contains(searchString) || s.PersonName.Last.Contains(searchString))
                    .OrderBy((IOrderSpecification<Student>)orderSpecification);
            }
            return orderSpecification;
  
        }
        public static ISpecification<Student> FirstAndLastName(string firstName, string lastName)
        {
            return Spec<Student>
                    .New(s => s.PersonName.First.Contains(firstName) && s.PersonName.Last.Contains(lastName));
        }
    }
    
}
