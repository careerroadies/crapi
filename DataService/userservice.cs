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

    public class userservice : IuserService
    {
        SqlDataAccess obj = new SqlDataAccess();
        usersession objuser = new usersession();
        public usersession saveuser(user user)
        {
            string userid = string.Empty;
            string refid = string.Empty;
            string strQuery = "saveuser";
            var arrParam = new string[6, 2];
            arrParam[0, 0] = "_username";
            arrParam[0, 1] = user.username;

            arrParam[1, 0] = "_password";
            arrParam[1, 1] = user.password;

            arrParam[2, 0] = "_email";
            arrParam[2, 1] = user.email;

            arrParam[3, 0] = "_mobilenumber";
            arrParam[3, 1] = user.mobilenumber;

            arrParam[4, 0] = "_usertypeid";
            arrParam[4, 1] = user.usertypeid.ToString();

            arrParam[5, 0] = "_refferalid";
            arrParam[5, 1] = user.refferalid;

            obj.ExecuteNonQuery(strQuery, arrParam, out refid, out userid);

            if (!string.IsNullOrEmpty(refid))
                objuser._ownrefferalid = refid;

            if (!string.IsNullOrEmpty(userid))
                objuser._userid = userid;

            return objuser;
        }

        public bool GetUserByUserName(string username, int usertype)
        {
            string strQuery = "ValidateUserName";
            var arrParam = new string[2, 2];
            arrParam[0, 0] = "uname";
            arrParam[0, 1] = username.ToString();

            arrParam[1, 0] = "typeid";
            arrParam[1, 1] = usertype.ToString();

            var result = obj.ExecuteScalar(strQuery, arrParam);

            if (result == null)
                return false;
            else
                return true;
        }

        public user Login(string username, string password, string typeid)
        {
            var userobj = new user();
            string strQuery = "ValidateUser";
            var arrParam = new string[3, 2];
            arrParam[0, 0] = "uname";
            arrParam[0, 1] = username.ToString();

            arrParam[1, 0] = "typeid";
            arrParam[1, 1] = typeid.ToString();

            arrParam[2, 0] = "upassword";
            arrParam[2, 1] = password.ToString();

            var result = obj.ExecuteDataTable(strQuery, arrParam);
            if (result.Rows.Count > 0)
            {
                userobj.email = result.Rows[0]["email"].ToString();
                userobj.mobilenumber = result.Rows[0]["mobilenumber"].ToString();
                userobj.ownrefferalid = result.Rows[0]["ownrefferalid"].ToString();
                userobj.refferalid = result.Rows[0]["refferalid"].ToString();
                userobj.refferalid = result.Rows[0]["username"].ToString();

                return userobj;
            }
            else
            {
                return null;
            }

            
        }
    }
}
