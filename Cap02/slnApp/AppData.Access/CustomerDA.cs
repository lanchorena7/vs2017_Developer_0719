﻿using AppEntities.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppData.Access
{
    class CustomerDA:BaseDA
    {
        public int GetCount()
        {
            int result = 0;

            try
            {
                //1- Consulta SQL
                var sql = "SELECT COUNT (Customerld) FROM Artist";

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
        }  //TRAE REGISTROS

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

        public List<Artist> GetArtist(string filtroPorNombre)
        {
            var result = new List<Artist>();
            var sql = "usp_GetArtist"; // Aplicamos un SP

            using (IDbConnection cnx = new SqlConnection(ConnectionString))
            {
                cnx.Open(); //Abrimos conexion de la BD
                var cmd = cnx.CreateCommand();  //Creamos la conexion
                cmd.CommandText = sql;  //Pasamos la cadena sql
                cmd.CommandType = CommandType.StoredProcedure; // Creamos el comando
                //Configurando el parametro
                cmd.Parameters.Add(
                    new SqlParameter("@Nombre", filtroPorNombre) // Pasamos el parametro
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

        public int InsertArtist(Artist entity)
        {
            var result = 0; //Creamos una variable result

            using (IDbConnection cnx = new SqlConnection(ConnectionString))
            {
                cnx.Open();
                var cmd = cnx.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_InsertArtist";
                //parametros
                cmd.Parameters.Add(
                    new SqlParameter("@Name", entity.Name));
                result = Convert.ToInt32(cmd.ExecuteScalar());
            }

            return result;
        } //

        public int InsertArtistParamOut(Artist entity)
        {
            var result = 0; //Creamos una variable result

            using (IDbConnection cnx = new SqlConnection(ConnectionString))
            {
                cnx.Open();
                var cmd = cnx.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_InsertArtist";
                //parametros
                cmd.Parameters.Add(
                    new SqlParameter("@Name", entity.Name));
                //Declarando un parametro de salida
                var paramID = new SqlParameter();
                paramID.ParameterName = "@ID";
                paramID.Direction = ParameterDirection.Output;
                paramID.DbType = DbType.Int32;

                cmd.Parameters.Add(paramID);
                //--Fin de confiurarar el parametro de salida

                cmd.ExecuteNonQuery();
                result = Convert.ToInt32(paramID.Value);
            }

            return result;
        }

        public bool UpdateArtist(Artist entity)
        {
            var result = false; //Creamos una variable result

            using (IDbConnection cnx = new SqlConnection(ConnectionString))
            {
                cnx.Open();
                var cmd = cnx.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_UpdateArtist";
                //parametros
                cmd.Parameters.Add(
                    new SqlParameter("@ID", entity.Name));
                //result = cmd.ExecuteNonQuery() > 0 ? true : false
                //Es igual a la evaluación de la linea de abajo
                result = cmd.ExecuteNonQuery() > 0;
            }

            return result;
        }

        public bool DeleteArtist(int id)
        {
            var result = false; //Creamos una variable result

            using (IDbConnection cnx = new SqlConnection(ConnectionString))
            {
                cnx.Open();
                var cmd = cnx.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "usp_DeleteArtist";
                //parametros
                cmd.Parameters.Add(
                    new SqlParameter("@ID", id));
                //result = cmd.ExecuteNonQuery() > 0 ? true : false
                //Es igual a la evaluación de la linea de abajo
                result = cmd.ExecuteNonQuery() > 0;
            }

            return result;
        }

        public Customer usp_GetCustomerxName(int id)
        {
            var resultado = new Customer();
            var name = new List<Customer>();

            using (IDbConnection cnx = new SqlConnection(ConnectionString))
            {
                cnx.Open(); //Abrimos conexion de la BD
                var cmd = cnx.CreateCommand();  //Creamos la conexion
                cmd.CommandText = "usp_GetCustomerxName";  //Pasamos la cadena sql
                cmd.CommandType = CommandType.StoredProcedure; //Configurando el parametro
                cmd.Parameters.Add(new SqlParameter("@FullName", name));

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var customer = new Customer();

                    customer.CustomerId = reader.GetInt32Value("CustomerId"));
                    customer.FirstName = reader.GetStringValue("FirstName"));
                    customer.LastName = reader.GetStringValue("LastName"));

                    customer.Company = reader.GetStringValue("Company");

                    customer.Address = reader.GetStringValue("Address");
                    customer.City = reader.GetStringValue("City");
                    customer.State = reader.GetStringValue("State");
                    customer.Country = reader.GetStringValue("Country");
                    customer.PostalCode = reader.GetStringValue("PostalCode");
                    customer.Phone = reader.GetStringValue("Phone");
                    customer.Fax = reader.GetStringValue("Fax");
                    customer.Email = reader.GetStringValue("Email");
                    customer.SupportRepId = reader.GetInt32Null("SupportRepId");

                    resultado.Add(customer);
                }
            }

            return resultado;
        }
    }
}