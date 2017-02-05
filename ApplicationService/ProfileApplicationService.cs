using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataserviceInterface;
using DataModels;
using System.Data;

namespace ApplicationService
{
    public class ProfileApplicationService
    {
        #region"----Initialize Interface----"
        IProfileService _profileservice;
        private IProfileService profileservice
        {
            get { return _profileservice; }
        }
        public ProfileApplicationService(IProfileService profiledataservice)
        {
            _profileservice = profiledataservice;
        }
        #endregion

        #region "---Profile Basic detail----"
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
        public DataTable GetProfile(string profileid)
        {
            DataTable DtProfile = profileservice.GetProfile(profileid);
            return DtProfile;
        }
        #endregion

        #region "---Profile Educationdetails-----"

        #region"---PostGraduation details-----"
        public string SavePostGraduationDetails(profilepostgraduation _profilepostgraduation, out TransactionalInformation transaction)
        {
            var savestatus = "";
            transaction = new TransactionalInformation();
            try
            {
                ProfileBusinessRules profilebusinessrules = new ProfileBusinessRules();
                profilebusinessrules.ValidatePostGraduationDetails(_profilepostgraduation, profileservice);
                if (profilebusinessrules.ValidationStatus == true)
                {
                    savestatus = profileservice.SavePostGraduationDetails(_profilepostgraduation);
                    transaction.ReturnStatus = true;
                    transaction.ReturnMessage.Add("Post Graduation Details registered successfully.");
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
        public DataTable GetPostGraduationDetails(string profileid)
        {
            DataTable DtProfile = profileservice.GetPostGraduationDetails(profileid);
            return DtProfile;
        }
        #endregion
        
        #region"---Graduation details-----"
        public string SaveGraduationDetails(profilegraduationdetails _profilegraduationdetails, out TransactionalInformation transaction)
        {
            var savestatus = "";
            transaction = new TransactionalInformation();
            try
            {
                ProfileBusinessRules profilebusinessrules = new ProfileBusinessRules();
                profilebusinessrules.ValidateGraduationDetails(_profilegraduationdetails, profileservice);
                if (profilebusinessrules.ValidationStatus == true)
                {
                    savestatus = profileservice.SaveGraduationDetails(_profilegraduationdetails);
                    transaction.ReturnStatus = true;
                    transaction.ReturnMessage.Add("Graduation Details registered successfully.");
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
        public DataTable GetGraduationDetails(string profileid)
        {
            DataTable DtProfile = profileservice.GetGraduationDetails(profileid);
            return DtProfile;
        }
        #endregion
        
        #region"---Higher Secondary details-----"
        public string SaveHigherSecondaryDetails(profilehighersecondarydetails _profilehighersecondarydetails, out TransactionalInformation transaction)
        {
            var savestatus = "";
            transaction = new TransactionalInformation();
            try
            {
                ProfileBusinessRules profilebusinessrules = new ProfileBusinessRules();
                profilebusinessrules.ValidateHigherSecondaryDetails(_profilehighersecondarydetails, profileservice);
                if (profilebusinessrules.ValidationStatus == true)
                {
                    savestatus = profileservice.SaveHigherSecondaryDetails(_profilehighersecondarydetails);
                    transaction.ReturnStatus = true;
                    transaction.ReturnMessage.Add("Higher Secondary Details registered successfully.");
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
        public DataTable GetHigherSecondaryDetails(string profileid)
        {
            DataTable DtProfile = profileservice.GetHigherSecondaryDetails(profileid);
            return DtProfile;
        }
        #endregion
        
        #region"---Secondary details-----"
        public string SaveSecondaryDetails(profilesecondarydetails _profilesecondarydetails, out TransactionalInformation transaction)
        {
            var savestatus = "";
            transaction = new TransactionalInformation();
            try
            {
                ProfileBusinessRules profilebusinessrules = new ProfileBusinessRules();
                profilebusinessrules.ValidateSecondaryDetails(_profilesecondarydetails, profileservice);
                if (profilebusinessrules.ValidationStatus == true)
                {
                    savestatus = profileservice.SaveSecondaryDetails(_profilesecondarydetails);
                    transaction.ReturnStatus = true;
                    transaction.ReturnMessage.Add("Secondary Details registered successfully.");
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
        public DataTable GetSecondaryDetails(string profileid)
        {
            DataTable DtProfile = profileservice.GetSecondaryDetails(profileid);
            return DtProfile;
        }
        #endregion
        #endregion
    }
}
