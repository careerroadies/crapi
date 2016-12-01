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
            ValidateRequired("FirstName", "First Name");
            ValidateRequired("LastName", "Last Name");
            ValidateRequired("Gender", "Gender");
            ValidateEmailAddress("PrimaryEmail", "Primary Email");
            ValidateEmailAddress("AlternateEmail", "Alternate Email");
        }

    }
}
