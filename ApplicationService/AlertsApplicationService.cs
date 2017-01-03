using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataserviceInterface;
using DataModels;
using System.Data;

namespace ApplicationService
{
    public class AlertsApplicationService
    {

        IAlertsService _alertdataservice;
        private IAlertsService alertdataservice
        {
            get { return _alertdataservice; }
        }

        public AlertsApplicationService(IAlertsService dataservice)
        {
            _alertdataservice = dataservice;
        }

        public bool SaveAlerts(string alerttext, string alerttypeid, string added, string alertzoneid,
                     string userid, string expiredate, string alertdescription, out TransactionalInformation transaction)
        {
            var issaveAlert = false;
            transaction = new TransactionalInformation();
            try
            {
                transaction.ReturnStatus = true;
                issaveAlert = alertdataservice.SaveAlerts(alerttext, alerttypeid, added, alertzoneid, userid, expiredate, alertdescription);
            }
            catch (Exception ex)
            {
                string errorMessage = ex.Message;
                transaction.ReturnStatus = false;
                transaction.ReturnMessage.Add(errorMessage);
            }
            return issaveAlert;
        }
    }
}
