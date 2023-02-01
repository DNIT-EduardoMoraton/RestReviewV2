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
    class DAOSecciones
    {
        private BDRevista bd;
        private AlertaServicio servicioAlerta;
        public DAOSecciones()
        {
            bd = new BDRevista();
            servicioAlerta = new AlertaServicio();
        }

        public int Insert(SeccionEntity seccion)
        {
            SqliteConnection con = bd.GetNewConnection();
            int result = -1;

            try
            {
                con.Open();

                string sql = "INSERT INTO Secciones (nombre, descripcion) " +
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

        public List<SeccionEntity> GetAll()
        {
            List<SeccionEntity> sections = new List<SeccionEntity>();
            SqliteConnection con = bd.GetNewConnection();
            try
            {
               
            con.Open();
            SqliteCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM secciones";
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
            
                            }
            catch (Exception e)
            {
                servicioAlerta.MessageBoxError(e.Message);
            }
            finally
            {
                con.Close();
            }
            return sections;
        }

        public SeccionEntity GetById(int id)
        {
            SeccionEntity result = new SeccionEntity();
            SqliteConnection con = bd.GetNewConnection();
            con.Open();
            SqliteCommand cmd = con.CreateCommand();
            cmd.CommandText = "SELECT * FROM secciones WHERE id = @id";
            cmd.Parameters.AddWithValue("@id", id);
            SqliteDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                result.Id = reader.GetInt32(0);
                result.Nombre = reader.GetString(1);
                result.Descripcion = reader.GetString(2);
            }
            con.Close();
            return result;
        }


    }
}
