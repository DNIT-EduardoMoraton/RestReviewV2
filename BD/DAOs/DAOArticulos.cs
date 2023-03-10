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
        public int Insert(ArticuloEntity articulo)
        {
            SqliteConnection con = bd.GetNewConnection();
            int result = -1;

            if (this.exists(articulo))
            {
                return this.EditArticulo(articulo);
            }

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
                command.Parameters.AddWithValue("@url", articulo.Url);

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

        public int EditArticulo(ArticuloEntity articulo)
        {
            SqliteConnection con = bd.GetNewConnection();
            con.Open();
            string sql = "UPDATE articulos SET idAutor = @IdAutor, idSeccion = @IdSeccion, texto = @Texto, titulo = @Titulo, imagen = @Imagen, fechaPublicacion = @FechaPublicacion, url = @Url WHERE id = @Id";
            SqliteCommand command = new SqliteCommand(sql, con);

            command.Parameters.AddWithValue("@IdAutor", articulo.IdAutor);
            command.Parameters.AddWithValue("@IdSeccion", articulo.IdSeccion);
            command.Parameters.AddWithValue("@Texto", articulo.Texto);
            command.Parameters.AddWithValue("@Titulo", articulo.Titulo);
            command.Parameters.AddWithValue("@Imagen", articulo.Imagen);
            command.Parameters.AddWithValue("@FechaPublicacion", articulo.FechaPublicacion);
            command.Parameters.AddWithValue("@Url", articulo.Url);
            command.Parameters.AddWithValue("@Id", articulo.Id);

            command.ExecuteNonQuery();
            con.Close();
            return 1;
        }

        public void Delete(ArticuloEntity articulo) // hacer comprobaciones de longitud
        {
            SqliteConnection con = bd.GetNewConnection();
            con.Open();
            string sql = "DELETE FROM articulos WHERE id = @Id";
            SqliteCommand command = new SqliteCommand(sql, con);
            command.Parameters.AddWithValue("@Id", articulo.Id);
            command.ExecuteNonQuery();
            con.Close();
        }



        private ArticuloEntity readOne(SqliteDataReader reader)
        {
            ArticuloEntity articulo = new ArticuloEntity();
            articulo.Id = reader.GetInt32(0);
            articulo.IdAutor = reader.GetInt32(1);
            articulo.IdSeccion = reader.GetInt32(2);
            articulo.Texto = reader.GetString(3);    
            articulo.Titulo = reader.GetString(4);
            articulo.Imagen = reader.GetString(5);
            articulo.FechaPublicacion = reader.GetInt64(6);
            articulo.Url = reader.GetString(7);
            return articulo;
        }

        public bool exists(ArticuloEntity articulo)
        {
            SqliteConnection con = bd.GetNewConnection();
            int result = -1;
            bool exists = false;

            try
            {
                con.Open();

                string sql = "SELECT count(*) FROM articulos WHERE id=@id";

                SqliteCommand command = new SqliteCommand(sql, con);
                command.Parameters.AddWithValue("@id", articulo.Id);

                result = Convert.ToInt32(command.ExecuteScalar());

                if (result > 0)
                {
                    exists = true;
                }
            }
            catch (Exception e)
            {
                servicioAlerta.MessageBoxError(e.Message);
            }
            finally
            {
                con.Close();
            }

            return exists;
        }
    }
}
