using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModels;
using System.Data;

namespace DataserviceInterface
{
    public interface Icommonservice
    {
        DataTable GetMenu(int profileid);
        object GetProfileList(int profileid, int userid);
        List<searchuser> GetProfileByLocation(string location, int city, int state);
        List<City> GetCity(int stateid);
        List<State> GetState();
      //  List<alerts> GetAlerts();
       
    }

    public interface IProfileService
    {
        List<BasicProfileDetails> GetProfiles();
        string SaveProfile(BasicProfileDetails userprofile);
        DataTable GetProfile(string Profileid);
    }

    public interface IuserService
    {
        usersession saveuser(user objuser);
        bool GetUserByUserName(string username, int usertype);
        user Login(string username, string password, string typeid);
    }

    public interface IAlertsService
    {
        bool SaveAlerts(string alerttext, string alerttypeid, string added, string alertzoneid,
                       string userid, string expiredate, string alertdescription);
    }

    public interface IPostAdsService
    {
        bool SaveAds(postads postads);
    }
}
