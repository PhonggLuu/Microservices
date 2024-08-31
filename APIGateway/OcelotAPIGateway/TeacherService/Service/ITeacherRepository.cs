using TeacherService.Models;

namespace TeacherService.Service
{
	public interface ITeacherRepository
	{
		List<Teacher> GetAll();
		Teacher? Get(int id);
	}
}
