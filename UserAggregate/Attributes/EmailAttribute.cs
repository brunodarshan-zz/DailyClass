using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace DailyClass.UserAggregate.Attributes
{
    public class EmailAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            Regex emailRgx = new Regex( @"\w+@\w+.\w{2,3}.\w{2,3}");
            if (emailRgx.Matches((string)value).Count == 1)
                return true;

            return false;
        }
    }
}