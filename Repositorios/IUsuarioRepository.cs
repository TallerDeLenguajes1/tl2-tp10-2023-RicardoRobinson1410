namespace tl2_tp10_2023_RicardoRobinson1410.Models;
using System.Data.SQLite;
public interface IUsuarioRepository
{
    public bool CrearUsuario(Usuario usu);
    public bool ModificarUsuario(Usuario usu1, Usuario usuNuevo);
    public List<Usuario> ListarUsuarios();
    public Usuario? ObtenerDetallesUsuario(int? id);
    public bool EliminarUsuario(int id);
}