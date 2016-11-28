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
    public class UserController : ApiController
    {
        IuserService _userservice;
        UserApplicationService uas;

        public UserController()
        {
            _userservice = new userservice();
        }

        [HttpPost]
        public HttpResponseMessage saveuser([FromBody] UserDTO userDTO)
        {
            user user = new user();
            uas = new UserApplicationService(_userservice);
            TransactionalInformation transaction = new TransactionalInformation();
            userApiModel userapimodel = new userApiModel();
            user.email = userDTO.email;
            user.mobilenumber = userDTO.mobilenumber;
            user.password = userDTO.password;
            user.refferalid = userDTO.refferalid;
            user.usertypeid = userDTO.usertypeid;
            user.username = userDTO.email;

            var result = uas.saveuser(user, out transaction);
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

        [HttpPost]
        public HttpResponseMessage Login([FromBody] LoginDTO loginUserDTO)
        {
            uas = new UserApplicationService(_userservice);
            TransactionalInformation transaction = new TransactionalInformation();
            userApiModel userapimodel = new userApiModel();

            if (loginUserDTO.username == null) loginUserDTO.username = "";
            if (loginUserDTO.password == null) loginUserDTO.password = "";
            if (loginUserDTO.usertypeid == null) loginUserDTO.usertypeid = "";
            
            var result = uas.Login(loginUserDTO.username, loginUserDTO.password, loginUserDTO.usertypeid, out transaction);
            if (transaction.ReturnStatus == false)
            {
                userapimodel.ReturnMessage = transaction.ReturnMessage;
                userapimodel.ReturnStatus = transaction.ReturnStatus;
                userapimodel.ValidationErrors = transaction.ValidationErrors;
                var badResponse = Request.CreateResponse<userApiModel>(HttpStatusCode.BadRequest, userapimodel);
                return badResponse;
            }
            userapimodel.ReturnStatus = transaction.ReturnStatus;
            userapimodel.IsAuthenicated = true;
            userapimodel.ReturnMessage.Add("Login successful.");

            return Request.CreateResponse(HttpStatusCode.OK, result);
        }

    }
}