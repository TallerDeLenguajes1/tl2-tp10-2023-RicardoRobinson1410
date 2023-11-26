namespace tl2_tp10_2023_RicardoRobinson1410.Models;
using System.Data.SQLite;
public interface ITareaRepository
{
    public bool CrearTarea(Tarea Tar);
    public bool ModificarTarea(int id, Tarea Tar);
    public List<Tarea> ListarTareas();
    public Tarea? ObtenerDetallesTarea(int id);
    public bool EliminarTarea(int id);
    public List<Tarea> ObtenerDetallesTareaPorId_Tablero(int idTablero);
    public List<Tarea> ObtenerDetallesTareaPorId_Usuario(int idUsuario);
    public bool AsignarUsuarioATarea(int id_Tarea, int id_Usuario);
    public bool modificarEstado(estadosTarea estado, int idTarea);
    public int CantidadTareasXEstado(estadosTarea estado);

}