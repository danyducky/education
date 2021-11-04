using System;

namespace Auth.DataLayer.Enums
{
    public struct Modules
    {
        public static readonly Guid Student = Guid.Parse(STUDENT);
        public static readonly Guid Teacher = Guid.Parse(TEACHER);
        public static readonly Guid Administrative = Guid.Parse(ADMINISTRATIVE);

        public static readonly string STUDENT = "";
        public static readonly string TEACHER = "";
        public static readonly string ADMINISTRATIVE = "";
    }
}
