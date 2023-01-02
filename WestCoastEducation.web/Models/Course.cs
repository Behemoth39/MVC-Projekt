namespace WestCoastEducation.web.Models;

public class Course
{
    public int CourseId { get; set; }
    public string CourseName { get; set; } = "";
    public string CourseNumber { get; set; } = "";
    public string CourseTitle  { get; set; } = "";    
    public DateOnly CourseStart { get; set; } 
    public int CourseLenght { get; set; } 
}
