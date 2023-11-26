using tl2_tp10_2023_RicardoRobinson1410.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace tl2_tp10_2023_RicardoRobinson1410.ViewModels;

public class ModificarTareaViewModel
{
    [Required (ErrorMessage ="Este campo es necesario")]
    [Display (Name="Id Tablero")]
    public int Id {get;set;}
    public int? Id_Tablero {get; set;}
    [Required (ErrorMessage ="Este campo es necesario")]
    [Display (Name="Nombre Tablero")]
    public string Nombre {get; set;}
    [Required (ErrorMessage ="Este campo es necesario")]
    [Display (Name="Estado Tarea")]
    public estadosTarea Estado {get; set;}
    [Required (ErrorMessage ="Este campo es necesario")]
    [Display (Name="Descripcion Tarea")]
    public string Descripcion {get; set;}
    [Required (ErrorMessage ="Este campo es necesario")]
    [Display (Name="Color Tarea")]
    public string Color {get; set;}
    public int? Id_Usuario_Asignado {get; set;}
    public List<Usuario> Usuarios{get; set;}
    public List<Tablero> Tableros {get; set;}


        public ModificarTareaViewModel()
    {
        this.Id=0;
        this.Id_Tablero=null;
        this.Nombre="";
        this.Estado=estadosTarea.ideas;
        this.Descripcion="";
        this.Color="";
        this.Id_Usuario_Asignado=null;
        this.Usuarios=new List<Usuario>();
        this.Tableros=new List<Tablero>();
    }
    public ModificarTareaViewModel( Tarea tar, List<Usuario> ListaUsuarios, List<Tablero> ListaTableros)
    {
        this.Id=tar.Id;
        this.Id_Tablero=tar.Id_Tablero;
        this.Nombre=tar.Nombre;
        this.Estado=tar.Estado;
        this.Descripcion=tar.Descripcion;
        this.Color=tar.Color;
        this.Id_Usuario_Asignado=tar.Id_Usuario_Asignado;
        this.Usuarios=ListaUsuarios;
        this.Tableros=ListaTableros;
    }
}