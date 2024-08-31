using StudentService.Models;

namespace StudentService.Service
{
	public class StudentRepository : List<Student>, IStudentRepository
	{
		private readonly List<Student> _students = SeedStudent();

		private static List<Student> SeedStudent()
		{
			var result = new List<Student>
			{
				new Student { Id = 1, Name = "John", School = "Harvard" },
				new Student { Id = 2, Name = "Jane", School = "MIT" },
				new Student { Id = 3, Name = "Doe", School = "Stanford" }
			};
			return result;
		}

		public List<Student> GetAll()
		{
			return _students;
		}

		public Student? Get(int id)
		{
			return _students.Find(s => s.Id == id);
		}
	}
}
