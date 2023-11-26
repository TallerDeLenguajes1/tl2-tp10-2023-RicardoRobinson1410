namespace tl2_tp10_2023_RicardoRobinson1410.Models;
using System.Data.SQLite;
public class UsuarioRepository : IUsuarioRepository
{
    private string cadenaConexion = "Data Source=BaseDeDatos/Kanban.db;Cache=Shared";
    public bool CrearUsuario(Usuario usu)
    {
        var query = $"INSERT INTO Usuario (nombre_De_Usuario, Rol, contrasenia) VALUES (@nombre_De_Usuario, @rol, @contrasenia)";
        using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
        {

            connection.Open();
            var command = new SQLiteCommand(query, connection);

            command.Parameters.Add(new SQLiteParameter("@nombre_De_Usuario", usu.Nombre_De_Usuario));
            command.Parameters.Add(new SQLiteParameter("@rol", usu.Rol));
            command.Parameters.Add(new SQLiteParameter("@contrasenia", usu.Contrasenia));

            command.ExecuteNonQuery();

            connection.Close();
        }
        return true;
    }
    public bool ModificarUsuario(Usuario usu1, Usuario usuNuevo)
    {
        SQLiteConnection connection = new SQLiteConnection(cadenaConexion);
        SQLiteCommand command = connection.CreateCommand();
        command.CommandText = $"UPDATE Usuario SET nombre_De_Usuario = '{usuNuevo.Nombre_De_Usuario}', Rol='{usuNuevo.Rol}', Contrasenia='{usuNuevo.Contrasenia}' WHERE id={usu1.Id}";
        connection.Open();
        command.ExecuteNonQuery();
        connection.Close();
        return true;
    }
    public List<Usuario> ListarUsuarios()
    {
        var queryString = @"SELECT * FROM Usuario;";
        List<Usuario> Usuarios = new List<Usuario>();
        using (SQLiteConnection connection = new SQLiteConnection(cadenaConexion))
        {
            SQLiteCommand command = new SQLiteCommand(queryString, connection);
            connection.Open();

            using (SQLiteDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    if (!reader.IsDBNull(0))
                    {
                        var Usuario = new Usuario();
                        Usuario.Id = Convert.ToInt32(reader["id"]);
                        Usuario.Nombre_De_Usuario = reader["nombre_De_Usuario"].ToString();
                        if (Usuario.Contrasenia != null)
                        {
                            Usuario.Contrasenia = reader["contrasenia"].ToString();
                        }
                        else
                        {
                            Usuario.Contrasenia = "";
                        }
                        Usuario.Rol = (rolesUsuario)Convert.ToInt32(reader["Rol"]);
                        Usuarios.Add(Usuario);
                    }
                }
            }
            connection.Close();
        }
        return Usuarios;
    }
    public Usuario? ObtenerDetallesUsuario(int? idUsuario)
    {
        string queryString = @"SELECT * FROM Usuario WHERE id = @id_us";
        using (var connection = new SQLiteConnection(cadenaConexion))
        {
            connection.Open();
            var command = new SQLiteCommand(queryString, connection);
            command.Parameters.Add(new SQLiteParameter("@id_us", idUsuario.ToString()));
            using (var reader = command.ExecuteReader())
            {
                if (reader.Read())
                {

                    if (!reader.IsDBNull(0))
                    {
                        int id_us = Convert.ToInt32(reader["id"]);
                        if (reader["nombre_De_Usuario"] != null)
                        {
                            string nombre = reader["nombre_De_Usuario"].ToString();
                            string contrasenia = reader["contrasenia"].ToString();
                            rolesUsuario rol = (rolesUsuario)Convert.ToInt32(reader["rol"]);
                            var us = new Usuario(id_us, nombre, rol, contrasenia);
                            return us;
                        }
                        else
                        {
                            return null;
                        }
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
        }
    }
    public bool EliminarUsuario(int id)
    {
        SQLiteConnection connection = new SQLiteConnection(cadenaConexion);
        SQLiteCommand command = connection.CreateCommand();
        // usar AddParameter
        command.CommandText = $"DELETE FROM Usuario WHERE id = '{id}';";
        connection.Open();
        command.ExecuteNonQuery();
        connection.Close();
        return true;
    }
}