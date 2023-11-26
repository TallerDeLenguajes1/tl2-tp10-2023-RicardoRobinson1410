namespace tl2_tp10_2023_RicardoRobinson1410.Models;
public enum rolesUsuario
{
    administrador=0,
    operador=1

}
public class Usuario
{
    private int id;
    private string nombre_De_Usuario;
    private rolesUsuario rol;
    private string contrasenia;


    public Usuario(int ID, string NOMBRE, rolesUsuario ROL, string CONTRASENIA)
    {
        this.id=ID;
        this.nombre_De_Usuario=NOMBRE;
        this.rol=ROL;
        this.contrasenia=CONTRASENIA;
    }

    public Usuario()
    {
        this.id=0;
        this.nombre_De_Usuario="";
        this.rol=rolesUsuario.administrador;
        this.contrasenia="";
    }

    public int Id { get => id; set => id = value; }
    public string Nombre_De_Usuario { get => nombre_De_Usuario; set => nombre_De_Usuario = value; }
    internal rolesUsuario Rol { get => rol; set => rol = value; }
    public string Contrasenia { get => contrasenia; set => contrasenia = value; }
}