using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataserviceInterface;
using DataModels;
using Utilities;
using DataAccessLayer;

namespace DataService
{
    public class TutorProfileService : ITutorProfileService
    {
        DBManager ObjUtility = new DBManager();
        SqlDataAccess obj = new SqlDataAccess();
        public System.Data.DataTable GetTutorProfilesDetails(string Profileid)
        {
            string strQuery = ObjUtility.GetTutorProfilesDetails;
            var arrParam = new string[1, 1];
            arrParam[0, 0] = "_profileid";
            arrParam[0, 1] = Profileid;
            var result = obj.ExecuteDataTable(strQuery, arrParam);
            if (result.Rows.Count > 0)
                return result;
            else
                return null;
        }

        public string SaveTutorProfilesDetails(TutorProfiles tutorProfiles)
        {
            string profile_id = string.Empty;
            string strQuery = ObjUtility.SaveTutorProfilesDetails;
            var arrParam = new string[17, 2];
            arrParam[0, 0] = "_Tutorprofiledetailsid";
            arrParam[0, 1] = tutorProfiles.Tutorprofiledetailsid.ToString();

            arrParam[1, 0] = "_profileid";
            arrParam[1, 1] = tutorProfiles.Profileid.ToString();

            arrParam[2, 0] = "_Name";
            arrParam[2, 1] = tutorProfiles.Name.ToString();

            arrParam[3, 0] = "_Location";
            arrParam[3, 1] = tutorProfiles.Location.ToString();

            arrParam[4, 0] = "_Stateid";
            arrParam[4, 1] = tutorProfiles.Stateid.ToString();

            arrParam[5, 0] = "_Cityid";
            arrParam[5, 1] = tutorProfiles.Cityid.ToString();

            arrParam[6, 0] = "_Contactno";
            arrParam[6, 1] = tutorProfiles.Contactno.ToString();

            arrParam[7, 0] = "_Email";
            arrParam[7, 1] = tutorProfiles.Email.ToString();

            arrParam[8, 0] = "_Landline";
            arrParam[8, 1] = tutorProfiles.Landline.ToString();

            arrParam[9, 0] = "_Institutename";
            arrParam[9, 1] = tutorProfiles.Institutename.ToString();


            arrParam[10, 0] = "_Added";
            arrParam[10, 1] = tutorProfiles.Added.ToString();


            arrParam[11, 0] = "_Updated";
            arrParam[11, 1] = tutorProfiles.Updated.ToString();


            arrParam[12, 0] = "_Active";
            arrParam[12, 1] = tutorProfiles.Active.ToString();


            arrParam[13, 0] = "_Uploadimage";
            arrParam[13, 1] = tutorProfiles.Uploadimage.ToString();

            arrParam[14, 0] = "_Description";
            arrParam[14, 1] = tutorProfiles.Description.ToString();

            arrParam[15, 0] = "_Specializations";
            arrParam[15, 1] = tutorProfiles.Specializations.ToString();

            arrParam[16, 0] = "_Maplocation";
            arrParam[16, 1] = tutorProfiles.Maplocation.ToString();

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
