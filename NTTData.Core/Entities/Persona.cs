using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NTTData.Core.Entities
{
    public partial class Persona
    {
        public Persona()
        {
            Clientes = new HashSet<Cliente>();
        }

        [Key]
        public int Personaid { get; set; }
        public string? Nombre { get; set; }
        public string? Genero { get; set; }
        public int? Edad { get; set; }
        public string? Identificacion { get; set; }
        public string? Dirección { get; set; }
        public string? Teléfono { get; set; }

        public virtual ICollection<Cliente> Clientes { get; set; }
    }
}
