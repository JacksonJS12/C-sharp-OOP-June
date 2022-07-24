namespace SoftUniLogger
{
    using System.Collections.Generic;
    public static class Extensions
    {
        public static void AddRange<T>(this ICollection<T> appenders, IEnumerable<T> appendersToAdd)
        {
            foreach (T apToAdd in appendersToAdd)
            {
                appenders.Add(apToAdd);
            }
        }
        public static IReadOnlyCollection<IAppender> AsReadOnly(this ICollection<IAppender> appenders)
        => (IReadOnlyCollection<IAppender>)appenders;
    }
}
