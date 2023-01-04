using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WestCoastEducation.web.ViewModels;

public class UserPostViewModel
{
    [Required(ErrorMessage = "Användarnamn är obligatoriskt")]
    [DisplayName("Användarnamn")]
    public string UserName { get; set; } = "";

    [Required(ErrorMessage = "Förnamn är obligatoriskt")]
    [DisplayName("Förnamn")]
    public string FirstName { get; set; } = "";

    [Required(ErrorMessage = "Efternamn är obligatoriskt")]
    [DisplayName("Efternamn")]
    public string LastName { get; set; } = "";

    [Required(ErrorMessage = "Email är obligatoriskt")]
    [DisplayName("Email")]
    public string Email { get; set; } = "";

    [Required(ErrorMessage = "Telefonnummer är obligatoriskt")]
    [DisplayName("Telefon")]
    public string Phone { get; set; } = "";

    [Required(ErrorMessage = "Lösenord är obligatoriskt")]
    [DisplayName("Temporärt lösenord")]
    public string Password { get; set; } = "";

    [Required(ErrorMessage = "kontotyp är obligatoriskt")]
    [DisplayName("Kontotyp")]
    public string TypeOfUser { get; set; } = "";
}
