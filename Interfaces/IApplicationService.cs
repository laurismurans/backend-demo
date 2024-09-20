namespace SearchBackend.Services
{
    public interface IApplicationService
    {
        IEnumerable<CourseApplyRequest> GetApplications();
        void Apply(CourseApplyRequest request);
    }
}