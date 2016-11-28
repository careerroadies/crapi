using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModels;
using DataserviceInterface;


namespace ApplicationService
{
    public class WriterBusinessService
    {
        IWriterDataService _writerdataservice;

        private IWriterDataService writerdataservice
        {
            get { return _writerdataservice; }
        }

        public WriterBusinessService(IWriterDataService dataservice)
        {
            _writerdataservice = dataservice;
        }

      /*   public List<Script> GetScripts(out TransactionalInformation transaction)
         {
             transaction = new TransactionalInformation();
             List<Script> scripts = new List<Script>();
             try
             {
                 writerdataservice.CreateSession();
                 scripts = writerdataservice.GetAllScript();
                 transaction.ReturnStatus = true;
             }
             catch(Exception ex)
             {
                 transaction.ReturnMessage = new List<string>();
                 string errorMessage = ex.Message;
                 transaction.ReturnStatus = false;
                 transaction.ReturnMessage.Add(errorMessage);
                 writerdataservice.CloseSession();
             }

             return scripts;
         }*/
    }
}
