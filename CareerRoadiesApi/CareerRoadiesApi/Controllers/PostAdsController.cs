using ApplicationService;
using CareerRoadiesApi.WebApiModels;
using DataModels;
using DataService;
using DataserviceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CareerRoadiesApi.Controllers
{
    public class PostAdsController : ApiController
    {
          IPostAdsService postdataservice;
        // GET api/common
          public PostAdsController()
        {
            postdataservice = new PostadsDataService();
        }
          [HttpPost]
          public HttpResponseMessage SavePostAds(AdsDTO adsDTO)
          {
              TransactionalInformation transaction = new TransactionalInformation();
              PostAdsApplicationService postadBusinessService;
              postadBusinessService = new PostAdsApplicationService(postdataservice);
              userApiModel userapimodel = new userApiModel();
              postads pad = new postads();
               pad.adsid = adsDTO.adsid;
             pad.adcategoryid  = adsDTO.adsid;
             pad.adtitle  = adsDTO.adsid;
             pad.addescription  = adsDTO.adsid;
             pad.state  = adsDTO.adsid;
             pad.city  = adsDTO.adsid;
             pad.location  = adsDTO.adsid;
             pad.name  = adsDTO.adsid;
             pad.email  = adsDTO.adsid;
             pad.mobilenumber  = adsDTO.adsid;
             pad.createdate  = adsDTO.adsid;
             pad.createdby  = adsDTO.adsid;
             pad.image  = adsDTO.adsid;
             pad.active = adsDTO.adsid;

             var result = postadBusinessService.SaveAds(pad,  out transaction);
              if (transaction.ReturnStatus == false)
              {
                  userapimodel.ReturnMessage = transaction.ReturnMessage;
                  userapimodel.ReturnStatus = transaction.ReturnStatus;
                  var badResponse = Request.CreateResponse<userApiModel>(HttpStatusCode.BadRequest, userapimodel);
                  return badResponse;

              }
              userapimodel.ReturnStatus = transaction.ReturnStatus;
              userapimodel.IsAuthenicated = true;
              return Request.CreateResponse(HttpStatusCode.OK, result);
          }
    }
}
