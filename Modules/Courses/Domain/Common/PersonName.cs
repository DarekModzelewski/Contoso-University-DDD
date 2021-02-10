using ContosoUniversity.SharedKernel.Domain;


namespace ContosoUniversity.Modules.Courses.Domain.Common
{
    public class PersonName : ValueObject
    {
        public string First { get; }
        public string Last { get; }
        public string Full { get; }
        public string Reversed { get; }

        public PersonName(string first, string last)
        {
            First = first;
            Last = last;
            Full = First + " " + Last;
            Reversed = Last + " " + First;
        }

        public static PersonName CreateNew(string first, string last) 
        {
            if (string.IsNullOrEmpty(first) && string.IsNullOrEmpty(last))
            {
                // tbd validatee
            }
            return new PersonName(first, last);
        }
    }
}
