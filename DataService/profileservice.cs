using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataserviceInterface;
using DataModels;
using DataAccessLayer;
namespace DataService
{
  public class profileservice:IProfileService
    {
        userprofile objprofile = new userprofile();
        SqlDataAccess obj = new SqlDataAccess();
        public List<userprofile> GetProfiles()
        {
            return null;
        }

        public userprofile GetProfile(int profileid)
        {
            return null;
        }


        public string SaveProfile(userprofile userprofile)
        {
            string strQuery = "saveprofiledetails";
            var arrParam = new string[14, 2];
            arrParam[0, 0] = "userid";
            arrParam[0, 1] = userprofile.userid.ToString();

            arrParam[1, 0] = "firstname";
            arrParam[1, 1] = userprofile.firstname.ToString();

            arrParam[2, 0] = "middlename";
            arrParam[2, 1] = userprofile.middlename.ToString();

            arrParam[3, 0] = "lastname";
            arrParam[3, 1] = userprofile.lastname.ToString();

            arrParam[4, 0] = "fathername";
            arrParam[4, 1] = userprofile.fathername.ToString();

            arrParam[5, 0] = "mothername";
            arrParam[5, 1] = userprofile.mothername.ToString();

            arrParam[6, 0] = "bloodgroup";
            arrParam[6, 1] = userprofile.bloodgroup.ToString();

            arrParam[7, 0] = "dob";
            arrParam[7, 1] = userprofile.dob.ToString();

            arrParam[8, 0] = "maritalstatus";
            arrParam[8, 1] = userprofile.maritalstatus.ToString();

            arrParam[9, 0] = "Anniversory";
            arrParam[9, 1] = "2016-08-23";//userprofile.Anniversory.ToString();

            arrParam[10, 0] = "profilepicture";
            arrParam[10, 1] = userprofile.profilepicture.ToString();    

            arrParam[11, 0] = "profiletext";
            arrParam[11, 1] = userprofile.profiletext.ToString();

            arrParam[12, 0] = "contactno";
            arrParam[12, 1] = userprofile.contactno.ToString();

            arrParam[13, 0] = "stype";
            arrParam[13, 1] = userprofile.stype.ToString();

            var result = obj.ExecuteNonQuery(strQuery, arrParam);
            return Convert.ToString(result);
        }
    }
}
