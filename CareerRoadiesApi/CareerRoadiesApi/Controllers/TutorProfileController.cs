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
    public class TutorProfileController : ApiController
    {
        ITutorProfileService _profileService;
        TutorProfileApplicationService pas;
        public TutorProfileController()
        {
            _profileService = new TutorProfileService();
        }

        [HttpPost]
        public HttpResponseMessage SaveTutorProfilesDetails(TutorprofilesDTO p)
        {
            pas = new TutorProfileApplicationService(_profileService);
            TransactionalInformation transaction = new TransactionalInformation();
            userApiModel userapimodel = new userApiModel();
            TutorProfiles bpd = new TutorProfiles();
            bpd.Tutorprofiledetailsid = p.Tutorprofiledetailsid;
            bpd.Profileid = p.Profileid;
            bpd.Name = p.Name;
            bpd.Location = p.Location;
            bpd.Stateid = p.Stateid;
            bpd.Cityid = p.Cityid;
            bpd.Contactno = p.Contactno;
            bpd.Email = p.Email;
            bpd.Landline = p.Landline;
            bpd.Institutename = p.Institutename;
            bpd.Added = p.Added;
            bpd.Updated = p.Updated;
            bpd.Active = p.Active;
            bpd.Uploadimage = p.Uploadimage;
            bpd.Description = p.Description;
            bpd.Specializations = p.Specializations;
            bpd.Maplocation = p.Maplocation;

            var result = pas.SaveTutorProfilesDetails(bpd, out transaction);
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
        [HttpGet]
        public HttpResponseMessage GetTutorProfilesDetails(int id)
        {
            TutorProfileApplicationService profileApplicationService;
            profileApplicationService = new TutorProfileApplicationService(_profileService);
            var result = profileApplicationService.GetTutorProfilesDetails(id.ToString());
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
    }
}
