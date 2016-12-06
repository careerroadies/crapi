using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels
{
    // This is profile class. which contains two more classes for save the basic details and address. test
    public class profile
    {

    }

    public class BasicProfileDetails
    {
       public string ProfileId { get; set; }
       public string UserId { get; set; }
       public string FirstName { get; set; }
       public string LastName { get; set; }
       public string Dob { get; set; }
       public string MobileNumber { get; set; }
       public string PrimaryEmail { get; set; }
       public string AlternateEmail { get; set; }
       public string Gender { get; set; }
       public string MaritalStatus { get; set; }
       public string ProfilePicture { get; set; }
       public string ProfileText { get; set; }
       public string Status { get; set; }
       public string stype { get; set; }
       public string city { get; set; }
       public string state { get; set; }
       public string location { get; set; }
    }

    public class profileAddressDetails
    {
        public string ProfileId { get; set; }
        public string Id { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string Landmark { get; set; }
        public string Locality { get; set; }
        public string Pincode { get; set; }
        public int CityID { get; set; }
        public int StateID { get; set; }
        public int AddressCategoryID { get; set; }
    }
}
