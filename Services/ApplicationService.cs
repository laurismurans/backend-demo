namespace SearchBackend.Services
{
    public class ApplicationService: IApplicationService
    {
        private readonly List<CourseApplyRequest> _applications = new List<CourseApplyRequest>();

        public IEnumerable<CourseApplyRequest> GetApplications()
        {
            return _applications;
        }

        public void Apply(CourseApplyRequest request)
        {
            _applications.Add(request);
        }
    }
}