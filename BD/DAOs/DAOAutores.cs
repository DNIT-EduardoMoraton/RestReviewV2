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
            SqliteConnection con = bd.getNewConnection();
            int result = -1;

            try
            {
                con.Open();

                string sql = "INSERT INTO autores (nombre, imagen, nickName, redsocial) " +
                             "VALUES (@nombre, @imagen, @nickName, @redsocial)";

                SqliteCommand command = new SqliteCommand(sql, con);
                command.Parameters.AddWithValue("@nombre", autor.Nombre);
                command.Parameters.AddWithValue("@imagen", autor.Imagen);
                command.Parameters.AddWithValue("@nickName", autor.Imagen);
                command.Parameters.AddWithValue("@redsocial", autor.Imagen);

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
            SqliteConnection con = bd.getNewConnection();
            con.Open();
            SqliteCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM autores";
            SqliteDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                

            }
            con.Close();
            return autores;
        }


    }
}
