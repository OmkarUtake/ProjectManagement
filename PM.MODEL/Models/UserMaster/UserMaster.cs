using PM.Utility.CustomValidations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM.MODEL
{
    public class UserMaster
    {
        public int Id { get; set; }

        [RegularExpression(RegexHelper.REGEX_NAME)]
        public string Name { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public string CountryCode { get; set; }
        public string EmployeeId { get; set; }
        public DateTime DOB { get; set; }
        public DateTime DOJ { get; set; }
        public bool IsActive { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string AddressLine1 { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

    }
}
