using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PM.MODEL.Models.UserMaster.UserMasterDTO
{
    public class UserMasterDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
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
