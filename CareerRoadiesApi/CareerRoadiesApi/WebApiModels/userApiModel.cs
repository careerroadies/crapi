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
        public string password { get;set;}
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
}