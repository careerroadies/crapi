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
        List<pincode> GetPinCode(string cityid);
      //  List<alerts> GetAlerts();
       
    }

    public interface IProfileService
    {
        DataTable GetProfile(string Profileid);
        string SaveProfile(BasicProfileDetails userprofile);

        List<BasicProfileDetails> GetProfiles();

        DataTable GetPostGraduationDetails(string Profileid);
        string SavePostGraduationDetails(profilepostgraduation postgraduation);

        DataTable GetGraduationDetails(string Profileid);
        string SaveGraduationDetails(profilegraduationdetails graduation);

        DataTable GetHigherSecondaryDetails(string Profileid);
        string SaveHigherSecondaryDetails(profilehighersecondarydetails highersecondary);

        DataTable GetSecondaryDetails(string Profileid);
        string SaveSecondaryDetails(profilesecondarydetails secondary);
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

    public interface ITutorProfileService
    {
        DataTable GetTutorProfilesDetails(string Profileid);
        string SaveTutorProfilesDetails(TutorProfiles tutorProfiles);
    }
}
