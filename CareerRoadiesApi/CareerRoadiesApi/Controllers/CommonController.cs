using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using System.Threading.Tasks;
using System.Data.Entity.Infrastructure;
using DataService;
using DataserviceInterface;
using ApplicationService;
using DataModels;
using CareerRoadiesApi.WebApiModels;


namespace CareerRoadiesApi.Controllers
{
    public class CommonController : ApiController
    {
        //  private CREntities db = new CREntities();
        Icommonservice commondataservice;
        // GET api/common
        public CommonController()
        {
            commondataservice = new commondataservice();
        }
        [HttpGet]
        public string GetTest()
        {
            return "deepak";
        }

        [HttpGet]
        public HttpResponseMessage GetMenu(int id)
        {
            CommonApplicationService commonBusinessService;
            commonBusinessService = new CommonApplicationService(commondataservice);
            var result = commonBusinessService.getMenu(id);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpGet]
        public HttpResponseMessage GetProfiles(int id)
        {
            CommonApplicationService commonBusinessService;
            commonBusinessService = new CommonApplicationService(commondataservice);
            var result = commonBusinessService.getProfileList(id, 0);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpGet]
        public HttpResponseMessage ViewProfiles(int id)
        {
            CommonApplicationService commonBusinessService;
            commonBusinessService = new CommonApplicationService(commondataservice);
            var result = commonBusinessService.getProfileList(0, id);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpGet]
        public HttpResponseMessage GetState()
        {
            TransactionalInformation transaction = new TransactionalInformation();
            CommonApplicationService commonBusinessService;
            commonBusinessService = new CommonApplicationService(commondataservice);
            userApiModel userapimodel = new userApiModel();

            var result = commonBusinessService.GetState(out transaction);
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

        [HttpGet]
        public HttpResponseMessage GetCity(int id)
        {
            TransactionalInformation transaction = new TransactionalInformation();
            CommonApplicationService commonBusinessService;
            commonBusinessService = new CommonApplicationService(commondataservice);
            userApiModel userapimodel = new userApiModel();

            var result = commonBusinessService.GetCity(id, out transaction);
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

        [HttpPost]
        public HttpResponseMessage GetProfileByLocation(LocationSearchDTO locationsearchDTO)
        {
            TransactionalInformation transaction = new TransactionalInformation();
            CommonApplicationService commonBusinessService;
            commonBusinessService = new CommonApplicationService(commondataservice);
            userApiModel userapimodel = new userApiModel();
            string location = string.Empty;
            int city = 1;
            int state = 1;
            location = locationsearchDTO.location;
            city = locationsearchDTO.city;
            state = locationsearchDTO.state;

            var result = commonBusinessService.GetuserByLocations(location, city, state, out transaction);
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
