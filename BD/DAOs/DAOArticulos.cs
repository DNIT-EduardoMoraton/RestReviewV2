using GestorRestReview.Modelo;
using GestorRestReview.Servicios;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorRestReview.BD.DAOs
{
    class DAOArticulos
    {
        private BDRevista bd;
        private AlertaServicio servicioAlerta;
        public DAOArticulos()
        {
            bd = new BDRevista();
            servicioAlerta = new AlertaServicio();
        }

        // Create Articulos
        public int insert(ArticuloEntity articulo)
        {
            SqliteConnection con = bd.GetNewConnection();
            int result = -1;

            try
            {
                con.Open();

                string sql = "INSERT INTO articulos (idAutor, idSeccion, texto, titulo, imagen, fechaPublicacion, url) " +
                             "VALUES (@idAutor, @idSeccion, @texto, @titulo, @imagen, @fechaPublicacion, @url)";

                SqliteCommand command = new SqliteCommand(sql, con);
                command.Parameters.AddWithValue("@idAutor", articulo.IdAutor);
                command.Parameters.AddWithValue("@idSeccion", articulo.IdSeccion);
                command.Parameters.AddWithValue("@texto", articulo.Texto);
                command.Parameters.AddWithValue("@titulo", articulo.Titulo);
                command.Parameters.AddWithValue("@imagen", articulo.Imagen);
                command.Parameters.AddWithValue("@fechaPublicacion", articulo.FechaPublicacion);
                command.Parameters.AddWithValue("@url", articulo.FechaPublicacion);

                result = command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                servicioAlerta.MessageBoxError(e.Message);
            }
            finally
            {
                con.Close();
            }

            return result;

        }

        public List<ArticuloEntity> getAll()
        {
            List<ArticuloEntity> articulos = new List<ArticuloEntity>();
            SqliteConnection con = bd.GetNewConnection();
            con.Open();
            SqliteCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM articulos";
            SqliteDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                ArticuloEntity articulo = readOne(reader);
                articulos.Add(articulo);

            }
            con.Close();
            return articulos;
        }

        public List<ArticuloEntity> GetAllByIdSeccion(SeccionEntity seccion)
        {
            SqliteConnection con = bd.GetNewConnection();
            con.Open();
            List<ArticuloEntity> articulos = new List<ArticuloEntity>();
            string sql = "SELECT * FROM articulos" +
                             "WHERE idSeccion = @IdSeccion";

            SqliteCommand command = new SqliteCommand(sql, con);

            command.Parameters.AddWithValue("@IdSeccion", seccion.Id);
            SqliteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ArticuloEntity articulo = readOne(reader);

            }
            con.Close();
            return articulos;
        }



        private ArticuloEntity readOne(SqliteDataReader reader)
        {
            ArticuloEntity articulo = new ArticuloEntity();
            articulo.Id = reader.GetInt32(0);
            articulo.IdAutor = reader.GetInt32(1);
            articulo.Texto = reader.GetString(2);
            articulo.IdSeccion = reader.GetInt32(3);
            articulo.Titulo = reader.GetString(4);
            articulo.Imagen = reader.GetString(5);
            articulo.FechaPublicacion = reader.GetInt64(6);
            articulo.Url = reader.GetString(7);
            return articulo;
        }
    }
}
