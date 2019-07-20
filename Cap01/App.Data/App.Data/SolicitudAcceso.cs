using App.Data.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data
{
    public class SolicitudAcceso: Solicitud
    {
        public int NivelAcceso { get; set; }
        //override - sobre escribir
        public override bool Aprobar()
        {
            var resultado = false;

            if (this.NivelAcceso > 2) //No es Administrador
                resultado = true;

            return resultado;
        }
    }
}
