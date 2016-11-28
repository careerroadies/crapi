using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataserviceInterface;
using DataModels;
namespace ApplicationService
{
    public class UserApplicationService
    {
        IuserService _userservice;

        private IuserService userservice
        {
            get { return _userservice; }
        }

        public UserApplicationService(IuserService userdataservice)
        {
            _userservice = userdataservice;
        }

        public usersession saveuser(user user, out TransactionalInformation transaction)
        {
            usersession objuser = new usersession();
            transaction = new TransactionalInformation();
            try
            {
                UserBusinessRules userbusinessrules = new UserBusinessRules();
                userbusinessrules.ValidateUser(user, userservice);
                if (userbusinessrules.ValidationStatus == true)
                {
                    objuser = userservice.saveuser(user);
                    transaction.ReturnStatus = true;
                    transaction.ReturnMessage.Add("User registered successfully.");
                }
                else
                {
                    transaction.ReturnStatus = userbusinessrules.ValidationStatus;
                    transaction.ReturnMessage = userbusinessrules.ValidationMessage;
                    transaction.ValidationErrors = userbusinessrules.ValidationErrors;
                }
            }
            catch (Exception ex)
            {
                transaction.ReturnMessage = new List<string>();
                string errorMessage = ex.Message;
                transaction.ReturnStatus = false;
                transaction.ReturnMessage.Add(errorMessage);
            }

            return objuser;
        }

        public user Login(string username, string password, string typeid, out TransactionalInformation transaction)
        {
            user objreturn = new user();
            transaction = new TransactionalInformation();
            try
            {
                objreturn.username = username;
                objreturn.password = password;
                objreturn = userservice.Login(username, password, typeid);

                if (objreturn != null)
                {
                    transaction.ReturnStatus = true;
                }
                else
                {
                    transaction.ReturnStatus = false;
                    transaction.ReturnMessage.Add("Login invalid");
                }
            }
            catch (Exception ex)
            {
                transaction.ReturnMessage = new List<string>();
                string errorMessage = ex.Message;
                transaction.ReturnStatus = false;
                transaction.ReturnMessage.Add(errorMessage);
            }
            return objreturn;
        }
        
    }
}
