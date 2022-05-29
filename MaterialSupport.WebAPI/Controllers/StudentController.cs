using MaterialSupport.Core.CustomExceptions;
using MaterialSupport.Core.Dto;
using MaterialSupport.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MaterialSupport.WebAPI.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;

        private int UserId => int.Parse(User.Claims.Single(c => c.Type == ClaimTypes.NameIdentifier).Value);

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [Authorize(Roles = "Student")]
        [HttpGet("getstudent")]
        public async Task<IActionResult> GetStudent()
        {
            try
            {
                var result = await _studentService.GetStudent(UserId);
                return Ok(result);
            }
            catch (StudentNotFoundException e)
            {
                return StatusCode(404, e.Message);
            }
        }

        [HttpPut("editcontacts")]
        public async Task<IActionResult> EditContacts([FromBody] ContactsDto contacts)
        {
            try
            {
                var result = await _studentService.EditContacts(UserId, contacts);
                return Ok(result);
            }
            catch (StudentNotFoundException e)
            {
                return StatusCode(404, e.Message);
            }
        }
    }
}
