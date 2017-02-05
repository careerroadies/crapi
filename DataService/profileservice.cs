using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataserviceInterface;
using DataModels;
using DataAccessLayer;
using System.Data;
namespace DataService
{
    public class profileservice : IProfileService
    {
        BasicProfileDetails objprofile = new BasicProfileDetails();
        SqlDataAccess obj = new SqlDataAccess();
        #region "---Profile Basic detail----"
        public List<BasicProfileDetails> GetProfiles()
        {
            return null;
        }
        public DataTable GetProfile(string profileid)
        {
            string strQuery = "getprofiledetails";
            var arrParam = new string[1, 1];
            arrParam[0, 0] = "_profileid";
            arrParam[0, 1] = profileid;
            var result = obj.ExecuteDataTable(strQuery, arrParam);
            if (result.Rows.Count > 0)
                return result;
            else
                return null;
        }
        public string SaveProfile(BasicProfileDetails userprofile)
        {
            string profile_id = string.Empty;
            string strQuery = "saveprofiledetails";
            var arrParam = new string[17, 2];
            arrParam[0, 0] = "_profileid";
            arrParam[0, 1] = userprofile.ProfileId;

            arrParam[1, 0] = "_userid";
            arrParam[1, 1] = userprofile.UserId;

            arrParam[2, 0] = "_firstname";
            arrParam[2, 1] = userprofile.FirstName.ToString();

            arrParam[3, 0] = "_lastname";
            arrParam[3, 1] = userprofile.LastName.ToString();

            arrParam[4, 0] = "_dob";
            arrParam[4, 1] = userprofile.Dob.ToString();

            arrParam[5, 0] = "_maritalstatus";
            arrParam[5, 1] = userprofile.MaritalStatus.ToString();

            arrParam[6, 0] = "_profiletext";
            arrParam[6, 1] = userprofile.ProfileText.ToString();

            arrParam[7, 0] = "_profilepicture";
            arrParam[7, 1] = userprofile.ProfilePicture.ToString();

            arrParam[8, 0] = "_mobilenumber";
            arrParam[8, 1] = userprofile.MobileNumber.ToString();

            arrParam[9, 0] = "_primaryemail";
            arrParam[9, 1] = userprofile.PrimaryEmail.ToString();

            arrParam[10, 0] = "_alternateemail";
            arrParam[10, 1] = userprofile.AlternateEmail.ToString();

            arrParam[11, 0] = "_gender";
            arrParam[11, 1] = userprofile.Gender.ToString();

            arrParam[12, 0] = "_status";
            arrParam[12, 1] = userprofile.Status.ToString();

            arrParam[13, 0] = "_stype";
            arrParam[13, 1] = userprofile.stype.ToString();

            arrParam[15, 0] = "_location";
            arrParam[15, 1] = userprofile.location.ToString();

            arrParam[14, 0] = "_city";
            arrParam[14, 1] = userprofile.city.ToString();

            arrParam[16, 0] = "_state";
            arrParam[16, 1] = userprofile.state.ToString();



            var result = obj.ExecuteDataTable(strQuery, arrParam);
            if (result != null)
            {
                if (result.Rows.Count > 0)
                {
                    if (!string.IsNullOrEmpty(result.Rows[0]["uuid"].ToString()))
                        profile_id = result.Rows[0]["uuid"].ToString();

                }
            }
            return profile_id;
        }
        #endregion

        #region "---Profile Educationdetails-----"

        #region"---PostGraduation details-----"
        public DataTable GetPostGraduationDetails(string profileid)
        {
            string strQuery = "getpostgraduationdetails";
            var arrParam = new string[1, 1];
            arrParam[0, 0] = "_profileid";
            arrParam[0, 1] = profileid;
            var result = obj.ExecuteDataTable(strQuery, arrParam);
            if (result.Rows.Count > 0)
                return result;
            else
                return null;
        }
        public string SavePostGraduationDetails(profilepostgraduation postgraduation)
        {
            string profile_id = string.Empty;
            string strQuery = "savepostgraduationdetails";
            var arrParam = new string[9, 2];
            arrParam[0, 0] = "_profilepostgraduationid";
            arrParam[0, 1] = postgraduation.profilepostgraduationid;

            arrParam[1, 0] = "_profileid";
            arrParam[1, 1] = postgraduation.profileid;

            arrParam[2, 0] = "_postgraduationid";
            arrParam[2, 1] = postgraduation.postgraduationid;

            arrParam[3, 0] = "_postgraduationtypeid";
            arrParam[3, 1] = postgraduation.postgraduationtypeid;

            arrParam[4, 0] = "_specializationid";
            arrParam[4, 1] = postgraduation.specializationid;

            arrParam[5, 0] = "_UniversityorInstituteid";
            arrParam[5, 1] = postgraduation.UniversityorInstituteid;

            arrParam[6, 0] = "_Year";
            arrParam[6, 1] = postgraduation.Year;

            arrParam[7, 0] = "_grad";
            arrParam[7, 1] = postgraduation.gradingsystem;

            arrParam[8, 0] = "_marks";
            arrParam[8, 1] = postgraduation.marks;

            var result = obj.ExecuteDataTable(strQuery, arrParam);
            if (result != null)
            {
                if (result.Rows.Count > 0)
                {
                    if (!string.IsNullOrEmpty(result.Rows[0]["uuid"].ToString()))
                        profile_id = result.Rows[0]["uuid"].ToString();

                }
            }
            return profile_id;
        }
        #endregion

