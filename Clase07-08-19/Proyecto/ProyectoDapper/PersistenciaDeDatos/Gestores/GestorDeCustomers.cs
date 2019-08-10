using Dapper;
using PersistenciaDeDatos.Compartido;
using PersistenciaDeDatos.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistenciaDeDatos.Gestores
{
    public class GestorDeCustomers
    {
        private FabricaDeConexiones fabricaDeConexiones = new FabricaDeConexiones();

        public List<Customer> ListarCustomers()
        {
            using (var conexion = fabricaDeConexiones.ConstruirConexionAChinook())
            {
                // EJECUTAR SQL EN EL CODIGO
                //var listaDeCustomers = conexion.Query<Customer>(
                //        "SELECT * FROM Customer",
                //        commandType: CommandType.Text
                //    ).ToList();

                var listaDeCustomers = conexion.Query<Customer>(
                        "ListarCustomers",
                        commandType: CommandType.StoredProcedure
                    ).ToList();
                return listaDeCustomers;

                //--SCRIPT DEL STORE PROCEDURE
                //CREATE PROCEDURE ListarCustomers
                //AS
                //BEGIN
                //    SELECT* FROM Customer
                //END
            }
        }


        public void InsertarGenre(string nombreDeGeneroMusical)
        {
            using (var conexion = fabricaDeConexiones.ConstruirConexionAChinook())
            {
                conexion.Execute(
                        "INSERT INTO Genre(Name) VALUES(@Name)"
                        , new { Name = nombreDeGeneroMusical }
                        , commandType: CommandType.Text
                    );
            }
        }

    }
}
