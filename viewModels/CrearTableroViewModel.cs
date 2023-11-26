using tl2_tp10_2023_RicardoRobinson1410.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace tl2_tp10_2023_RicardoRobinson1410.ViewModels;

public class CrearTableroViewModel
{
    public int Id { get; set; }
    [Required(ErrorMessage = "este campo es requerido")]
    [Display(Name = "Nombre de Tablero")]
    public string Nombre { get; set; }
    [Required(ErrorMessage = "este campo es requerido")]
    [Display(Name = "Nombre de Usuario")]
    public string Descripcion { get; set; }
    [Required(ErrorMessage = "este campo es requerido")]
    [Display(Name = "Nombre de Usuario")]
    public int? Id_Usuario_Propietario { get; set; }
    public string? NombreUsuario {get; set;}
    public List<Usuario> ListaUsuarios {get; set;}

    public CrearTableroViewModel ()
    {
        Id=0;
        Nombre="";
        Descripcion="";
        Id_Usuario_Propietario=null;
        NombreUsuario=null;
        this.ListaUsuarios=new List<Usuario>();
    }

public CrearTableroViewModel(Tablero tablero, List<Usuario> listaUsuarios)
    {
        this.Id=tablero.Id;
        this.Nombre=tablero.Nombre;
        this.Descripcion=tablero.Descripcion;
        this.Id_Usuario_Propietario=tablero.Id_Usuario_Propietario;
        this.ListaUsuarios=listaUsuarios;
        this.NombreUsuario=listaUsuarios.FirstOrDefault(l=>l.Id==this.Id_Usuario_Propietario).Nombre_De_Usuario;
    }

    public CrearTableroViewModel(List<Usuario> listaUsuarios)
    {
        Id=0;
        Nombre="";
        Descripcion="";
        Id_Usuario_Propietario=null;
        this.ListaUsuarios = listaUsuarios;
    }

}