using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataserviceInterface;
using DataModels;

namespace ApplicationService
{
    public class ProfileApplicationService
    {
        // Profile Class for saving profile details.
        IProfileService _profileservice;
        private IProfileService profileservice
        {
            get { return _profileservice; }
        }

        public ProfileApplicationService(IProfileService profiledataservice)
        {
            _profileservice = profiledataservice;
        }

        public string saveprofile(BasicProfileDetails _userprofile, out TransactionalInformation transaction)
        {
            var savestatus = "";
            transaction = new TransactionalInformation();
            try
            {
                ProfileBusinessRules profilebusinessrules = new ProfileBusinessRules();
                profilebusinessrules.ValidateProfile(_userprofile, profileservice);
                if (profilebusinessrules.ValidationStatus == true)
                {
                    savestatus = profileservice.SaveProfile(_userprofile);
                    transaction.ReturnStatus = true;
                    transaction.ReturnMessage.Add("Profile registered successfully.");
                }
                else
                {
                    transaction.ReturnStatus = profilebusinessrules.ValidationStatus;
                    transaction.ReturnMessage = profilebusinessrules.ValidationMessage;
                    transaction.ValidationErrors = profilebusinessrules.ValidationErrors;
                }
                

            }
            catch (Exception ex)
            {
                transaction.ReturnMessage = new List<string>();
                string errorMessage = ex.Message;
                transaction.ReturnStatus = false;
                transaction.ReturnMessage.Add(errorMessage);
            }
        
            
            return savestatus;
        }
    }
}
