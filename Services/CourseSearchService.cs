using SearchBackend.Models;

namespace SearchBackend.Services
{
    public class CourseSearchService : ICourseSearchService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseSearchService(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public IEnumerable<Course> Search(
            string? instituteName = null,
            string? courseName = null,
            string? category = null,
            string? deliveryMethod = null,
            string? location = null,
            string? language = null,
            DateTime? startDateMin = null,
            DateTime? startDateMax = null)
        {
            IEnumerable<Course> query = _courseRepository.GetCourses();

            if (!string.IsNullOrEmpty(instituteName))
                query = query.Where(c => c.InstituteName.Contains(instituteName, StringComparison.OrdinalIgnoreCase));

            if (!string.IsNullOrEmpty(courseName))
                query = query.Where(c => c.CourseName.Contains(courseName, StringComparison.OrdinalIgnoreCase));

            if (!string.IsNullOrEmpty(category))
                query = query.Where(c => c.Category.Contains(category, StringComparison.OrdinalIgnoreCase));

            if (!string.IsNullOrEmpty(deliveryMethod))
                query = query.Where(c => c.DeliveryMethod.Contains(deliveryMethod, StringComparison.OrdinalIgnoreCase));

            if (!string.IsNullOrEmpty(location))
                query = query.Where(c => c.Location.Contains(location, StringComparison.OrdinalIgnoreCase));

            if (!string.IsNullOrEmpty(language))
                query = query.Where(c => c.Language!.Contains(language, StringComparison.OrdinalIgnoreCase));

            if (startDateMin.HasValue) {
                query = query.Where(c => c.StartDate.Date >= startDateMin.Value.Date);

                if (startDateMax.HasValue)
                    query = query.Where(c => c.StartDate.Date <= startDateMax.Value.Date);
            }

            return query.OrderBy(c => c.StartDate);
        }

        public IEnumerable<string> GetUniqueInstituteNames()
        {
            
            return _courseRepository.GetCourses().Select(c => c.InstituteName).Distinct().OrderBy(value => value);
        }

        public IEnumerable<string> GetUniqueCourseNames()
        {
            return _courseRepository.GetCourses().Select(c => c.CourseName.Trim()).Distinct().OrderBy(value => value);
        }
        public IEnumerable<string> GetUniqueCategories()
        {
            return _courseRepository.GetCourses().Select(c => c.Category).Distinct().OrderBy(value => value);
        }

        public IEnumerable<string> GetUniqueDeliveryMethods()
        {
            return _courseRepository.GetCourses().Select(c => c.DeliveryMethod).Distinct().OrderBy(value => value);
        }

        public IEnumerable<string> GetUniqueLocations()
        {
            return _courseRepository.GetCourses().Select(c => c.Location).Distinct().OrderBy(value => value);
        }

        public IEnumerable<string> GetUniqueLanguages()
        {
            return _courseRepository.GetCourses().Where(c => c.Language != "NULL").Select(c => c.Language!).Distinct().OrderBy(value => value);
        }

        public (DateTime MinDate, DateTime MaxDate) GetMinAndMaxStartDate()
        {
            IEnumerable<Course> courses = _courseRepository.GetCourses();

            if (!courses.Any())
                throw new InvalidOperationException("No courses available to calculate min/max dates.");

            var minDate = courses.Min(c => c.StartDate);
            var maxDate = courses.Max(c => c.StartDate);

            return (minDate, maxDate);
        }

    }
}
