using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModels;
using DataserviceInterface;

namespace ApplicationService
{
    public class ProfileBusinessRules : ValidationRules
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
            ValidateRequired("state", "State");
            ValidateRequired("city", "City");
            ValidateRequired("location", "Location");
            ValidateEmailAddress("PrimaryEmail", "Primary Email");
            ValidateEmailAddress("AlternateEmail", "Alternate Email");
        }
        public void ValidatePostGraduationDetails(profilepostgraduation profile, IProfileService profileservice)
        {
            profiledataservice = profileservice;
            InitializeValidationRules(profile);
            ValidateRequired("postgraduationid", "Post Graduation");
            ValidateRequired("postgraduationtypeid", "Post Graduation Type");
            ValidateRequired("specializationid", "Specialization");
            ValidateRequired("UniversityorInstituteid", "University or Institute");
            ValidateRequired("Year", "Year");
            ValidateRequired("gradingsystem", "Grade");
            ValidateRequired("marks", "Marks");

        }
        public void ValidateGraduationDetails(profilegraduationdetails profile, IProfileService profileservice)
        {
            profiledataservice = profileservice;
            InitializeValidationRules(profile);
            ValidateRequired("graduationid", "Graduation");
            ValidateRequired("postgraduationtypeid", "Graduation Type");
            ValidateRequired("specializationid", "Specialization");
            ValidateRequired("UniversityorInstituteid", "University or Institute");
            ValidateRequired("Year", "Year");
            ValidateRequired("gradingsystem", "Grade");
            ValidateRequired("marks", "Marks");
        }
        public void ValidateHigherSecondaryDetails(profilehighersecondarydetails profile, IProfileService profileservice)
        {
            profiledataservice = profileservice;
            InitializeValidationRules(profile);
            ValidateRequired("educationboardid", "Education Board Name");
            ValidateRequired("medium", "Medium ");
            ValidateRequired("Year", "Year");
            ValidateRequired("marks", "Marks");
        }
        public void ValidateSecondaryDetails(profilesecondarydetails profile, IProfileService profileservice)
        {
            profiledataservice = profileservice;
            InitializeValidationRules(profile);
            ValidateRequired("educationboardid", "Education Board Name");
            ValidateRequired("medium", "Medium ");
            ValidateRequired("Year", "Year");
            ValidateRequired("marks", "Marks");
        }
    }
}
