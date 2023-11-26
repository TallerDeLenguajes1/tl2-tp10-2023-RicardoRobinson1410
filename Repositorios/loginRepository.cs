namespace tl2_tp10_2023_RicardoRobinson1410.Models;
using Microsoft.AspNetCore.Mvc;
public class LoginRepository : IloginRepository
{
    public Usuario? SeEncuentraUsuario(string Nombre, string Contrasenia, List<Usuario> listaUsuarios)
    {
        Usuario usucorrecto = listaUsuarios.FirstOrDefault(l => l.Nombre_De_Usuario == Nombre && l.Contrasenia == Contrasenia);
        return usucorrecto;
    }
}