using Microsoft.AspNetCore.Mvc;
using StudentManagement.Repository.Helpers.Interface;
using StudentManagement.Controllers;

namespace StudentManagement.Helpers
{
    public class APIResponseHelper : IAPIResponseHelper
    {
        public IActionResult CreateResponse(dynamic result)
        {
            if (result == null)
            {
                return new StatusCodeResult(StatusCodes.Status500InternalServerError);
            }
            if (result is bool)
            {
                return result ? new StatusCodeResult(StatusCodes.Status500InternalServerError) : new OkResult();
            }
            if (result is int)
            {
                if (result == -400)
                    return new StatusCodeResult(StatusCodes.Status400BadRequest);
                else
                    return result < 0 ? new StatusCodeResult(StatusCodes.Status500InternalServerError) : new OkResult();
            }
            return new JsonResult(result);
        }
        
    }

}
