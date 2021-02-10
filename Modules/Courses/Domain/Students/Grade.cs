using ContosoUniversity.SharedKernel.Domain;


namespace ContosoUniversity.Modules.Courses.Domain.Students
{
    public class Grade : ValueObject
    {
        public static Grade A => new Grade("A");
        public static Grade B => new Grade("B");
        public static Grade C => new Grade("C");
        public static Grade D => new Grade("D");
        public static Grade F => new Grade("F");

        public string Value { get; }

        public Grade(string value)
        {
            Value = value;
        }
    }
}
