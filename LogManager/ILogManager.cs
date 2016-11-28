using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using log4net;
using log4net.Config;


namespace LogManager
{
    public interface ILogManager
    {
        void createLogger();
        void writeRequest(string message);
        void writeResponse(string message);
        void writeException(string message);
        void writeDBQueryTime(string strQuery, int iTime);
        string ConvertXMLtoString(XmlNode xmlnode);
    }
}
