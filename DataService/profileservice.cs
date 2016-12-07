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
  public class profileservice:IProfileService
    {
      BasicProfileDetails objprofile = new BasicProfileDetails();
        SqlDataAccess obj = new SqlDataAccess();
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

    }
}
