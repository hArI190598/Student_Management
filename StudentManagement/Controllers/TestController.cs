using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace StudentManagement.Controllers
{
    [Route("api/[controller]") ]
    public class TestController
    {
        [HttpGet]
        public string Display()
        {
            return "Hello World";

        }
    }
}
