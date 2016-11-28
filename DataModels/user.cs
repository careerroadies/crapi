using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels
{
    // This is the user model.
    public class user
    {
        public int user_id;
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string mobilenumber { get; set; }
        public int usertypeid { get; set; }
        public string refferalid { get; set; }
        public string ownrefferalid { get; set; }
    }
}
