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
            TransactionalInformation transaction = new TransactionalInformation();
            userApiModel userapimodel = new userApiModel();
            BasicProfileDetails bpd = new BasicProfileDetails();
            bpd.FirstName = p.FirstName;
            bpd.LastName = p.LastName;
            bpd.Gender = p.Gender;
            bpd.Dob = p.Dob;
            bpd.AlternateEmail = (!string.IsNullOrEmpty(p.AlternateEmail)?p.AlternateEmail: string.Empty);
            bpd.PrimaryEmail = p.PrimaryEmail;
            bpd.MobileNumber = p.MobileNumber;
            bpd.UserId = p.UserId;
            bpd.ProfileId = p.ProfileId;
            bpd.Status = p.Status;
            bpd.ProfilePicture = p.ProfilePicture;
            bpd.ProfileText = p.ProfileText;
            bpd.MaritalStatus = p.MaritalStatus;
            bpd.stype = p.stype;
            
            var result = pas.saveprofile(bpd, out transaction);
            if (transaction.ReturnStatus == false)
            {
                userapimodel.ReturnMessage = transaction.ReturnMessage;
                userapimodel.ReturnStatus = transaction.ReturnStatus;
                userapimodel.ValidationErrors = transaction.ValidationErrors;
                var badResponse = Request.CreateResponse<userApiModel>(HttpStatusCode.BadRequest, userapimodel);
                return badResponse;
            }
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
    }
}
