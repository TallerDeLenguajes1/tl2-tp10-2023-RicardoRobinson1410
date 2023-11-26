namespace tl2_tp10_2023_RicardoRobinson1410.Models;

public enum estadosTarea
{
    ideas=0,
    toDo=1,
    doing=2,
    review=3,
    done=4
}
public class Tarea
{
    private int id;
    private int? id_Tablero;
    private string nombre;
    private estadosTarea estado;
    private string descripcion;
    private string color;
    private int? id_Usuario_Asignado;

    public int Id { get => id; set => id = value; }
    public int? Id_Tablero { get => id_Tablero; set => id_Tablero = value; }
    public string Nombre { get => nombre; set => nombre = value; }
    public estadosTarea Estado { get => estado; set => estado = value; }
    public string Descripcion { get => descripcion; set => descripcion = value; }
    public string Color { get => color; set => color = value; }
    public int? Id_Usuario_Asignado { get => id_Usuario_Asignado; set => id_Usuario_Asignado = value; }
}