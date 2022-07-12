using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTTData.Core.Entities
{
    public class CuentaResult
    {
        public string? Numerocuenta { get; set; }
        public string? Tipocuenta { get; set; }
        public decimal? SaldoInicial { get; set; }
        public bool? Estado { get; set; }

    }
}
