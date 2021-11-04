using Common.Magic;
using System;

namespace Common.Services
{
    public interface IDateTimeManager
    {
        DateTime Now { get; }
        DateTime UtcNow { get; }
    }

    public static class DateTimeManagerExtensions
    {
        public static DateTime DateNow(this IHave<IDateTimeManager> context)
            => context.Entity.Now;

        public static DateTime DateUtcNow(this IHave<IDateTimeManager> context)
            => context.Entity.UtcNow;
    }
}
