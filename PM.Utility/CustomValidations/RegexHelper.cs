using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM.Utility.CustomValidations
{
    public static class RegexHelper
    {
        public const string REGEX_NAME = "^[a-zA-Z']+$";
        public const string REGEX_MOBILE_NUMBER = @"^[0-9]{10}$";
        public const string REGEX_COUNTRY_CODE = @"^\+[0-9]{1,5}$";
    }
}
