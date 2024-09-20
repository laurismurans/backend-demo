using SearchBackend.Models;

namespace SearchBackend.Services
{
    public interface ICourseSearchService
    {
        IEnumerable<Course> Search(
            string? instituteName = null,
            string? courseName = null,
            string? category = null,
            string? deliveryMethod = null,
            string? location = null,
            string? language = null,
            DateTime? startDateMin = null,
            DateTime? startDateMax = null);

        IEnumerable<string> GetUniqueInstituteNames();
        IEnumerable<string> GetUniqueCourseNames();
        IEnumerable<string> GetUniqueCategories();
        IEnumerable<string> GetUniqueDeliveryMethods();
        IEnumerable<string> GetUniqueLocations();
        IEnumerable<string> GetUniqueLanguages();
        (DateTime MinDate, DateTime MaxDate) GetMinAndMaxStartDate();
    }
}