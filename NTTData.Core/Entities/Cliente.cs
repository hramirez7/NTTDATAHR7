using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NTTData.Core.Entities
{
    public partial class Cliente
    {
        [Key]
        public int Clienteid { get; set; }
        public int? Personaid { get; set; }
        public string? Contrasena { get; set; }
        public bool? Estado { get; set; }

        public virtual Persona? Persona { get; set; }
    }
}
