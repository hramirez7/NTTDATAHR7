using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NTTData.Core.Entities
{
    public partial class Cuenta
    {
        [Key]
        public int Cuentaid { get; set; }
        public int? Clienteid { get; set; }
        public string? Numerocuenta { get; set; }
        public string? Tipocuenta { get; set; }
        public decimal? SaldoInicial { get; set; }
        public bool? Estado { get; set; }

        public virtual Cliente? Cliente { get; set; }
    }
}
