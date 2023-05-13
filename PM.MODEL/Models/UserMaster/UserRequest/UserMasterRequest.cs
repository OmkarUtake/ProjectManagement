using PM.Utility.CustomValidations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM.MODEL.Models.UserMaster
{
    public class UserMasterRequest
    {
        public int Id { get; set; }

        [RegularExpression(RegexHelper.REGEX_NAME, ErrorMessage = "Invalid Name. ")]
        public string Name { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email Id")]
        public string Email { get; set; }

        [RegularExpression(RegexHelper.REGEX_MOBILE_NUMBER, ErrorMessage = "Invalid Mobile No. ")]
        public string MobileNo { get; set; }

        [RegularExpression(RegexHelper.REGEX_COUNTRY_CODE, ErrorMessage = "Invalid Country Code. ")]
        public string CountryCode { get; set; }
        public string EmployeeId { get; set; }
        public DateTime DOB { get; set; }
        public DateTime DOJ { get; set; }
        public string AddressLine1 { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
    }
}
