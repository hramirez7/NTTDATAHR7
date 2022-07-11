using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTTData.Core.DTOS
{
    public class MovimientoEntradaDTO
    {
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinal { get; set; }
        public string Identificacion { get; set; }

    }
}
