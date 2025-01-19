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

        [HttpGet("{id:int}", Name = "GetStudentById")]
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

        [HttpPost]
        [Route("Create")]
        //api/student/create
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<StudentDTO> CreateStudent([FromBody]StudentDTO model)
        {
            if(model == null) return BadRequest();

            //if(model.AdmissionDate <= DateTime.Now)
            //{
            //    //1. Directly adding error message to modelstate
            //    //2. Using custom attribute
            //    ModelState.AddModelError("AdmisionDate Error", "Admision date must be grater than or equal to todyas date");
            //    return BadRequest(ModelState);
            //}

            int newId = CollageRepository.Students.LastOrDefault().Id + 1;
            Student student = new Student
            {
                Id = newId,
                StudentName = model.StudentName,
                Address = model.Address,
                Email = model.Email,
            };

            CollageRepository.Students.Add(student);

            model.Id = student.Id;

            return CreatedAtRoute("GetStudentById", new {id = model.Id}, model);
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
