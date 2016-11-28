using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataserviceInterface;
using System.Data;


namespace ApplicationService
{
    public class CommonApplicationService 
    {
        Icommonservice _commondataservice;
        private Icommonservice commondataservice
        {
            get { return _commondataservice; }
        }

        public CommonApplicationService(Icommonservice commonservice)
        {
            _commondataservice = commonservice;
        }

        public DataTable getMenu(int profileid)
        {
            var menulist = commondataservice.GetMenu(profileid);
            return menulist;
        }

        
        public object getProfileList(int userid, int profileid)
        {
            var friendsList = commondataservice.GetProfileList(userid, profileid);
            return friendsList;
        }
    }
}
