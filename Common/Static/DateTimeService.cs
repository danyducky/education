using Common.Magic;
using System;

namespace Common.Static
{
    public static class DateTimeService
    {
        public static DateTime GetDateTimeNow(this IAppRequestContext context) => DateTime.Now;

        public static DateTime GetUtcDateTimeNow(this IAppRequestContext context) => DateTime.UtcNow;
    }
}
