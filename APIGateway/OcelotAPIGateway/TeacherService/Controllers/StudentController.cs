using Microsoft.AspNetCore.Mvc;
using TeacherService.Service;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TeacherService.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TeacherController : ControllerBase
	{
		private readonly ITeacherRepository _teacherRepository;
		public TeacherController(ITeacherRepository teacherRepository)
		{
			_teacherRepository = teacherRepository;
		}
		// GET: api/<TeacherController>
		[HttpGet]
		public IActionResult Get()
		{
			return Ok(_teacherRepository.GetAll());
		}

		// GET api/<TeacherController>/5
		[HttpGet("{id}")]
		public IActionResult Get(int id)
		{
			var teacher = _teacherRepository.Get(id);
			if (teacher is null)
				return NotFound();
			return Ok(teacher);
		}
	}
}
