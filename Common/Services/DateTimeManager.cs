using System;

namespace Common.Services
{
    public class DateTimeManager : IDateTimeManager
    {
        public DateTime Now { get => DateTime.Now; }

        public DateTime UtcNow { get => DateTime.UtcNow; }
    }
}
