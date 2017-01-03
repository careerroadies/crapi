using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataModels;
using DataserviceInterface;



namespace ApplicationService
{
    public class PostAdsApplicationService
    {
        IPostAdsService _postadsdataservice;
        private IPostAdsService postadsdataservice
        {
            get { return _postadsdataservice; }
        }

        public PostAdsApplicationService(IPostAdsService postadservice)
        {
            _postadsdataservice = postadservice;
        }

        public bool SaveAds(postads objads , out TransactionalInformation transaction)
        {
            var issaveAlert = false;
            transaction = new TransactionalInformation();
            try
            {
                transaction.ReturnStatus = true;
                issaveAlert = postadsdataservice.SaveAds(objads);
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
