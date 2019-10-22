using Microsoft.AspNetCore.Mvc;

namespace Freelance_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployerController: ControllerBase
    {
        private readonly EmployerService _employerService;

        public EmployerController(EmployerService employerService)
        {
            _employerService = employerService;
        }

        [HttpGet]
        public ActionResult<List<Employe>> get() =>
            _employerService.Get();

        [HttpGet("{id:length(24)}")]
        public ActionResult<Employe> Get(string id)
        {
            var employe = _employeService.Get(id);

            if (employe == null)
            {
                NotFound();
            }

            return employe;
        }
        
        HttpPost]
        public ActionResult<Employe> Create(Employe employe)
        {
            _employeService.Create(employe);

            return employe;
        }
        
        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Employe employein)
        {
            var emplpye = _employeService.Get(id);

            if (emplpye == null)
            {
                return NotFound();
            }

            _employeService.Update(id, employein);

            return NoContent();
        }
        
        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var employe = _employeService.Get(id);

            if (employe == null)
            {
                return NotFound();
            }

            _employeService.Remove(employe.Id);

            return NoContent();
        }
    }
}