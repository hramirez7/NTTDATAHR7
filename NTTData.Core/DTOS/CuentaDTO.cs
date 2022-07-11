using System;
using System.Collections.Generic;

namespace NTTData.Core.DTOS
{
    public partial class CuentaDTO : ClienteDTO
    {
        public int Cuentaid { get; set; }
        public int? Clienteid { get; set; }
        public string? Numerocuenta { get; set; }
        public string? Tipocuenta { get; set; }
        public decimal? SaldoInicial { get; set; }
        public bool? Estado { get; set; }
    }
}
