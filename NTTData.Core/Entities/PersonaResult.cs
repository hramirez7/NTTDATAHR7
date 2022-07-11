using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTTData.Core.Entities
{
    public class PersonaResult
    {
        public int Clienteid { get; set; }
        public int? Personaid { get; set; }
        public string? Contrasena { get; set; }
        public bool? Estado { get; set; }
        public string? Nombre { get; set; }
        public string? Genero { get; set; }
        public int? Edad { get; set; }
        public string? Identificacion { get; set; }
        public string? Dirección { get; set; }
        public string? Teléfono { get; set; }

    }
}
