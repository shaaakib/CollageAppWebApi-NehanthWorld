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
        public ActionResult<IEnumerable<StudentDTO>> GetStudentName()
        {
            //var students = new List<StudentDTO>();

            //foreach (var item in CollageRepository.Students)
            //{
            //    StudentDTO obj = new StudentDTO()
            //    {
            //        Id = item.Id,
            //        StudentName = item.StudentName,
            //        Address = item.Address,
            //        Email = item.Email,
            //    };
            //    student.Add(obj);
            //}

            var students = CollageRepository.Students.Select(s => new StudentDTO()
            {
                Id = s.Id,
                StudentName = s.StudentName,
                Address = s.Address,
                Email = s.Email,
            });

            return Ok(students);
        }

        [HttpGet("{id:int}")]
        public ActionResult<StudentDTO> GetStudentById(int id)
        {
            if(id <= 0) return BadRequest();

            var student = CollageRepository.Students.Where(n => n.Id == id).FirstOrDefault();

            if(student == null) return NotFound($"The student with id {id} not found");

            var studentDTO = new StudentDTO()
            {
                Id = student.Id,
                StudentName = student.StudentName,
                Address = student.Address,
                Email = student.Email,
            };
            
            return Ok(studentDTO);
        }

        [HttpGet("{name:alpha}")]
        public ActionResult<StudentDTO> GetStudentByName(string name)
        {
            if (string.IsNullOrEmpty(name)) return BadRequest();

            var student = CollageRepository.Students.Where(n => n.StudentName == name).FirstOrDefault();

            if (student == null) return NotFound($"The student with id {name} not found");

            var studentDTO = new StudentDTO()
            {
                Id = student.Id,
                StudentName = student.StudentName,
                Address = student.Address,
                Email = student.Email,
            };

            return Ok(studentDTO);
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
