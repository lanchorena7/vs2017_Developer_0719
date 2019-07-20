using AppEntities.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Access
{
    public class ArtistDA:BaseDA
    {
        /// <summary>
        /// Obtiene la cantidad de registro
        /// </summary>
        /// <returns></returns>
        public int GetCount()
        {
            int result = 0;

            try
            {
                //1- Consulta SQL
                var sql = "SELECT COUNT (ArtistId) FROM Artist";

                //2- Crear el objeto conexion
                //using (IDbConnection cnx = new SqlConnection(cnxString))
                using (IDbConnection cnx = new SqlConnection(ConnectionString))
                {
                    //Abriendo la conexion a la BD
                    cnx.Open();

                    //3- Creando un objeto command
                    var cmd = cnx.CreateCommand();
                    //Asignando la consulta SQL al objeto command
                    cmd.CommandText = sql;
                    result = (int)cmd.ExecuteScalar(); //Ejecuta el comando
                }
            }
            catch
            {
                result = -1;
            }

            return result;
        }


        public List<Artist> GetArtist()
        {
            var result = new List<Artist>();
            var sql = "SELECT * FROM Artist";

            using (IDbConnection cnx = new SqlConnection(ConnectionString))
            {
                cnx.Open(); //Abrimos conexion de la BD
                var cmd = cnx.CreateCommand();  //Creamos la conexion
                cmd.CommandText = sql;  //Pasamos la cadena sql
                var indice = 0;
                var reader = cmd.ExecuteReader();

                while(reader.Read())
                {
                    var artist = new Artist();
                    indice = reader.GetOrdinal("ArtistId");
                    artist.ArtistId = reader.GetInt32(indice);
                    //artist.ArtistId = Convert.ToInt32(reader["ArtistId"]);

                    indice = reader.GetOrdinal("Name");
                    artist.Name = reader.GetString(indice);

                    result.Add(artist);
                }
            }
            return result;
        }

        public List<Artist> GetArtist(string filtroPorNombre)
        {
            var result = new List<Artist>();
            var sql = "usp_GetArtist";

            using (IDbConnection cnx = new SqlConnection(ConnectionString))
            {
                cnx.Open(); //Abrimos conexion de la BD
                var cmd = cnx.CreateCommand();  //Creamos la conexion
                cmd.CommandText = sql;  //Pasamos la cadena sql
                cmd.CommandType = CommandType.StoredProcedure;
                //Configurando el parametro
                cmd.Parameters.Add(
                    new SqlParameter("@Nombre", filtroPorNombre)
                    );

                var indice = 0;
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var artist = new Artist();
                    indice = reader.GetOrdinal("ArtistId");
                    artist.ArtistId = reader.GetInt32(indice);
                    //artist.ArtistId = Convert.ToInt32(reader["ArtistId"]);

                    indice = reader.GetOrdinal("Name");
                    artist.Name = reader.GetString(indice);

                    result.Add(artist);
                }
            }
            return result;
        }
    }
}
