using SearchBackend.Models;

namespace SearchBackend.Services
{
    public interface ICourseRepository
    {
        IReadOnlyCollection<Course> GetCourses();
    }
}
