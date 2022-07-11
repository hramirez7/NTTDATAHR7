using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTTData.Core.DTOS
{
    public class ClienteDTO : PersonaDTO
    {
        public int Clienteid { get; set; }
        public int? IdPersona { get; set; }
        public string? Contrasena { get; set; }
        public bool? Estado { get; set; }
    }
}
