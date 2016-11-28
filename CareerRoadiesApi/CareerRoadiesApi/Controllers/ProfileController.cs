using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataService;
using DataserviceInterface;
using ApplicationService;
using DataModels;

namespace CareerRoadiesApi.Controllers
{
    public class ProfileController : ApiController
    {
        IProfileService _profileService;
        ProfileApplicationService pas;
        public ProfileController()
        {
            _profileService = new profileservice();
        }   

        [HttpPost]
        public HttpResponseMessage saveprofile(userprofile p)
        {
            pas = new ProfileApplicationService(_profileService);
            var result = pas.saveprofile(p);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
    }
}
