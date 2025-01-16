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
        public IEnumerable<Student> GetStudentName()
        {
            return CollageRepository.Students;
        }

        [HttpGet("{id:int}")]
        public Student GetStudentById(int id)
        {
            return CollageRepository.Students.Where(n => n.Id == id).FirstOrDefault();
        }

        [HttpGet("{name:alpha}")]
        public Student GetStudentByName(string name)
        {
            return CollageRepository.Students.Where(n => n.StudentName == name).FirstOrDefault();
        }

        [HttpDelete("{id}")]
        public bool StudentByDelete(int id)
        {
            var student =  CollageRepository.Students.Where(n => n.Id == id).FirstOrDefault();
            CollageRepository.Students.Remove(student);
            return true;
        }
    }
}
