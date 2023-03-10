

using Microsoft.Data;
using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestorRestReview.BD
{
    class BDRevista
    {
        private SqliteConnection conexion;

        public BDRevista()
        {

        }

        public void inicializar()
        {
            conexion = new SqliteConnection("Data Source=BDRevista.db");
            conexion.Open();

            // Create Articulos
            SqliteCommand articulos = conexion.CreateCommand();
            articulos.CommandText = @"CREATE TABLE IF NOT EXISTS articulos (
                                      id INTEGER PRIMARY KEY AUTOINCREMENT,
                                      idAutor INTEGER,
                                      idSeccion INTEGER,
                                      texto TEXT,
                                      titulo TEXT,
                                      imagen TEXT,
                                      fechaPublicacion INTEGER,
                                      url TEXT
                                    );";
            articulos.ExecuteNonQuery();


            // Create autores
            SqliteCommand autores = conexion.CreateCommand();
            autores.CommandText = @"CREATE TABLE IF NOT EXISTS autores (
                                      id INTEGER PRIMARY KEY AUTOINCREMENT,
                                      nombre TEXT,
                                      imagen TEXT,
                                      nickName TEXT,
                                      redsocial TEXT
                                    );";
            autores.ExecuteNonQuery();

            // Create secciones

            SqliteCommand secciones = conexion.CreateCommand();
            secciones.CommandText = @"CREATE TABLE IF NOT EXISTS secciones (
                                      id INTEGER PRIMARY KEY AUTOINCREMENT,
                                      nombre TEXT,
                                      descripcion TEXT
                                    );";
            secciones.ExecuteNonQuery();
            conexion.Close();

        } 

        public SqliteConnection GetNewConnection() => new SqliteConnection("Data Source=BDRevista.db");

    }
}
