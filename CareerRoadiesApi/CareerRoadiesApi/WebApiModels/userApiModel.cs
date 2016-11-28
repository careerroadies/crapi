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
}