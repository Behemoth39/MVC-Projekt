namespace WestCoastEducation.web.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; } = "";
        public string CourseNumer { get; set; } = "";
        public string EnrollmentLimit  { get; set; } = "";
        public string ParticipantList  { get; set; } = ""; 
        public DateTime CourseStart { get; set; }
        public DateTime CourseEnd { get; set; }        
    }
}