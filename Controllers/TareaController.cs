using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using tl2_tp10_2023_RicardoRobinson1410.Models;
using tl2_tp10_2023_RicardoRobinson1410.ViewModels;
namespace tl2_tp10_2023_RicardoRobinson1410.Controllers;
public class TareaController : Controller
{
    private readonly ITareaRepository _repositorioTarea;
    private readonly ITableroRepository _repositorioTablero;
    private IUsuarioRepository _repositorioUsuario;
    private readonly ILogger<TareaController> _logger;

    public TareaController(ILogger<TareaController> logger, ITareaRepository repositorioTarea, ITableroRepository repositorioTablero, IUsuarioRepository repositorioUsuario)
    {
        _repositorioTarea = repositorioTarea;
        _repositorioTablero = repositorioTablero;
        _repositorioUsuario = repositorioUsuario;
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var MiSesion = HttpContext.Session.GetString("Usuario");
        if (MiSesion != null)
        {
            return View(ListarTareasIndex());
        }
        else
        {
            return RedirectToRoute(new { controller = "Login", action = "Index" });
        }

    }

    [HttpGet]
    public IActionResult CrearTarea()
    {
        var MiSesion = HttpContext.Session.GetString("Usuario");
        if (MiSesion != null)
        {
            return (View(CrearListaCrearTareaViewModel()));
        }
        else
        {
            return RedirectToRoute(new { controller = "Login", action = "Index" });
        }

    }

    [HttpPost]
    public IActionResult CrearTarea(CrearTareaViewModel tarvm)
    {
        if (HttpContext.Session.GetString("Usuario") != null)
        {
            if (ModelState.IsValid)
            {
                _repositorioTarea.CrearTarea(transformarCrearTareaViewModelATarea(tarvm));
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("CrearTarea");
            }
        }
        else
        {
            return RedirectToRoute(new { Controller = "Login", Action = "Index" });
        }
    }

    [HttpGet]
    public IActionResult ModificarTarea(int id)
    {
        var MiSesion = HttpContext.Session.GetString("Usuario");
        if (MiSesion != null)
        {
            return View(CrearListaModificarTareaViewModel(id));
        }
        else
        {
            return RedirectToRoute(new { controller = "Login", action = "Index" });
        }

    }

    [HttpPost]
    public IActionResult ModificarTarea(ModificarTareaViewModel tarvm)
    {
                if (HttpContext.Session.GetString("Usuario") != null)
        {
            if (ModelState.IsValid)
            {
                       var tar = transformarModificarTareaViewModelATarea(tarvm);
                         _repositorioTarea.ModificarTarea(tar.Id, tar);
                         return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("ModificarTarea");
            }
        }
        else
        {
            return RedirectToRoute(new { Controller = "Login", Action = "Index" });
        }
    }

    public IActionResult EliminarTarea(int id)
    {
        var MiSesion = HttpContext.Session.GetString("Usuario");
        if (MiSesion != null)
        {
            _repositorioTarea.EliminarTarea(id);
            return RedirectToAction("Index");
        }
        else
        {
            return RedirectToRoute(new { controller = "Login", action = "Index" });
        }

    }

    private List<IndexTareaViewModel> ListarTareasIndex()
    {
        var listaTareasIndex = new List<IndexTareaViewModel>();
        var listaTareas = _repositorioTarea.ListarTareas();
        foreach (var item in listaTareas)
        {
            Usuario? usu = _repositorioUsuario.ObtenerDetallesUsuario(item.Id_Usuario_Asignado);
            Tablero? tab = _repositorioTablero.ObtenerDetallesTablero(item.Id_Tablero);
            string? nombreUsuario;
            string? nombreTablero;
            if (usu != null)
            {
                nombreUsuario = usu.Nombre_De_Usuario;
            }
            else
            {
                nombreUsuario = null;
            }
            if (tab != null)
            {
                nombreTablero = tab.Nombre;
            }
            else
            {
                nombreTablero = null;
            }
            var tarvm = new IndexTareaViewModel(item, nombreUsuario, nombreTablero);
            listaTareasIndex.Add(tarvm);
        }
        return listaTareasIndex;
    }

    private CrearTareaViewModel CrearListaCrearTareaViewModel()
    {
        var listaUsuarios = _repositorioUsuario.ListarUsuarios();
        var ListaTableros = _repositorioTablero.ListarTableros();

        return new CrearTareaViewModel(listaUsuarios, ListaTableros);
    }

    private ModificarTareaViewModel CrearListaModificarTareaViewModel(int id)
    {
        var tarea = _repositorioTarea.ObtenerDetallesTarea(id);
        var listaUsuarios = _repositorioUsuario.ListarUsuarios();
        var ListaTableros = _repositorioTablero.ListarTableros();

        return new ModificarTareaViewModel(tarea, listaUsuarios, ListaTableros);
    }

    private Tarea transformarCrearTareaViewModelATarea(CrearTareaViewModel tar)
    {
        var tarea = new Tarea();
        tarea.Id = tar.Id;
        tarea.Nombre = tar.Nombre;
        tarea.Descripcion = tar.Descripcion;
        tarea.Color = tar.Color;
        tarea.Estado = tar.Estado;
        tarea.Id_Tablero = tar.Id_Tablero;
        tarea.Id_Usuario_Asignado = tar.Id_Usuario_Asignado;
        return tarea;
    }

    private Tarea transformarModificarTareaViewModelATarea(ModificarTareaViewModel tar)
    {
        var tarea = new Tarea();
        tarea.Id = tar.Id;
        tarea.Nombre = tar.Nombre;
        tarea.Descripcion = tar.Descripcion;
        tarea.Color = tar.Color;
        tarea.Estado = tar.Estado;
        tarea.Id_Tablero = tar.Id_Tablero;
        tarea.Id_Usuario_Asignado = tar.Id_Usuario_Asignado;
        return tarea;
    }
}
