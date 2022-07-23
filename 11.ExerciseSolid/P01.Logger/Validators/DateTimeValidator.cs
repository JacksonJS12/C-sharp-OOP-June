namespace SoftUniLogger
{
    using System;
    internal class DateTimeValidator : IValidator
    {
        public bool IsValid(object value)
            => DateTime.TryParse((string)value, out DateTime date);
    }
}
