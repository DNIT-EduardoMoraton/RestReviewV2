using GestorRestReview.Modelo;
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
        public DAOSecciones()
        {
            bd = new BDRevista();
            servicioAlerta = new AlertaServicio();
        }


        autores.CommandText = @"CREATE TABLE IF NOT EXISTS autores (
                                      id INTEGER PRIMARY KEY AUTOINCREMENT,
                                      nombre TEXT,
                                      imagen TEXT,
                                      nickName TEXT,
                                      redsocial TEXT
                                    );";
        public int insert(AutorEntity autor)
        {
            SqliteConnection con = bd.getNewConnection();
            int result = -1;

            try
            {
                con.Open();

                string sql = "INSERT INTO autores (nombre, imagen, nickName, redsocial) " +
                             "VALUES (@nombre, @descripcion)";

                SqliteCommand command = new SqliteCommand(sql, con);
                command.Parameters.AddWithValue("@nombre", seccion.Nombre);
                command.Parameters.AddWithValue("@descripcion", seccion.Descripcion);

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

        public List<SeccionEntity> getAll()
        {
            List<SeccionEntity> sections = new List<SeccionEntity>();
            SqliteConnection con = bd.getNewConnection();
            con.Open();
            SqliteCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM Secciones";
            SqliteDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                SeccionEntity section = new SeccionEntity();
                section.Id = reader.GetInt32(0);
                section.Nombre = reader.GetString(1);
                section.Descripcion = reader.GetString(2);
                sections.Add(section);
            }
            con.Close();
            return sections;
        }


    }
}
