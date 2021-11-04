using System;

namespace Auth.DataLayer.Enums
{
    public struct Roles
    {
        public static readonly Guid User = Guid.Parse(USER);
        public static readonly Guid Administrator = Guid.Parse(ADMINISTRATOR);
        public static readonly Guid Student = Guid.Parse(STUDENT);
        public static readonly Guid Methodist = Guid.Parse(METHODIST);
        public static readonly Guid Teacher = Guid.Parse(TEACHER);


        public const string USER = "c747026e-cf5f-45ce-b9cb-6fbc28c932f8";
        public const string ADMINISTRATOR = "134bb2bd-c47e-4784-8fc0-57b615e91b10";
        public const string STUDENT = "da8768d4-d284-4349-a440-2bcd439cd0ca";
        public const string METHODIST = "f60e1182-5fba-4c21-b759-7e9162cc89e8";
        public const string TEACHER = "7ff227cc-9a69-4582-9654-3d1d3e92a1dc";
    }
}
