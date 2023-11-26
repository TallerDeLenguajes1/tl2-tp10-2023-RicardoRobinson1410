using tl2_tp10_2023_RicardoRobinson1410.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace tl2_tp10_2023_RicardoRobinson1410.ViewModels;

public class IndexTareaViewModel
{
    public int Id {get;set;}
    public int? Id_Tablero {get; set;}
    [Display(Name ="Nombre Tarea")]
    public string Nombre {get; set;}
    [Display(Name ="Estado tarea")]
    public estadosTarea Estado {get; set;}

    [Display(Name ="Descripcion Tarea")]
    public string Descripcion {get; set;}
    [Display(Name ="Color Tarea")]
    public string Color {get; set;}
    public int? Id_Usuario_Asignado {get; set;}
    public string? NombreUsuario{get; set;}
    public string? NombreTablero {get; set;}

    public IndexTareaViewModel()
    {
        Id=0;
        this.Id_Tablero=null;
        this.Nombre="";
        this.Estado=estadosTarea.ideas;
        this.Descripcion="";
        this.Color="";
        this.Id_Usuario_Asignado=null;
        this.NombreUsuario=null;
        this.NombreTablero=null;
    }

    public IndexTareaViewModel(Tarea tar, string? nombreUsu, string? nombreTab)
    {
        this.Id=tar.Id;
        this.Id_Tablero=tar.Id_Tablero;
        this.Nombre=tar.Nombre;
        this.Estado=tar.Estado;
        this.Descripcion=tar.Descripcion;
        this.Color=tar.Color;
        this.Id_Usuario_Asignado=tar.Id_Usuario_Asignado;
        this.NombreUsuario=nombreUsu;
        this.NombreTablero=nombreTab;
    }
}