using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels
{
    public class Common
    {

    }

    public class City
    {
        public int cityid { get; set; }
        public int stateid { get; set; }
        public string name { get; set; }
    }

    public class State
    {
        public int stateid { get; set; }
        public string name { get; set; }
    }
}
