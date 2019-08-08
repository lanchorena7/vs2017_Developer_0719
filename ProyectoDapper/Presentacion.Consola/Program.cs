using PersistenciaDeDatos.Gestores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion.Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            var gestorDeCustomers = new GestorDeCustomers();

            gestorDeCustomers.ListarCustomers().ForEach(x =>
            {
                Console.WriteLine(x.Address);
                
            });

            gestorDeCustomers
                .ListarCustomers()
                .Select(x => x.City)
                .Distinct()
                .ToList()
                .ForEach(x => gestorDeCustomers.InsertarGenre(x));


            Console.ReadKey();

        }
    }
}
