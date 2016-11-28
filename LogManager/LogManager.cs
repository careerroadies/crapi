using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using log4net;
using log4net.Config;
using System.IO;


namespace LogManager
{
    public class LogManager : ILogManager 
    {
        private ILog log;

        public LogManager()
        {
        }

        public void createLogger()
        {
            log = log4net.LogManager.GetLogger(typeof(LogManager));
        }

        public void writeRequest(string message)
        {
            string strMessage = " Request: " + message; 
            log.Info(strMessage);
        }

        public void writeResponse(string message)
        {
            string strMessage = " Response: " + message;
            log.Info(strMessage);
        }

        public void writeException(string message)
        {
            log.Error(" " + message); 
        }

        public void writeDBQueryTime(string strQuery, int iTime)
        {
            string message = " Query Time: " + iTime.ToString() + "s for query: " + strQuery;
            log.Debug(message);
        }

        public string ConvertXMLtoString(XmlNode xmlnode)
        { 
            StringWriter sw = new StringWriter();
            XmlTextWriter xw = new XmlTextWriter(sw);

            xmlnode.WriteTo(xw);
            return sw.ToString();
        }

    }
}
