using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BochaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAllStudents()
        {
            string[] studenNames = new string[] { "Juan", "A", "L", "V","A", };

            return Ok(studenNames);
        }

    }
}
