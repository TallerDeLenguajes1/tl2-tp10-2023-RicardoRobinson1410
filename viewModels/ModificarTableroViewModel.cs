using tl2_tp10_2023_RicardoRobinson1410.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace tl2_tp10_2023_RicardoRobinson1410.ViewModels;

public class ModificarTableroViewModel
{
    public int Id { get; set; }
    [Required(ErrorMessage = "este campo es requerido")]
    [Display(Name = "Nombre de Tablero")]
    public string Nombre { get; set; }
    [Required(ErrorMessage = "este campo es requerido")]
    [Display(Name = "Nombre de Usuario")]
    public string Descripcion { get; set; }
    public int? Id_Usuario_Propietario { get; set; }
    public string? NombreUsuario {get; set;}
    public List<Usuario> ListaUsuarios {get; set;}

    public ModificarTableroViewModel ()
    {
        Id=0;
        Nombre="";
        Descripcion="";
        Id_Usuario_Propietario=null;
        NombreUsuario=null;
        this.ListaUsuarios=new List<Usuario>();
    }

public ModificarTableroViewModel(Tablero tablero, List<Usuario> listaUsuarios)
    {
        this.Id=tablero.Id;
        this.Nombre=tablero.Nombre;
        this.Descripcion=tablero.Descripcion;
        this.Id_Usuario_Propietario=tablero.Id_Usuario_Propietario;
        this.ListaUsuarios=listaUsuarios;
        Usuario? usu=listaUsuarios.FirstOrDefault(l=>l.Id==this.Id_Usuario_Propietario);
        string? name;
        if(usu!=null)
        {
            name=usu.Nombre_De_Usuario;   
        }else
        {
            name=null;
        }
        this.NombreUsuario=name;
    }

    public ModificarTableroViewModel(List<Usuario> listaUsuarios)
    {
        Id=0;
        Nombre="";
        Descripcion="";
        Id_Usuario_Propietario=null;
        this.ListaUsuarios = listaUsuarios;
    }

}