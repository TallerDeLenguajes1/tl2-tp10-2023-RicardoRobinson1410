namespace tl2_tp10_2023_RicardoRobinson1410.Models;
public class Tablero
{
    private int id;
    private int? id_Usuario_Propietario;
    private string nombre;
    private string descripcion;

    public int Id { get => id; set => id = value; }
    public int? Id_Usuario_Propietario { get => id_Usuario_Propietario; set => id_Usuario_Propietario = value; }
    public string Nombre { get => nombre; set => nombre = value; }
    public string Descripcion { get => descripcion; set => descripcion = value; }
}