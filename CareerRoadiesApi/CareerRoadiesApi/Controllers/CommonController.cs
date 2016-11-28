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

      /*  //[HttpGet]
        public HttpResponseMessage GetCity(int id)
        {
            var result = db.cities.Where(a => a.stateid == id).Select(x => new { x.name, x.cityid }).OrderBy(o => o.name).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpGet]
        public HttpResponseMessage GetCountry()
        {
            var result = db.countries.Select(x => new { x.name, x.countryid }).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

        [HttpGet]
        public HttpResponseMessage GetState(int id)
        {
            var result = db.states.Where(a => a.countryid == id).Select(x => new { x.name, x.stateid }).OrderBy(o => o.name).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }*/
    }
}
