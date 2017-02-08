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
            bpd.AlternateEmail = (!string.IsNullOrEmpty(p.AlternateEmail) ? p.AlternateEmail : string.Empty);
            bpd.PrimaryEmail = p.PrimaryEmail;
            bpd.MobileNumber = p.MobileNumber;
            bpd.UserId = p.UserId;
            bpd.ProfileId = p.ProfileId;
            bpd.Status = p.Status;
            bpd.ProfilePicture = p.ProfilePicture;
            bpd.ProfileText = p.ProfileText;
            bpd.MaritalStatus = p.MaritalStatus;
            bpd.stype = p.stype;
            bpd.city = p.city;
            bpd.state = p.state;
            bpd.location = p.location;


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

        #region"----"Education details-----"
        #region "----Post graduation details------"
        [HttpPost]
        public HttpResponseMessage SavePostGraduationDetails(profilepostgraduationDTO p)
        {
            pas = new ProfileApplicationService(_profileService);
            TransactionalInformation transaction = new TransactionalInformation();
            userApiModel userapimodel = new userApiModel();
            profilepostgraduation bpd = new profilepostgraduation();
            bpd.postgraduationid = p.postgraduationid;
            bpd.postgraduationtypeid = p.postgraduationtypeid;
            bpd.profileid = p.profileid;
            bpd.profilepostgraduationid = p.profilepostgraduationid;
            bpd.specializationid = p.specializationid;
            bpd.UniversityorInstituteid = p.UniversityorInstituteid;
            bpd.Year = p.Year;
            bpd.marks = p.marks;
            bpd.gradingsystem = p.gradingsystem;

            var result = pas.SavePostGraduationDetails(bpd, out transaction);
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
        public HttpResponseMessage GetPostGraduationDetails(int id)
        {
            ProfileApplicationService profileBusinessService;
            profileBusinessService = new ProfileApplicationService(_profileService);
            var result = profileBusinessService.GetPostGraduationDetails(id.ToString());
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
        #endregion

        #region"-----Graduation Details-----"
        [HttpPost]
        public HttpResponseMessage SaveGraduationDetails(profilegraduationdetailsDTO p)
        {
            pas = new ProfileApplicationService(_profileService);
            TransactionalInformation transaction = new TransactionalInformation();
            userApiModel userapimodel = new userApiModel();
            profilegraduationdetails bpd = new profilegraduationdetails();
            bpd.graduationid = p.graduationid;
            bpd.graduationtypeid = p.graduationtypeid;
            bpd.profileid = p.profileid;
            bpd.profilegraduationid = p.profilegraduationid;
            bpd.specializationid = p.specializationid;
            bpd.UniversityorInstituteid = p.UniversityorInstituteid;
            bpd.Year = p.Year;
            bpd.marks = p.marks;
            bpd.grad = p.grad;


            var result = pas.SaveGraduationDetails(bpd, out transaction);
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
        public HttpResponseMessage GetGraduationDetails(int id)
        {
            ProfileApplicationService profileBusinessService;
            profileBusinessService = new ProfileApplicationService(_profileService);
            var result = profileBusinessService.GetGraduationDetails(id.ToString());
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
        #endregion

        #region"-----Higher Secondary Details-----"
        [HttpPost]
        public HttpResponseMessage SaveHigherSecondaryDetails(profilehighersecondarydetailsDTO p)
        {
            pas = new ProfileApplicationService(_profileService);
            TransactionalInformation transaction = new TransactionalInformation();
            userApiModel userapimodel = new userApiModel();
            profilehighersecondarydetails bpd = new profilehighersecondarydetails();
            bpd.profilehighersecondarydetailsid = p.profilehighersecondarydetailsid;
            bpd.profileid = p.profileid;
            bpd.educationboardid = p.educationboardid;
            bpd.marks = p.marks;
            bpd.medium = p.medium;
            bpd.Year = p.Year;

            var result = pas.SaveHigherSecondaryDetails(bpd, out transaction);
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
        public HttpResponseMessage GetHigherSecondaryDetails(int id)
        {
            ProfileApplicationService profileBusinessService;
            profileBusinessService = new ProfileApplicationService(_profileService);
            var result = profileBusinessService.GetHigherSecondaryDetails(id.ToString());
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
        #endregion

        #region"-----Secondary Details-----"
        [HttpPost]
        public HttpResponseMessage SaveSecondaryDetails(profilesecondarydetailsDTO p)
        {
            pas = new ProfileApplicationService(_profileService);
            TransactionalInformation transaction = new TransactionalInformation();
            userApiModel userapimodel = new userApiModel();
            profilesecondarydetails bpd = new profilesecondarydetails();
            bpd.profilesecondarydetailsid = p.profilesecondarydetailsid;
            bpd.profileid = p.profileid;
            bpd.educationboardid = p.educationboardid;
            bpd.marks = p.marks;
            bpd.medium = p.medium;
            bpd.Year = p.Year;

            var result = pas.SaveSecondaryDetails(bpd, out transaction);
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
        public HttpResponseMessage GetSecondaryDetails(int id)
        {
            ProfileApplicationService profileBusinessService;
            profileBusinessService = new ProfileApplicationService(_profileService);
            var result = profileBusinessService.GetSecondaryDetails(id.ToString());
            return Request.CreateResponse(HttpStatusCode.OK, result);
        }
        #endregion
        #endregion
    }
}
