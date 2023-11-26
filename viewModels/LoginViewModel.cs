using tl2_tp10_2023_RicardoRobinson1410.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace tl2_tp10_2023_RicardoRobinson1410.ViewModels;

public class LoginViewModel
{
    [Required (ErrorMessage ="Este campo es requerido")]
    [Display (Name = "Nombre de Usuario")]
    public string Nombre {get; set;}

    [Required (ErrorMessage = "Este campo es requerido")]
    [Display (Name = "Contraseña")]
    public string Contrasenia {get; set;}

}