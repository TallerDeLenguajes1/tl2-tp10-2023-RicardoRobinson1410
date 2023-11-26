namespace tl2_tp10_2023_RicardoRobinson1410.Models;

using System.Data.SqlClient;
using System.Data.SQLite; 
public class TareaRepository:ITareaRepository
{
    private string cadenaConexion="Data Source=BaseDeDatos/Kanban.db;Cache=Shared";
public bool CrearTarea(Tarea tar)
{
    var query = $"INSERT INTO Tarea (id_Tablero, nombre, estado, descripcion, color, id_Usuario_Asignado) VALUES (@id_Tablero, @nombre, @estado, @descripcion, @color, @id_Usuario_Asignado)";
            using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {

                connection.Open();
                var command = new SQLiteCommand(query, connection);

                command.Parameters.Add(new SQLiteParameter("@id_Tablero", tar.Id_Tablero));
                command.Parameters.Add(new SQLiteParameter("@nombre", tar.Nombre));
                command.Parameters.Add(new SQLiteParameter("@estado", tar.Descripcion));
                command.Parameters.Add(new SQLiteParameter("@descripcion", tar.Descripcion));
                command.Parameters.Add(new SQLiteParameter("@color", tar.Color));
                command.Parameters.Add(new SQLiteParameter("@id_Usuario_Asignado", tar.Id_Usuario_Asignado));

                command.ExecuteNonQuery();

                connection.Close();   
            }
            return true;
}
    public bool ModificarTarea(int id, Tarea tar)
    {
        SQLiteConnection connection = new SQLiteConnection(cadenaConexion);
            SQLiteCommand command = connection.CreateCommand();
            command.CommandText = $"UPDATE Tarea SET id_Tablero = '{tar.Id_Tablero}', nombre='{tar.Nombre}', estado='{tar.Estado}', descripcion='{tar.Descripcion}', color='{tar.Color}', id_Usuario_Asignado='{tar.Id_Usuario_Asignado}' WHERE id={id}";
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            return true;
    }
    public List<Tarea> ListarTareas()
    {
        var queryString = @"SELECT * FROM Tarea;";
            List<Tarea> Tareas = new List<Tarea>();
            using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {
                SQLiteCommand command = new SQLiteCommand(queryString, connection);
                connection.Open();
            
                using(SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var Tarea = new Tarea();
                        Tarea.Id = Convert.ToInt32(reader["id"]);
                        if(!reader.IsDBNull(1))
                        {
                            Tarea.Id_Tablero = Convert.ToInt32(reader["id_Tablero"]);
                        }else
                        {
                            Tarea.Id_Tablero=null;
                        }
                        Tarea.Nombre=reader["nombre"].ToString();
                        Tarea.Estado=(estadosTarea)Convert.ToInt32(reader["estado"]);
                        Tarea.Descripcion=reader["descripcion"].ToString();
                        Tarea.Color=reader["color"].ToString();
                        if(!reader.IsDBNull(6))
                        {
                            Tarea.Id_Usuario_Asignado=Convert.ToInt32(reader["id_Usuario_Asignado"]);
                        }else
                        {
                            Tarea.Id_Usuario_Asignado=null;
                        }
                        Tareas.Add(Tarea);
                    }
                }
                connection.Close();
            }
            return Tareas;
    }
    public Tarea? ObtenerDetallesTarea(int idTarea)
    {
        SQLiteConnection connection = new SQLiteConnection(cadenaConexion);
            var Tarea = new Tarea();
            SQLiteCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Tarea WHERE id = @idTarea";
            command.Parameters.Add(new SQLiteParameter("@idTarea", idTarea));
            connection.Open();
            using(SQLiteDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    Tarea.Id = Convert.ToInt32(reader["id"]);
                    if(!reader.IsDBNull(1))
                    {
                         Tarea.Id_Tablero = Convert.ToInt32(reader["id_Tablero"]);
                    }else
                    {
                        Tarea.Id_Tablero=null;
                    }
                        Tarea.Nombre=reader["nombre"].ToString();
                        Tarea.Estado=(estadosTarea)Convert.ToInt32(reader["estado"]);
                        Tarea.Descripcion=reader["descripcion"].ToString();
                        Tarea.Color=reader["color"].ToString();
                        if(!reader.IsDBNull(6))
                        {
                            Tarea.Id_Usuario_Asignado=Convert.ToInt32(reader["id_Usuario_Asignado"]);
                        }else
                        {
                            Tarea.Id_Usuario_Asignado=null;
                        }
                        
                }
            }
            connection.Close();
            return Tarea;
    }
    public bool EliminarTarea(int idTarea)
    {
        SQLiteConnection connection = new SQLiteConnection(cadenaConexion);
            SQLiteCommand command = connection.CreateCommand();
            // usar AddParameter
            command.CommandText = $"DELETE FROM Tarea WHERE id = '{idTarea}';";
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            return true;
    }

