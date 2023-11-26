using tl2_tp10_2023_RicardoRobinson1410.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace tl2_tp10_2023_RicardoRobinson1410.ViewModels;

public class CrearUsuarioViewModel
{
    public int Id {get; set;}

    [Required (ErrorMessage ="este campo es requerido")]
    [Display (Name= "Nombre de Usuario")]
    public string? Nombre {get; set;}

    [Required (ErrorMessage ="este campo es requerido")]
    [Display (Name= "Contraseña")]
    public string? Contrasenia {get; set;}

    [Required (ErrorMessage ="este campo es requerido")]
    [Display (Name= "Rol del Usuario")] 
    public rolesUsuario Rol {get; set;}

    public CrearUsuarioViewModel (Usuario usu)
    {
        this.Id=usu.Id;
        this.Nombre=usu.Nombre_De_Usuario;
        this.Contrasenia=usu.Contrasenia;
        this.Rol=usu.Rol;
    }

    public CrearUsuarioViewModel()
    {
        this.Id=0;
        this.Nombre="";
        this.Contrasenia="";
        this.Rol=rolesUsuario.administrador;
    }
}