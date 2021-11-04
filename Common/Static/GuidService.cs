using Common.Magic;
using System;

namespace Common.Static
{
    public static class GuidService
    {
        public static Guid NewGuid(this IAppRequestContext context) => Guid.NewGuid();
    }
}
