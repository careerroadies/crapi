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
    public class TutorProfileApplicationService
    {
        #region"----Initialize Interface----"
        ITutorProfileService _Tutorprofileservice;
        private ITutorProfileService tutorprofileservice
        {
            get { return _Tutorprofileservice; }
        }
        public TutorProfileApplicationService(ITutorProfileService tutorprofiledataservice)
        {
            _Tutorprofileservice = tutorprofiledataservice;
        }
        #endregion

        #region "---Profile Basic detail----"
        public string SaveTutorProfilesDetails(TutorProfiles _userprofile, out TransactionalInformation transaction)
        {
            var savestatus = "";
            transaction = new TransactionalInformation();
            try
            {
                ProfileBusinessRules profilebusinessrules = new ProfileBusinessRules();
                profilebusinessrules.ValidateTutorProfile(_userprofile, tutorprofileservice);
                if (profilebusinessrules.ValidationStatus == true)
                {
                    savestatus = tutorprofileservice.SaveTutorProfilesDetails(_userprofile);
                    transaction.ReturnStatus = true;
                    transaction.ReturnMessage.Add("Tutor Profile registered successfully.");
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
        public DataTable GetTutorProfilesDetails(string profileid)
        {
            DataTable DtProfile = tutorprofileservice.GetTutorProfilesDetails(profileid);
            return DtProfile;
        }
        #endregion
    }
}
