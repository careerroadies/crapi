using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModels;
using DataserviceInterface;

namespace ApplicationService
{
    public class ProfileBusinessRules:ValidationRules
    {
        IProfileService profiledataservice;

        public void InitializeProfileBusinessRules(BasicProfileDetails profile, IProfileService profileservice)
        {
            profiledataservice = profileservice;
            InitializeValidationRules(profile);
        }

        public void ValidateProfile(BasicProfileDetails profile, IProfileService profileservice)
        {
            profiledataservice = profileservice;
            InitializeValidationRules(profile);
            ValidateRequired("firstname", "First Name");
            ValidateRequired("lastname", "Last Name");
            ValidateRequired("gender", "Gender");
            ValidateEmailAddress("primaryemail", "Primary Email");
            ValidateEmailAddress("alternateemail", "Alternate Email");
        }

    }
}