        #region"---Graduation details-----"
        public DataTable GetGraduationDetails(string profileid)
        {
            string strQuery = "getgraduationdetails";
            var arrParam = new string[1, 1];
            arrParam[0, 0] = "_profileid";
            arrParam[0, 1] = profileid;
            var result = obj.ExecuteDataTable(strQuery, arrParam);
            if (result.Rows.Count > 0)
                return result;
            else
                return null;
        }
        public string SaveGraduationDetails(profilegraduationdetails graduation)
        {
            string profile_id = string.Empty;
            string strQuery = "savegraduationdetails";
            var arrParam = new string[9, 2];
            arrParam[0, 0] = "_profilegraduationid";
            arrParam[0, 1] = graduation.profilegraduationid;

            arrParam[1, 0] = "_profileid";
            arrParam[1, 1] = graduation.profileid;

            arrParam[2, 0] = "_graduationid";
            arrParam[2, 1] = graduation.graduationid;

            arrParam[3, 0] = "_graduationtypeid";
            arrParam[3, 1] = graduation.graduationtypeid;

            arrParam[4, 0] = "_specializationid";
            arrParam[4, 1] = graduation.specializationid;

            arrParam[5, 0] = "_UniversityorInstituteid";
            arrParam[5, 1] = graduation.UniversityorInstituteid;

            arrParam[6, 0] = "_Year";
            arrParam[6, 1] = graduation.Year;

            arrParam[7, 0] = "_grad";
            arrParam[7, 1] = graduation.grad;

            arrParam[8, 0] = "_marks";
            arrParam[8, 1] = graduation.marks;

            var result = obj.ExecuteDataTable(strQuery, arrParam);
            if (result != null)
            {
                if (result.Rows.Count > 0)
                {
                    if (!string.IsNullOrEmpty(result.Rows[0]["uuid"].ToString()))
                        profile_id = result.Rows[0]["uuid"].ToString();

                }
            }
            return profile_id;
        }
        #endregion

        #region"---Higher Secondary details-----"
        public DataTable GetHigherSecondaryDetails(string profileid)
        {
            string strQuery = "gethighersecondarydetails";
            var arrParam = new string[1, 1];
            arrParam[0, 0] = "_profileid";
            arrParam[0, 1] = profileid;
            var result = obj.ExecuteDataTable(strQuery, arrParam);
            if (result.Rows.Count > 0)
                return result;
            else
                return null;
        }
        public string SaveHigherSecondaryDetails(profilehighersecondarydetails highersecondary)
        {
            string profile_id = string.Empty;
            string strQuery = "savehighersecondarydetails";
            var arrParam = new string[6, 2];
            arrParam[0, 0] = "_profilehighersecondarydetailsid";
            arrParam[0, 1] = highersecondary.profilehighersecondarydetailsid;

            arrParam[1, 0] = "_profileid";
            arrParam[1, 1] = highersecondary.profileid;

            arrParam[2, 0] = "_educationboardid";
            arrParam[2, 1] = highersecondary.educationboardid;

            arrParam[3, 0] = "_Year";
            arrParam[3, 1] = highersecondary.Year;

            arrParam[4, 0] = "_medium";
            arrParam[4, 1] = highersecondary.medium;

            arrParam[5, 0] = "_marks";
            arrParam[5, 1] = highersecondary.marks;

            var result = obj.ExecuteDataTable(strQuery, arrParam);
            if (result != null)
            {
                if (result.Rows.Count > 0)
                {
                    if (!string.IsNullOrEmpty(result.Rows[0]["uuid"].ToString()))
                        profile_id = result.Rows[0]["uuid"].ToString();

                }
            }
            return profile_id;
        }
        #endregion

        #region"---Secondary details-----"
        public DataTable GetSecondaryDetails(string profileid)
        {
            string strQuery = "getsecondarydetails";
            var arrParam = new string[1, 1];
            arrParam[0, 0] = "_profileid";
            arrParam[0, 1] = profileid;
            var result = obj.ExecuteDataTable(strQuery, arrParam);
            if (result.Rows.Count > 0)
                return result;
            else
                return null;
        }
        public string SaveSecondaryDetails(profilesecondarydetails secondary)
        {
            string profile_id = string.Empty;
            string strQuery = "savesecondarydetails";
            var arrParam = new string[6, 2];
            arrParam[0, 0] = "_profilesecondarydetailsid";
            arrParam[0, 1] = secondary.profilesecondarydetailsid;

            arrParam[1, 0] = "_profileid";
            arrParam[1, 1] = secondary.profileid;

            arrParam[2, 0] = "_educationboardid";
            arrParam[2, 1] = secondary.educationboardid;

            arrParam[3, 0] = "_Year";
            arrParam[3, 1] = secondary.Year;

            arrParam[4, 0] = "_medium";
            arrParam[4, 1] = secondary.medium;

            arrParam[5, 0] = "_marks";
            arrParam[5, 1] = secondary.marks;

            var result = obj.ExecuteDataTable(strQuery, arrParam);
            if (result != null)
            {
                if (result.Rows.Count > 0)
                {
                    if (!string.IsNullOrEmpty(result.Rows[0]["uuid"].ToString()))
                        profile_id = result.Rows[0]["uuid"].ToString();

                }
            }
            return profile_id;
        }
        #endregion
        #endregion

    }
}

