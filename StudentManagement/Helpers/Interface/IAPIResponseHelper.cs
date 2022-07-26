using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace StudentManagement.Repository.Helpers.Interface
{
    public interface IAPIResponseHelper
    {
        public IActionResult CreateResponse(dynamic result);
       
    }
}
