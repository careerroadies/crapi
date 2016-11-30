using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataService;
using DataserviceInterface;
using ApplicationService;
using DataModels;
using CareerRoadiesApi.WebApiModels;

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
        public HttpResponseMessage saveprofile(BasicProfileDetailsDTO p)
        {
            pas = new ProfileApplicationService(_profileService);
            BasicProfileDetails bpd = new BasicProfileDetails();

            var result = pas.saveprofile(bpd);
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
    }
}
