using System.Collections.Generic;
using Freelance_Api.Models;
using Freelance_Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Freelance_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly StudentService _studentService;
        public StudentController(StudentService studentService)
        {
            _studentService = studentService;
        }
        [HttpGet]
        public ActionResult<List<Student>> Get() =>
            _studentService.Get();

        [HttpGet("{id:length(24)}", Name = "GetBook")]
        public ActionResult<Student> Get(string id)
        {
            var student = _studentService.Get(id);

            if (student == null)
            {
                return NotFound();
            }

            return student;
        }

        [HttpPost]
        public ActionResult<Student> Create(Student student)
        {
            _studentService.Create(student);

            return  student;
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Student studentin)
        {
            var student = _studentService.Get(id);

            if (student == null)
            {
                return NotFound();
            }

            _studentService.Update(id, studentin);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var student = _studentService.Get(id);

            if (student == null)
            {
                return NotFound();
            }

            _studentService.Remove(student.Id);

            return NoContent();
        }
    }
}