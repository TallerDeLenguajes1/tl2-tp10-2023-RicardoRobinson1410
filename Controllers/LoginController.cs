using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Http;
using tl2_tp10_2023_RicardoRobinson1410.Models;
using tl2_tp10_2023_RicardoRobinson1410.ViewModels;
namespace tl2_tp10_2023_RicardoRobinson1410.Controllers;

public class LoginController : Controller
{
    private readonly IloginRepository _repositorioLogin;
    private readonly IUsuarioRepository _repositorioUsuario;

    public LoginController(IUsuarioRepository repositorioUsuario, IloginRepository repositorioLogin)
    {
        _repositorioUsuario=repositorioUsuario;
        _repositorioLogin=repositorioLogin;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View(new LoginViewModel());
    }

    [HttpPost]
    public IActionResult Login(LoginViewModel log)
    {
        if (ModelState.IsValid)
        {
            var listaUsuarios = _repositorioUsuario.ListarUsuarios();
            var usuCorrecto = _repositorioLogin.SeEncuentraUsuario(log.Nombre, log.Contrasenia, listaUsuarios);
            if (usuCorrecto != null)
            {
                LogearUsuario(usuCorrecto);
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        else{
            return RedirectToAction("Index");
        }

    }
    private void LogearUsuario(Usuario usu)
    {
        HttpContext.Session.SetInt32("Id", usu.Id);
        HttpContext.Session.SetString("Usuario", usu.Nombre_De_Usuario);
        HttpContext.Session.SetString("Rol", usu.Rol.ToString());
        HttpContext.Session.SetString("Contrasenia", usu.Contrasenia);
    }
}