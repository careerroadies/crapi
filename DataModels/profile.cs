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

    public class profilepostgraduation
    {
        public string profilepostgraduationid { get; set; }
        public string profileid { get; set; }
        public string postgraduationid { get; set; }
        public string postgraduationtypeid { get; set; }
        public string specializationid { get; set; }
        public string UniversityorInstituteid { get; set; }
        public string Year { get; set; }
        public string gradingsystem { get; set; }
        public string marks { get; set; }
    }
    public class profilegraduationdetails
    {
        public string profilegraduationid { get; set; }
        public string profileid { get; set; }
        public string graduationid { get; set; }
        public string graduationtypeid { get; set; }
        public string specializationid { get; set; }
        public string UniversityorInstituteid { get; set; }
        public string Year { get; set; }
        public string grad { get; set; }
        public string marks { get; set; }
    }
    public class profilehighersecondarydetails
    {
        public string profilehighersecondarydetailsid { get; set; }
        public string educationboardid { get; set; }
        public string medium { get; set; }
        public string profileid { get; set; }
        public string Year { get; set; }
        public string marks { get; set; }
    }
    public class profilesecondarydetails
    {
        public string profilesecondarydetailsid { get; set; }
        public string educationboardid { get; set; }
        public string Year { get; set; }
        public string medium { get; set; }
        public string marks { get; set; }
        public string profileid { get; set; }
    }
    
    public class searchuser
    {
        public string profileid { get; set; }
        public string username { get; set; }
        public string dob { get; set; }
        public string mobilenumber { get; set; }
        public string profilepicture { get; set; }
        public string primaryemail { get; set; }
    }
}
