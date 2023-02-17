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
    class DAOAutores
    {
        private BDRevista bd;
        private AlertaServicio servicioAlerta;
        public DAOAutores()
        {
            bd = new BDRevista();
            servicioAlerta = new AlertaServicio();
        }

        public int insert(AutorEntity autor)
        {
            SqliteConnection con = bd.GetNewConnection();
            int result = -1;

            try
            {
                con.Open();

                string sql = "INSERT INTO autores (nombre, imagen, nickName, redsocial) " +
                             "VALUES (@nombre, @imagen, @nickName, @redsocial)";

                SqliteCommand command = new SqliteCommand(sql, con);
                command.Parameters.AddWithValue("@nombre", autor.Nombre);
                command.Parameters.AddWithValue("@imagen", autor.Imagen);
                command.Parameters.AddWithValue("@nickName", autor.NickName);
                command.Parameters.AddWithValue("@redsocial", autor.Redsocial);

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

        public List<AutorEntity> getAll()
        {
            List<AutorEntity> autores = new List<AutorEntity>();
            SqliteConnection con = bd.GetNewConnection();
            con.Open();
            SqliteCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM autores";
            SqliteDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Autor autor = new Autor();
                autor.Id = reader.GetInt32(0);
                autor.Nombre = reader.GetString(1);
                autor.Imagen = reader.GetString(2);
                autor.NickName = reader.GetString(3);
                autor.Redsocial = reader.GetString(4);
                autores.Add(autor);
            }
            con.Close();
            return autores;
        }

        public AutorEntity geById(int id)
        {
            AutorEntity result = new AutorEntity();
            SqliteConnection con = bd.GetNewConnection();
            con.Open();
            SqliteCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM autores WHERE id = @id";
            cmd.Parameters.AddWithValue("@id", id);
            SqliteDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                result.Id = reader.GetInt32(0);
                result.Nombre = reader.GetString(1);
                result.Imagen = reader.GetString(2);
                result.NickName = reader.GetString(3);
                result.Redsocial = reader.GetString(4);
            }
            con.Close();
            return result;
        }
        public void Delete(AutorEntity autor) // hacer comprobaciones de longitud
        {
            SqliteConnection con = bd.GetNewConnection();
            con.Open();
            string sql = "DELETE FROM autores WHERE id = @Id";
            SqliteCommand command = new SqliteCommand(sql, con);
            command.Parameters.AddWithValue("@Id", autor.Id);
            command.ExecuteNonQuery();
            con.Close();
        }


    }
}
