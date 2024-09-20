using Microsoft.AspNetCore.Mvc;
using SearchBackend.Services;

namespace SearchBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseFilterController : ControllerBase
    {
        private readonly CourseSearchService _courseSearchService;

        public CourseFilterController(CourseSearchService courseSearchService)
        {
            _courseSearchService = courseSearchService;
        }

        [HttpGet("categories")]
        public IActionResult GetUniqueCategories()
        {
            var uniqueCategories = _courseSearchService.GetUniqueCategories();
            return Ok(uniqueCategories);
        }

        [HttpGet("institute-names")]
        public IActionResult GetUniqueInstituteNames()
        {
            var uniqueCategories = _courseSearchService.GetUniqueInstituteNames();
            return Ok(uniqueCategories);
        }

        [HttpGet("course-names")]
        public IActionResult GetUniqueCourseNames()
        {
            var uniqueCategories = _courseSearchService.GetUniqueCourseNames();
            return Ok(uniqueCategories);
        }

        [HttpGet("delivery-methods")]
        public IActionResult GetUniqueDeliveryMethods()
        {
            var uniqueCategories = _courseSearchService.GetUniqueDeliveryMethods();
            return Ok(uniqueCategories);
        }

        [HttpGet("locations")]
        public IActionResult GetUniqueLocations()
        {
            var uniqueCategories = _courseSearchService.GetUniqueLocations();
            return Ok(uniqueCategories);
        }

        [HttpGet("languages")]
        public IActionResult GetUniqueLanguages()
        {
            var uniqueCategories = _courseSearchService.GetUniqueLanguages();
            return Ok(uniqueCategories);
        }

        [HttpGet("start-date-range")]
        public IActionResult GetMinAndMaxStartDate()
        {
            try
            {
                var (minDate, maxDate) = _courseSearchService.GetMinAndMaxStartDate();

                return Ok(new
                {
                    StartDateMin = minDate.ToString("yyyy-MM-dd"),
                    StartDateMax = maxDate.ToString("yyyy-MM-dd")
                });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
