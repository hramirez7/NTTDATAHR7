using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTTData.Core.Entities
{
    public class CuentaEntrada
    {
        public string? Identificacion { get; set; }
        public string? numerocuenta { get; set; }
        public string? tipocuenta { get; set; }
        public decimal? saldoInicial { get; set; }
        public bool? Estado { get; set; }

    }
}