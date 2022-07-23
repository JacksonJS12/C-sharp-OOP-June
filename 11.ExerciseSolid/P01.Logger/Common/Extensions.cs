namespace SoftUniLogger
{
    using System.Collections.Generic;
    public static class Extensions
    {
        public static void AddRange(this ICollection<IAppender> appenders, IEnumerable<IAppender> appendersToAdd)
        {
            foreach (IAppender apToAdd in appendersToAdd)
            {
                appenders.Add(apToAdd);
            }
        }
        public static IReadOnlyCollection<IAppender> AsReadOnly(this ICollection<IAppender> appenders)
        => (IReadOnlyCollection<IAppender>)appenders;
    }
}
