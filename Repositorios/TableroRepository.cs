namespace tl2_tp10_2023_RicardoRobinson1410.Models;
using System.Data.SQLite;
using Microsoft.AspNetCore.Http.Connections;

public class TableroRepository : ITableroRepository
{
    private string cadenaConexion = "Data Source=BaseDeDatos/Kanban.db;Cache=Shared";
    public bool CrearTablero(Tablero tab)
    {
        var query = $"INSERT INTO Tablero (id_Usuario_Propietario, nombre, descripcion) VALUES (@id_Usuario_Propietario, @nombre, @descripcion)";
        using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
        {

            connection.Open();
            var command = new SQLiteCommand(query, connection);

            command.Parameters.Add(new SQLiteParameter("@id_Usuario_Propietario", tab.Id_Usuario_Propietario));
            command.Parameters.Add(new SQLiteParameter("@nombre", tab.Nombre));
            command.Parameters.Add(new SQLiteParameter("@descripcion", tab.Descripcion));

            command.ExecuteNonQuery();

            connection.Close();
        }
        return true;
    }
    public bool ModificarTablero(int id, Tablero tab)
    {
        using (var connection = new SQLiteConnection(cadenaConexion))
        {
            var tablero=new Tablero();
            var sqlQuery = $"UPDATE Tablero SET id_Usuario_Propietario =@tabId_Usuario_Propietario, nombre= @tabNombre, descripcion= @tabDescripcion WHERE id=@id;";
            var command= new SQLiteCommand(sqlQuery, connection);
            command.Parameters.Add(new SQLiteParameter("@tabId_Usuario_Propietario",tab.Id_Usuario_Propietario));
            command.Parameters.Add(new SQLiteParameter("@tabNombre",tab.Nombre));
            command.Parameters.Add(new SQLiteParameter("@tabDescripcion",tab.Descripcion));
            command.Parameters.Add(new SQLiteParameter("@id",id));
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        return true;
        }
        
    }
    public List<Tablero> ListarTableros()
    {
        var queryString = @"SELECT * FROM Tablero;";
        List<Tablero> Tableros = new List<Tablero>();
        using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
        {
            SQLiteCommand command = new SQLiteCommand(queryString, connection);
            connection.Open();

            using (SQLiteDataReader reader = command.ExecuteReader()) 
            {
                while (reader.Read())
                {
                    var Tablero = new Tablero();
                    Tablero.Id = Convert.ToInt32(reader["id"]);
                    if(!reader.IsDBNull(1))
                    {
                        Tablero.Id_Usuario_Propietario = Convert.ToInt32(reader["id_Usuario_Propietario"]);
                    }else
                    {
                        Tablero.Id_Usuario_Propietario=null;
                    }
                    Tablero.Nombre = reader["nombre"].ToString();
                    Tablero.Descripcion = reader["descripcion"].ToString();
                    Tableros.Add(Tablero);
                }
            }
            connection.Close();
        }
        return Tableros;
    }
    public List<Tablero> ObtenerDetallesTableroPorUsuario(int idTablero)
    {
        SQLiteConnection connection = new SQLiteConnection(cadenaConexion);
        var Tableros = new List<Tablero>();
        SQLiteCommand command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM Tablero WHERE id_Usuario_Propietario = @idTablero";
        command.Parameters.Add(new SQLiteParameter("@idTablero", idTablero));
        connection.Open();
        using (SQLiteDataReader reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                var Tablero = new Tablero();
                Tablero.Id = Convert.ToInt32(reader["id"]);
                Tablero.Id_Usuario_Propietario = Convert.ToInt32(reader["id_Usuario_Propietario"].ToString());
                Tablero.Nombre = reader["nombre"].ToString();
                Tablero.Descripcion = reader["descripcion"].ToString();
                Tableros.Add(Tablero);
            }

        }
        connection.Close();
        return Tableros;
    }
    public bool EliminarTablero(int idTablero)
    {
        SQLiteConnection connection = new SQLiteConnection(cadenaConexion);
        SQLiteCommand command = connection.CreateCommand();
        // usar AddParameter
        command.CommandText = $"DELETE FROM Tablero WHERE id = '{idTablero}';";
        connection.Open();
        command.ExecuteNonQuery();
        connection.Close();
        return true;
    }

    public Tablero? ObtenerDetallesTablero(int? id)
    {
        var sqlQuery = $"SELECT * from Tablero WHERE id=@idTablero";
        var tab = new Tablero();
        using (var connection = new SQLiteConnection(cadenaConexion))
        {
            connection.Open();
            var command = new SQLiteCommand(sqlQuery, connection);
            command.Parameters.Add(new SQLiteParameter("@idTablero", id));
            using (var reader = command.ExecuteReader())
            {

                if (reader.Read())
                {
                    if (reader["id"] != null)
                    {
                        tab.Id = Convert.ToInt32(reader["Id"]);
                        tab.Nombre = reader["Nombre"].ToString();
                        tab.Descripcion = reader["Descripcion"].ToString();
                        if(!reader.IsDBNull(1))
                        {
                            tab.Id_Usuario_Propietario = Convert.ToInt32(reader["Id_Usuario_Propietario"]);
                        }else
                        {
                            tab.Id_Usuario_Propietario=null;
                        }
                    }
                }
            }
            connection.Close();
        }
        return tab;
    }

}