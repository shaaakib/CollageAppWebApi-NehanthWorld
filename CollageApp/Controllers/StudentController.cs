using CollageApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CollageApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Student>> GetStudentName()
        {
            return Ok(CollageRepository.Students);
        }

        [HttpGet("{id:int}")]
        public ActionResult<Student> GetStudentById(int id)
        {
            if(id <= 0) return BadRequest();

            var student = CollageRepository.Students.Where(n => n.Id == id).FirstOrDefault();

            if(student == null) return NotFound($"The student with id {id} not found");  
            
            return Ok(student);
        }

        [HttpGet("{name:alpha}")]
        public ActionResult<Student> GetStudentByName(string name)
        {
            if (string.IsNullOrEmpty(name)) return BadRequest();

            var student = CollageRepository.Students.Where(n => n.StudentName == name).FirstOrDefault();

            if (student == null) return NotFound($"The student with id {name} not found");

            return Ok(student);
        }

        [HttpDelete("{id}")]
        public ActionResult<bool> StudentByDelete(int id)
        {
            if (id <= 0) return BadRequest();

            var student = CollageRepository.Students.Where(n => n.Id == id).FirstOrDefault();

            if (student == null) return NotFound($"The student with id {id} not found");

            CollageRepository.Students.Remove(student);
            return Ok(true);
        }
    }
}
