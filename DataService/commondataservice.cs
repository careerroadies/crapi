using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataserviceInterface;
using DataAccessLayer;
using System.Data;
using DataModels;



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

         public List<State> GetState()
         {
             List<State> lststates = new List<State>();
             State s = new State();
             SqlDataAccess obj = new SqlDataAccess();
             string strQuery = "getstate";
             var result = obj.ExecuteDataTable(strQuery);

             lststates = (from DataRow row in result.Rows

                    select new State
                    {
                        stateid = Convert.ToInt16(row["stateid"].ToString()),
                        name = row["name"].ToString()

                    }).ToList();
             return lststates;
         }

         public List<City> GetCity(int stateid)
         {
             List<City> lstcities = new List<City>();
             City s = new City();
             SqlDataAccess obj = new SqlDataAccess();
             var arrParam = new string[1, 2];
             arrParam[0, 0] = "_stateid";
             arrParam[0, 1] = stateid.ToString();
             string strQuery = "GetCity";

             var result = obj.ExecuteDataTable(strQuery, arrParam);

             lstcities = (from DataRow row in result.Rows

                          select new City
                          {
                              stateid = Convert.ToInt16(row["stateid"].ToString()),
                              name = row["name"].ToString(),
                              cityid = Convert.ToInt16(row["cityid"].ToString()),

                          }).ToList();
             return lstcities;
         }

         public List<searchuser> GetProfileByLocation(string location, int city, int state)
         {
             List<searchuser> lstusers = new List<searchuser>();
             searchuser s = new searchuser();
             SqlDataAccess obj = new SqlDataAccess();
             var arrParam = new string[3, 2];
             arrParam[0, 0] = "_location";
             arrParam[0, 1] = location.ToString();

             arrParam[1, 0] = "_city";
             arrParam[1, 1] = city.ToString();

             arrParam[2, 0] = "_state";
             arrParam[2, 1] = state.ToString();

             string strQuery = "GetSearchByLocation";

             var result = obj.ExecuteDataTable(strQuery, arrParam);

             lstusers = (from DataRow row in result.Rows

                          select new searchuser
                          {
                              profileid = row["profileid"].ToString(),
                              username = row["username"].ToString(),
                              dob = row["DOB"].ToString(),
                              mobilenumber = row["mobilenumber"].ToString(),
                              profilepicture = row["profilepicture"].ToString(),
                              primaryemail = row["primaryemail"].ToString(),

                          }).ToList();
             return lstusers;
         }
    }
}
