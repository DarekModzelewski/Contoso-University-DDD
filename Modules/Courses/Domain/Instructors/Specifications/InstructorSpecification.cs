using LinqBuilder;

namespace ContosoUniversity.Modules.Courses.Domain.Instructors.Specifications
{
    public class InstructorSpecification : Specification<Instructor>
    {      
        public static ISpecification<Instructor> FirstAndLastName(string firstName, string lastName)
        {
            return Spec<Instructor>
                    .New(i => i.PersonName.First.Contains(firstName) && i.PersonName.Last.Contains(lastName));
        }
    }
    
}
