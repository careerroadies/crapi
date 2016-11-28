using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels
{
    public class Script
    {
        public int scriptId {get;set;}
        public int writerId {get;set;}
        public string area {get;set;}
        public string name {get;set;}
        public string summary {get;set;}
        public string filename {get;set;}
        public string status { get; set; }
    }
}
