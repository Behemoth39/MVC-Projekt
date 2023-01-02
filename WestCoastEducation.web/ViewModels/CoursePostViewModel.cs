using System.ComponentModel.DataAnnotations;

namespace WestCoastEducation.web.ViewModels;

public class CoursePostViewModel
{
    [Required(ErrorMessage = "Kursnamn är obligatoriskt")]
    public string CourseName { get; set; } = "";

    [Required(ErrorMessage = "Kursnumer är obligatoriskt")]    
    public string CourseNumber { get; set; } = "";

    [Required(ErrorMessage = "Kurstitle är obligatoriskt")] 
    public string CourseTitle  { get; set; } = "";  

    [Required(ErrorMessage = "Kursstart är obligatoriskt")]  
    public string CourseStart { get; set; } = "";  

    [Required(ErrorMessage = "Kurslängd är obligatoriskt")]
    [Range(4, 80, ErrorMessage = "Kurslängd är obligatoriskt och måste minst vara 4 veckor")]
    public int? CourseLenght { get; set; } 
}
