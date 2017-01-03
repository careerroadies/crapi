using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataserviceInterface;
using DataAccessLayer;
using DataModels;

namespace DataService
{
    public class AlertsDataService:IAlertsService
    {
        public bool SaveAlerts(string alerttext, string alerttypeid, string added, string alertzoneid,
                   string userid, string expiredate, string alertdescription)
        {
            SqlDataAccess obj = new SqlDataAccess();
            string strQuery = "savealerts";
            var arrParam = new string[7, 2];
            arrParam[0, 0] = "_alerttext";
            arrParam[0, 1] = alerttext.ToString();

            arrParam[1, 0] = "_alerttypeid";
            arrParam[1, 1] = alerttypeid.ToString();

            arrParam[2, 0] = "_added";
            arrParam[2, 1] = added.ToString();

            arrParam[3, 0] = "_alertzoneid";
            arrParam[3, 1] = alertzoneid.ToString();

            arrParam[4, 0] = "_userid";
            arrParam[4, 1] = userid.ToString();

            arrParam[5, 0] = "_expiredate";
            arrParam[5, 1] = expiredate.ToString();

            arrParam[6, 0] = "_alertdescription";
            arrParam[6, 1] = alertdescription.ToString();

            var result = obj.ExecuteNonQuery(strQuery, arrParam);

            return (result > 0) ? true : false;
        }
    }
}
