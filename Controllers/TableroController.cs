using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using tl2_tp10_2023_RicardoRobinson1410.Models;
using tl2_tp10_2023_RicardoRobinson1410.ViewModels;
namespace tl2_tp10_2023_RicardoRobinson1410.Controllers;
public class TableroController : Controller
{
    private ITableroRepository _repositorioTablero;
    private IUsuarioRepository _repositorioUsuario;
    private readonly ILogger<TableroController> _logger;

    public TableroController(ILogger<TableroController> logger, ITableroRepository repositorioTablero, IUsuarioRepository repositorioUsuario)
    {
        _repositorioTablero=repositorioTablero;
        _repositorioUsuario=repositorioUsuario;
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var MiSesion = HttpContext.Session.GetString("Usuario");
        if (MiSesion != null)
        {
            var TipoSesion = (string?)HttpContext.Session.GetString("Rol");
            var id = (int)HttpContext.Session.GetInt32("Id");
            if (TipoSesion == "administrador")
            {
                return View(ListarTableroViewModel());
            }
            else
            {
                return View(ListarTableroViewModelPorUsuario(id));
            }


        }
        else
        {
            return RedirectToRoute(new { controller = "Login", action = "Index" });
        }

    }

    [HttpGet]
    public IActionResult CrearTablero()
    {
        var MiSesion = HttpContext.Session.GetString("Usuario");
        if (MiSesion != null)
        {
            return View(new CrearTableroViewModel(_repositorioUsuario.ListarUsuarios()));
        }
        else
        {
            return RedirectToRoute(new { controller = "Login", action = "Index" });
        }


    }

    [HttpPost]
    public IActionResult CrearTablero(CrearTableroViewModel tableroVM)
    {
        if (HttpContext.Session.GetString("Usuario") != null)
        {
            if (ModelState.IsValid)
            {
                var tablero = ConvertirCrearTableroVMaTablero(tableroVM);
                _repositorioTablero.CrearTablero(tablero);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("CrearTablero");
            }
        }else
        {
            return RedirectToRoute(new{Controller="Login", action="Index"});
        }
    }

    [HttpGet]
    public IActionResult ModificarTablero(int id)
    {
        var MiSesion = HttpContext.Session.GetString("Usuario");
        if (MiSesion != null)
        {
            var tablero = _repositorioTablero.ObtenerDetallesTablero(id);
            var usuarios = _repositorioUsuario.ListarUsuarios();
            var tablerovm = new ModificarTableroViewModel(tablero, usuarios);
            return View(tablerovm);
        }
        else
        {
            return RedirectToRoute(new { controller = "Login", action = "Index" });
        }

    }

    [HttpPost]
    public IActionResult ModificarTablero(ModificarTableroViewModel nuevo)
    {
        if(HttpContext.Session.GetString("Usuario")!=null)
        {
            if(ModelState.IsValid)
            {
                var tab = ConvertirModificarTableroVMaTablero(nuevo);
        _repositorioTablero.ModificarTablero(nuevo.Id, tab);
        return RedirectToAction("Index");
            }else
            {
                return RedirectToAction("ModificarTablero");
            }
        }else
        {
            return RedirectToRoute(new{Controller="Login", action="Index"});
        }
        
    }

    public IActionResult EliminarTablero(int id)
    {
        var MiSesion = HttpContext.Session.GetString("Usuario");
        if (MiSesion != null)
        {
            _repositorioTablero.EliminarTablero(id);
            return RedirectToAction("Index");
        }
        else
        {
            return RedirectToRoute(new { controller = "Login", action = "Index" });
        }

    }

    private List<IndexTableroViewModel> ListarTableroViewModel()
    {
        var ListaTablerosViewModel = new List<IndexTableroViewModel>();
        var listaTablero = _repositorioTablero.ListarTableros();
        foreach (var item in listaTablero)
        {
            Usuario? Usu = _repositorioUsuario.ObtenerDetallesUsuario(item.Id_Usuario_Propietario);
            string? nombre;
            if (Usu != null)
            {
                nombre = Usu.Nombre_De_Usuario;
            }
            else
            {
                nombre = null;
            }
            var TableroVM = new IndexTableroViewModel(item, nombre);
            ListaTablerosViewModel.Add(TableroVM);
        }
        return ListaTablerosViewModel;
    }

    private Tablero ConvertirCrearTableroVMaTablero(CrearTableroViewModel tvm)
    {
        var tab = new Tablero();
        tab.Id = tvm.Id;
        tab.Nombre = tvm.Nombre;
        tab.Descripcion = tvm.Descripcion;
        tab.Id_Usuario_Propietario = (int?)tvm.Id_Usuario_Propietario;
        return tab;
    }

    private Tablero ConvertirModificarTableroVMaTablero(ModificarTableroViewModel tvm)
    {
        var tab = new Tablero();
        tab.Id = tvm.Id;
        tab.Nombre = tvm.Nombre;
        tab.Descripcion = tvm.Descripcion;
        tab.Id_Usuario_Propietario = (int?)tvm.Id_Usuario_Propietario;
        return tab;
    }

    private List<IndexTableroViewModel> ListarTableroViewModelPorUsuario(int id)
    {
        var ListaTablerosViewModel = new List<IndexTableroViewModel>();
        var listaTablero = _repositorioTablero.ObtenerDetallesTableroPorUsuario(id);
        foreach (var item in listaTablero)
        {
            Usuario? Usu = _repositorioUsuario.ObtenerDetallesUsuario(item.Id_Usuario_Propietario);
            string? nombre;
            if (Usu != null)
            {
                nombre = Usu.Nombre_De_Usuario;
            }
            else
            {
                nombre = null;
            }
            var TableroVM = new IndexTableroViewModel(item, nombre);
            ListaTablerosViewModel.Add(TableroVM);
        }
        return ListaTablerosViewModel;
    }
}
