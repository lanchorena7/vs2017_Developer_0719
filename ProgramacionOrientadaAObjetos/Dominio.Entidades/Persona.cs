using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidades
{
    public class Persona
    {
        public DateTime FechaNacimiento { get; set; }
        public string Nombre { get; set; }
        public Sexo Sexo { get; set; }
        public int Anios { get; set; }
        public static int NumeroDePersonas { get; private set; } = 0;

        public Persona()
        {
            Persona.NumeroDePersonas++;
        }

        public void Saludar ()
        {
            //Saludo usando caracteristicas antiguas
            Console.WriteLine("Hola me llamo "+this.Nombre+ " tengo "+this.Anios+" años" );
            //Manejando cadena de caracteres con las nuevas caracteristicas de C#
            Console.WriteLine($"Hola me llamo {this.Nombre} tengo {this.Anios} años");
        }

        public override string ToString()
        {
            return $"Hola me llamo {this.Nombre} tengo {this.Anios} años";
        }

    }

    public enum Sexo {
        Hombre = 1,
        Mujer = 2
    }

}
