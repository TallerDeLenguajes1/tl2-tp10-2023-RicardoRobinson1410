namespace tl2_tp10_2023_RicardoRobinson1410.Models;
using System.Data.SQLite;
public interface ITableroRepository
{
    public bool CrearTablero(Tablero usu);
    public bool ModificarTablero(int id, Tablero usu);
    public List<Tablero> ListarTableros();
    public List<Tablero> ObtenerDetallesTableroPorUsuario(int idUsuario);
    public bool EliminarTablero(int id);
    public Tablero? ObtenerDetallesTablero(int? id);
}