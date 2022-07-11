using System;
using System.Collections.Generic;

namespace NTTData.Core.Entities
{
    public partial class Movimiento
    {
        public int Movimientoid { get; set; }
        public int? Clienteid { get; set; }
        public DateTime? Fecha { get; set; }
        public string? Tipomovimiento { get; set; }
        public decimal? Valor { get; set; }
        public decimal? Saldo { get; set; }
        public decimal? SaldoInicial { get; set; }

        public virtual Cliente? Cliente { get; set; }
    }
}
