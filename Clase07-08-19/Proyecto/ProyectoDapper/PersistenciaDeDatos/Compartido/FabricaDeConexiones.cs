using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersistenciaDeDatos.Compartido
{
    class FabricaDeConexiones
    {
        private string cadenaDeConexionChinook = "SERVER=S300-ST;DataBase=Chinook; USER ID=lanchorena; PASSWORD=piscobamba19";

        public IDbConnection ConstruirConexionAChinook()
        {
            return new SqlConnection(this.cadenaDeConexionChinook);
        }
    }
}
