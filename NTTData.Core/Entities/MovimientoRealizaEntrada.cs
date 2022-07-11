using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTTData.Core.Entities
{
    public class MovimientoRealizaEntrada
    {
        public string Identificaccion { get; set; }
        public string TipoCuenta { get; set; }
        public decimal MovimientoValor { get; set; }
        public string TipoMovimiento { get; set; }

    }
}