public List<Tarea> ObtenerDetallesTareaPorId_Tablero(int idTablero)
{
     SQLiteConnection connection = new SQLiteConnection(cadenaConexion);
            var Tareas = new List<Tarea>();
            SQLiteCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Tarea WHERE id_Tablero = @idTablero";
            command.Parameters.Add(new SQLiteParameter("@idTablero", idTablero));
            connection.Open();
            using(SQLiteDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var Tarea=new Tarea();
                    Tarea.Id = Convert.ToInt32(reader["id"]);
                    Tarea.Id_Tablero = Convert.ToInt32(reader["id_Tablero"]);
                    Tarea.Nombre=reader["nombre"].ToString();
                    Tarea.Estado=(estadosTarea)Convert.ToInt32(reader["estado"]);
                    Tarea.Descripcion=reader["descripcion"].ToString();
                    Tarea.Color=reader["color"].ToString();
                    Tarea.Id_Usuario_Asignado=Convert.ToInt32(reader["id_Usuario_Asignado"]);
                    Tareas.Add(Tarea);
                }
            }
            connection.Close();
            return Tareas;
}

public List<Tarea> ObtenerDetallesTareaPorId_Usuario(int idUsuario)
{
     SQLiteConnection connection = new SQLiteConnection(cadenaConexion);
            var Tareas = new List<Tarea>();
            SQLiteCommand command = connection.CreateCommand();
            command.CommandText = "SELECT * FROM Tarea WHERE id_Usuario_Asignado = @id_Usuario_Asignado";
            command.Parameters.Add(new SQLiteParameter("@id_Usuario_Asignado", idUsuario));
            connection.Open();
            using(SQLiteDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    var Tarea=new Tarea();
                    Tarea.Id = Convert.ToInt32(reader["id"]);
                        Tarea.Id_Tablero = Convert.ToInt32(reader["id_Tablero"]);
                        Tarea.Nombre=reader["nombre"].ToString();
                        Tarea.Estado=(estadosTarea)Convert.ToInt32(reader["estado"]);
                        Tarea.Descripcion=reader["descripcion"].ToString();
                        Tarea.Color=reader["color"].ToString();
                        if(!reader.IsDBNull(6))
                        {
                            Tarea.Id_Usuario_Asignado=Convert.ToInt32(reader["id_Usuario_Asignado"]);
                        }
                        else
                        {
                            Tarea.Id_Usuario_Asignado=null;
                        }
                        Tareas.Add(Tarea);
                }
            }
            connection.Close();
            return Tareas;
}

public bool AsignarUsuarioATarea(int id_Tarea, int id_Usuario)
{
    SQLiteConnection connection = new SQLiteConnection(cadenaConexion);
            SQLiteCommand command = connection.CreateCommand();
            command.CommandText = $"UPDATE Tarea SET id_Usuario_Asignado = '{id_Usuario}' WHERE id={id_Tarea}";
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            return true;
}

public bool modificarEstado(estadosTarea estado, int idTarea)
{
    SQLiteConnection connection = new SQLiteConnection(cadenaConexion);
            SQLiteCommand command = connection.CreateCommand();
            command.CommandText = $"UPDATE Tarea SET estado='{estado}' WHERE id={idTarea}";
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
            return true;
}

public int CantidadTareasXEstado(estadosTarea estado)
{   int cant;
     var queryString = @"SELECT COUNT(*) FROM Tarea WHERE estado= @estado";
            using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
            {
                SQLiteCommand command = new SQLiteCommand(queryString, connection);
                command.Parameters.Add(new SQLiteParameter("@estado", estado));
                connection.Open();
                cant=Convert.ToInt32(command.ExecuteScalar());
                connection.Close();

            }
    return cant;
}
}