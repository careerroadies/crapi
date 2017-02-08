using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataModels;

namespace CareerRoadiesApi.WebApiModels
{
    public class userApiModel : TransactionalInformation
    {
        public user user;
        public userApiModel()
        {
            user = new user();
        }
    }
    public class UserDTO
    {
        public int user_id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string mobilenumber { get; set; }
        public int usertypeid { get; set; }
        public string refferalid { get; set; }
        public string ownrefferalid { get; set; }
    }

    public class LoginDTO
    {
        public string username { get; set; }
        public string password { get; set; }
        public string usertypeid { get; set; }
    }

    public class LocationSearchDTO
    {
        public string location { get; set; }
        public int city { get; set; }
        public int state { get; set; }
    }

    public class BasicProfileDetailsDTO
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

    public class AlertsDTO
    {
        public string alerttext { get; set; }
        public string alerttypeid { get; set; }
        public string added { get; set; }
        public string alertzoneid { get; set; }
        public string userid { get; set; }
        public string expiredate { get; set; }
        public string alertdescription { get; set; }
        public string AlternateEmail { get; set; }
    }

    public class AdsDTO
    {
        public string adsid { get; set; }
        public string adcategoryid { get; set; }
        public string adtitle { get; set; }
        public string addescription { get; set; }
        public string state { get; set; }
        public string city { get; set; }
        public string location { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string mobilenumber { get; set; }
        public string createdate { get; set; }
        public string createdby { get; set; }
        public string image { get; set; }
        public string active { get; set; }
    }
    public class profilepostgraduationDTO
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
    public class profilegraduationdetailsDTO
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
    public class profilehighersecondarydetailsDTO
    {
        public string profilehighersecondarydetailsid { get; set; }
        public string educationboardid { get; set; }
        public string medium { get; set; }
        public string profileid { get; set; }
        public string Year { get; set; }
        public string marks { get; set; }
    }
    public class profilesecondarydetailsDTO
    {
        public string profilesecondarydetailsid { get; set; }
        public string educationboardid { get; set; }
        public string Year { get; set; }
        public string medium { get; set; }
        public string marks { get; set; }
        public string profileid { get; set; }
    }
}