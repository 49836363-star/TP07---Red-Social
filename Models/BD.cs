namespace TP07.Models;
using Dapper;
using Microsoft.Data.SqlClient;

public class BD
{
    private static string connectionString = @"Server=localhost;Database=tp5;Integrated Security=True;TrustServerCertificate=True";

    public static void RegistrarUsuario(Usuario u)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = @"INSERT INTO Usuario (nombreUsuario, contraseña, nombre, apellido) VALUES (@nombreUsuario, @contraseña, @nombre, @apellido)";
            connection.Execute(query, (new { u.nombreUsuario, u.contraseña, u.nombre, u.apellido }));
        }
    }

    public static bool ExisteUsuario(string nombreUsuario)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "SELECT * FROM Usuario WHERE nombreUsuario = @nombreUsuario";
            Usuario usuario = connection.QueryFirstOrDefault<Usuario>(query, new { nombreUsuario });
            return usuario != null;
        }
    }

    public static Usuario Login(string nombreUsuario, string contraseña)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "SELECT * FROM Usuario WHERE nombreUsuario = @nombreUsuario AND contraseña = @contraseña";
            return connection.QueryFirstOrDefault<Usuario>(query, new { nombreUsuario, contraseña });
        }
    }

    public static Usuario ObtenerUsuario(string nombreUsuario)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = "SELECT * FROM Usuario WHERE nombreUsuario = @nombreUsuario";
            return connection.QueryFirstOrDefault<Usuario>(query, new { nombreUsuario });
        }
    }

    public static void CrearPublicacion(Publicacion p)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            string query = @"INSERT INTO Publicacion (IdUsuario, titulo, descripcion, imagen, fechaPublicacion)
                             VALUES (@IdUsuario, @titulo, @descripcion, @imagen, @fechaPublicacion)";

            connection.Execute(query, new { p.IdUsuario, p.titulo, p.descripcion, p.imagen, p.fechaPublicacion });        }
    }
}