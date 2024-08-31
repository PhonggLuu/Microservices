using TeacherService.Models;

namespace TeacherService.Service
{
	public class TeacherRepository : List<Teacher>, ITeacherRepository
	{
		private readonly List<Teacher> _teachers = SeedTeacher();

		private static List<Teacher> SeedTeacher()
		{
			var result = new List<Teacher>
			{
				new Teacher { Id = 1, Name = "Johnny", School = "Harvard" },
				new Teacher { Id = 2, Name = "HatSnow", School = "MIT" },
				new Teacher { Id = 3, Name = "Dickies", School = "Stanford" }
			};
			return result;
		}

		public List<Teacher> GetAll()
		{
			return _teachers;
		}

		public Teacher? Get(int id)
		{
			return _teachers.Find(s => s.Id == id);
		}
	}
}
