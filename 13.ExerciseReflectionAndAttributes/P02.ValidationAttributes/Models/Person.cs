using ValidationAttributes.Utilities.Attributes;

namespace ValidationAttributes.Models
{
    public class Person
    {
        private const int ageMinValue = 12;
        private const int ageMaxValue = 90;

        public Person(string fullName, int age)
        {
            FullName = fullName;
            Age = age;
        }

        [MyRequired]
        public string FullName { get; set; }
        [MyRange(ageMinValue, ageMaxValue)]
        public int Age { get; set; }
    }
}
