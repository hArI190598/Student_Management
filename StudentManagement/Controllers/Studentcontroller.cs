using Microsoft.AspNetCore.Mvc;
using StudentManagement.Operations.Interface;
using StudentManagement.Repository.Helpers.Interface;
using StudentManagement.Models;

namespace StudentManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController
    {
        private readonly IStudentops _studentops;
        private readonly IAPIResponseHelper _responseHelper;

        public StudentController(IStudentops studentops, IAPIResponseHelper responseHelper)
        {
            this._studentops = studentops;
            this._responseHelper = responseHelper;
        }

        [HttpGet("")]

        public IActionResult GetAllStudent()
        {
            var response = _studentops.GetStudentops();
            return _responseHelper.CreateResponse(response);
        }

        [HttpGet("Name")]
        public IActionResult GetStudentByName([FromQuery] string Name)
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                return BadRequest();
            }
            var response = _studentops.GetStudentByNameops(Name);
            return _responseHelper.CreateResponse(response);
        }

        [HttpGet("{id}")]

        public IActionResult GetStudentById([FromRoute] int id)
        {
            if (id < 1)
            {
                return BadRequest();
            }
            var response = _studentops.GetStudentByIdops(id);
            return _responseHelper.CreateResponse(response);
        }


        [HttpPost("")]

        public IActionResult SaveStudent([FromBody] Student savestudent)
        {
            if (string.IsNullOrWhiteSpace(savestudent.Name))
            {
                return BadRequest();
            }
            var response = _studentops.SaveStudentops(savestudent);
            return _responseHelper.CreateResponse(response);

        }

        [HttpDelete("{id}")]

        public IActionResult RemoveStudent([FromRoute] int id)
        {
            if (id < 1)
            {
                return BadRequest();
            }
            var response = _studentops.RemoveStudentops(id);
            return _responseHelper.CreateResponse(response);

        }
    }
}

