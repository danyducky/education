using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Common.Validation
{
    public class EmailRegexAttribute : ValidationAttribute
    {
        private readonly Regex emailRegex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

        public override bool IsValid(object value)
        {
            if (value == null)
                return false;

            return emailRegex.Match(value as string).Success;
        }
    }
}
