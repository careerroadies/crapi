using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataserviceInterface;
using DataAccessLayer;
using System.Data;



namespace DataService
{
    public class commondataservice : Icommonservice
     {
         public DataTable GetMenu(int profileid)
         {
             SqlDataAccess obj = new SqlDataAccess();
             string strQuery = "Getmenu";
             var arrParam = new string[1, 2];
             arrParam[0, 0] = "p_profiletype";
             arrParam[0, 1] = profileid.ToString();
             var result = obj.ExecuteDataTable(strQuery, arrParam);
             return result;
         }

         public object GetProfileList(int userid, int profileid)
         {
             SqlDataAccess obj = new SqlDataAccess();
             string strQuery = "GetProfileList";
             var arrParam = new string[2, 2];
             arrParam[0, 0] = "p_userid";
             arrParam[0, 1] = userid.ToString();

             arrParam[1, 0] = "p_profileid";
             arrParam[1, 1] = profileid.ToString();
             var result = obj.ExecuteDataTable(strQuery, arrParam);
             return result;
         }  
    }
}
