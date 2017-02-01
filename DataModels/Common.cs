﻿using System;
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

    public class pincode
    {
        public string pincodeid { get; set; }
        public string location { get; set; }
    }

    public class alerts
    {
        public string alerttext { get; set; }
        public string added { get; set; }
    }
}
