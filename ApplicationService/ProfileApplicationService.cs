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
        IProfileService _profileservice;
        private IProfileService profileservice
        {
            get { return _profileservice; }
        }

        public ProfileApplicationService(IProfileService profiledataservice)
        {
            _profileservice = profiledataservice;
        }

        public string saveprofile(userprofile _userprofile)
        {
            var savestatus = profileservice.SaveProfile(_userprofile);
            return savestatus;
        }
    }
}
