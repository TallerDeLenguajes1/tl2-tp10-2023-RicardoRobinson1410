using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using tl2_tp10_2023_RicardoRobinson1410.Models;
using tl2_tp10_2023_RicardoRobinson1410.ViewModels;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Http;
namespace tl2_tp10_2023_RicardoRobinson1410.Controllers;

public class UsuarioController : Controller
{
    private readonly IUsuarioRepository _repositorioUsuario;
    private readonly ILogger<UsuarioController> _logger;
    
    public UsuarioController(ILogger<UsuarioController> logger, IUsuarioRepository repositorioUsuario)
    {
        _repositorioUsuario=repositorioUsuario;
        _logger = logger;
    }

    [HttpGet]
    public IActionResult Index()
    {
        var MiSesion = (string)HttpContext.Session.GetString("Usuario");
        if (MiSesion != null)
        {
            var usuarios = _repositorioUsuario.ListarUsuarios();
            var usuariosViewModel = new List<IndexUsuarioViewModel>();
            foreach (var usu in usuarios)
            {
                var usuModel = new IndexUsuarioViewModel(usu);
                usuariosViewModel.Add(usuModel);
            }
            return View(usuariosViewModel);
        }
        else
        {
            return RedirectToRoute(new { controller = "Login", action = "Index" });
        }

    }

    [HttpGet]
    public IActionResult CrearUsuario()
    {
        var MiSesion = (string)HttpContext.Session.GetString("Usuario");
        if (MiSesion != null)
        {
            return View(new CrearUsuarioViewModel());
        }
        else
        {
            return RedirectToRoute(new { controller = "Login", action = "Index" });
        }

    }
    [HttpPost]
    public IActionResult CrearUsuario(CrearUsuarioViewModel usuarioViewModel)
    {
        if (HttpContext.Session.GetString("Usuario") != null)
        {
            if (ModelState.IsValid)
            {
                var usu = ConvertirCrearUsuarioViewModelAUsuario(usuarioViewModel);
                _repositorioUsuario.CrearUsuario(usu);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("CrearUsuario");
            }
        }
        else
        {
            return RedirectToRoute(new { Controller = "Login", action = "Index" });
        }
    }
    [HttpGet]
    public IActionResult ModificarUsuario(int id)
    {
        var MiSesion = (string)HttpContext.Session.GetString("Usuario");
        if (MiSesion != null)
        {
            var usuvm = new ModificarUsuarioViewModel(_repositorioUsuario.ObtenerDetallesUsuario(id));
            return View(usuvm);
        }
        else
        {
            return RedirectToRoute(new { controller = "Login", action = "Index" });
        }

    }
    [HttpPost]
    public IActionResult ModificarUsuario(ModificarUsuarioViewModel usuvm)
    {
        if (HttpContext.Session.GetString("Usuario") != null)
        {
            if (ModelState.IsValid)
            {
                var usu = ConvertirModificarUsuarioViewModelAUsuario(usuvm);
                _repositorioUsuario.ModificarUsuario(usu, usu);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("ModificarUsuario");
            }
        }
        else
        {
            return RedirectToRoute(new { Controller = "Login", action = "Index" });
        }

    }

    public IActionResult EliminarUsuario(int id)
    {
        var MiSesion = HttpContext.Session.GetString("Usuario");
        if (MiSesion != null)
        {
            _repositorioUsuario.EliminarUsuario(id);
            return RedirectToAction("Index");
        }
        else
        {
            return RedirectToRoute(new { Controller = "Login", action = "Index" });
        }

    }

    private Usuario ConvertirCrearUsuarioViewModelAUsuario(CrearUsuarioViewModel usuvm)
    {
        var usu = new Usuario();
        usu.Id = usuvm.Id;
        usu.Nombre_De_Usuario = usuvm.Nombre;
        usu.Contrasenia = usuvm.Contrasenia;
        usu.Rol = usuvm.Rol;
        return usu;
    }

    private Usuario ConvertirModificarUsuarioViewModelAUsuario(ModificarUsuarioViewModel usuvm)
    {
        var usu = new Usuario();
        usu.Id = usuvm.Id;
        usu.Nombre_De_Usuario = usuvm.Nombre;
        usu.Contrasenia = usuvm.Contrasenia;
        usu.Rol = usuvm.Rol;
        return usu;
    }

}
