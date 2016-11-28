using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataserviceInterface;
using DataModels;

namespace ApplicationService
{
    public class UserBusinessRules : ValidationRules
    {
        IuserService userdataservice;

        public void InitializeUserBusinessRules(user user, IuserService dataService)
        {
            userdataservice = dataService;
            InitializeValidationRules(user);
        }

        public void ValidateUser(user user, IuserService userService)
        {
            userdataservice = userService;
            InitializeValidationRules(user);
            ValidateRequired("email", "E mail");
            ValidateEmailAddress("email", "Email Address");
            //  ValidateRequired("mobilenumber", "mobile number"); // TO DO
            ValidateRequired("password", "password");

            ValidateUniqueUserName(user.username, user.usertypeid);
        }

        public void ValidateUniqueUserName(string userName, int usertypeid)
        {

            if (!string.IsNullOrEmpty(userName))
            {
                bool isExist = userdataservice.GetUserByUserName(userName, usertypeid);
                if (isExist)
                {
                    AddValidationError("UserName", "User Name " + userName + " already exists.");
                }
            }

        }
    }
}
