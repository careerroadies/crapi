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
        string ProfileId { get; set; }
        string UserId { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Dob { get; set; }
        string MobileNumber { get; set; }
        string PrimaryEmail { get; set; }
        string AlternateEmail { get; set; }
        string Gender { get; set; }
        string MaritalStatus { get; set; }
        string ProfilePicture { get; set; }
        string ProfileText { get; set; }    
    }

    public class profileAddressDetails
    {
        string ProfileId { get; set; }
        string Id { get; set; }
        string AddressLine1 { get; set; }
        string AddressLine2 { get; set; }
        string Landmark { get; set; }
        string Locality { get; set; }
        string Pincode { get; set; }
        int CityID { get; set; }
        int StateID { get; set; }
        int AddressCategoryID { get; set; }
    }
}
