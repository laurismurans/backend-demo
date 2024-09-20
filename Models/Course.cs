namespace SearchBackend.Models
{
    public class Course
    {
        public required string CourseId { get; set; }
        public required string InstituteName { get; set; }
        public required string CourseName { get; set; }
        public required string Category { get; set; }
        public required string DeliveryMethod { get; set; }
        public required string Location { get; set; }
        public string? Language { get; set; }
        public DateTime StartDate { get; set; }
    }
}