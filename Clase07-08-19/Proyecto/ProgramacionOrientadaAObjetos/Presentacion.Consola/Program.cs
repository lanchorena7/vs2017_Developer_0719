using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entidades;

namespace Presentacion.Consola
{
    class Program
    {
        static void Main(string[] args)
        {
            Persona persona = new Persona();
            persona.Anios = 10;
            persona.FechaNacimiento = DateTime.Now.AddYears(-30);
            persona.Nombre = "Daniel";
            persona.Sexo = Sexo.Hombre;

            var segundaPersona = new Persona()
            {
                Anios = 30,
                FechaNacimiento = DateTime.Now,
                Nombre = "Luis",
                Sexo = Sexo.Hombre
            };

            List<object> listaGenerica = new List<object>();
            listaGenerica.Add(1);
            listaGenerica.Add(DateTime.Now);
            listaGenerica.Add(true);
            listaGenerica.Add(segundaPersona);

            Console.WriteLine("Impresion por for normal");
            for (int i = 0; i < listaGenerica.Count; i++)
            {
                Console.WriteLine(listaGenerica.ElementAt(i));
            }

            Console.WriteLine("Impresion con iteradores");
            foreach (var objecto in listaGenerica)
            {
                Console.WriteLine(objecto);
            }

            Console.WriteLine("Impresion por linq");
            listaGenerica.ForEach(y => Console.WriteLine(y));

            Console.ReadKey();
        }
    }
}
