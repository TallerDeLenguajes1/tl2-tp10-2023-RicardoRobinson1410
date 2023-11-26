namespace tl2_tp10_2023_RicardoRobinson1410.Models;
public interface IloginRepository
{
        public Usuario? SeEncuentraUsuario(string Nombre, string Contrasenia, List<Usuario> listaUsuarios);
    
}