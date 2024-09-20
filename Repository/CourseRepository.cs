using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using SearchBackend.Models;

namespace SearchBackend.Services
{
    public class CourseRepository: ICourseRepository
    {
        private readonly IReadOnlyCollection<Course> _courses;

        public CourseRepository(string filePath)
        {
            _courses = new List<Course>(LoadCoursesFromFile(filePath));
        }

        private IEnumerable<Course> LoadCoursesFromFile(string filePath)
        {
            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                Delimiter = ";"
            }))
            {
                return csv.GetRecords<Course>().ToList();
            }
        }

        public IReadOnlyCollection<Course> GetCourses()
        {
            return _courses;
        }
    }
}
