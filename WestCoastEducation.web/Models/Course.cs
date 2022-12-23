namespace WestCoastEducation.web.Models
{
    public class Course
    {
        public Guid CourseId { get; set; } = Guid.NewGuid();
        public string CourseName { get; set; } = "";
        public string CourseNumer { get; set; } = "";
        public string EnrollmentLimit  { get; set; } = "";
        public string ParticipantList  { get; set; } = ""; // remake to actual list later
        public DateTime CourseStart { get; set; }
        public DateTime CourseEnd { get; set; }        
    }
}