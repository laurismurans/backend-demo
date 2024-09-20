using Microsoft.AspNetCore.Mvc;
using SearchBackend.Models;
using SearchBackend.Services;

namespace SearchBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly CourseSearchService _courseSearchService;
        private readonly ApplicationService _applicationService;

        public CourseController(CourseSearchService courseSearchService, ApplicationService applicationService)
        {
            _courseSearchService = courseSearchService;
            _applicationService = applicationService;
        }

        [HttpGet("search")]
        public IActionResult SearchCourses(
            [FromQuery] string? instituteName,
            [FromQuery] string? courseName,
            [FromQuery] string? category,
            [FromQuery] string? deliveryMethod,
            [FromQuery] string? location,
            [FromQuery] string? language,
            [FromQuery] DateTime? startDateMin,
            [FromQuery] DateTime? startDateMax
            )
        {
            var results = _courseSearchService.Search(
                instituteName,
                courseName,
                category,
                deliveryMethod,
                location,
                language,
                startDateMin,
                startDateMax);

            if (results == null)
            {
                return Ok(new List<Course>());
            }

            return Ok(results);
        }

        [HttpPost("apply")]
        public IActionResult Apply([FromBody] CourseApplyRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _applicationService.Apply(request);

            return Ok(new { message = "Application successful!", status = 200 });
        }

        [HttpGet("applications")]
        public IActionResult GetApplications()
        {
            return Ok(_applicationService.GetApplications());
        }
    }

}
