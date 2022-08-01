using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Authentication;
using StudentManagement.Models;
using StudentManagement.Operations.Interface;
using StudentManagement.Repository.Helpers.Interface;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace StudentManagement.Controllers
{

  //  [Authorize]
        [ApiController]
        [Route("api/[controller]/[action]")]
        public class LoginController : ControllerBase
        {
            private readonly JWTAuth jwtAuth;
        private readonly IUserops _userops;
        private readonly IAPIResponseHelper _responseHelper;

        public LoginController(JWTAuth jwtAuth, IUserops userops, IAPIResponseHelper APIResponseHelper )
            {
                this.jwtAuth = jwtAuth;
                this._userops = userops;
            this._responseHelper = APIResponseHelper;
            }


            [HttpPost]
            [AllowAnonymous()]
            public IActionResult Authorize([FromBody] User usr)
            {
             int res = _userops.loginOps(usr.UserName, usr.Password);
            if (res == 1)
            {
                var token = jwtAuth.Authenticate(usr.UserName, usr.Password);


                if (string.IsNullOrEmpty(token))
                {
                    return Unauthorized();
                }
                else
                {
                    return Ok(token);
                }
            }
            else
              return null;
            }



        [HttpPost("")]

        public IActionResult Register([FromBody]User user )
        {
            //if (string.IsNullOrWhiteSpace(savestudent.Name))
            //{
            //    return BadRequest();
            //}
            var response = _userops.RegisterOps(user.UserName,user.Password);
            return _responseHelper.CreateResponse(response);

        }

        //[HttpDelete]
        //public IActionResult TestRoute()
        //{
        //    return Ok("Authorized");
        //}
    }
    }


