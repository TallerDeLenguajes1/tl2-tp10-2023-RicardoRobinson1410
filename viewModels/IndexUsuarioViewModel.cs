using tl2_tp10_2023_RicardoRobinson1410.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace tl2_tp10_2023_RicardoRobinson1410.ViewModels;

public class IndexUsuarioViewModel
{
    public int Id {get; set;}

    [Display (Name= "Nombre de Usuario")]
    public string? Nombre {get; set;}

    [Display (Name= "Contraseña")]
    public string? Contrasenia {get; set;}

    [Display (Name= "Rol del Usuario")] 
    public rolesUsuario Rol {get; set;}

    public IndexUsuarioViewModel (Usuario usu)
    {
        this.Id=usu.Id;
        this.Nombre=usu.Nombre_De_Usuario;
        this.Contrasenia=usu.Contrasenia;
        this.Rol=usu.Rol;
    }

    public IndexUsuarioViewModel()
    {
        this.Id=0;
        this.Nombre="";
        this.Contrasenia="";
        this.Rol=rolesUsuario.administrador;
    }
}