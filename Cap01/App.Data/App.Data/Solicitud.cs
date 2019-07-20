using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Base
{
    public class Solicitud
    {
        //Atributos u propiedades de una clase - get para q le asigne un valor - set para asignar un valor
        public int NroSolicitud { get; set; }
        public DateTime Fecha { get; set; }
        public string Solicitante { get; set; }
        public int Estado { get; set; }
        public string DetalleSolicitud { get; set; }

        //virtual para poder sobreescibirlo 
        public virtual bool Aprobar()
        {
            return true;
        }
    }
}
