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
    }

    public interface IProfileService
    {
        List<userprofile> GetProfiles();
        userprofile GetProfile(int profileid);
        string SaveProfile(userprofile userprofile);
    }

    public interface IuserService
    {
        usersession saveuser(user objuser);
        bool GetUserByUserName(string username, int usertype);
        user Login(string username, string password, string typeid);
    }
}
