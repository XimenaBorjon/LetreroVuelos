using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LetreroVuelos.Models
{
    public class Vuelo
    {
        public int IdVuelo { get; set; }
        public DateTime Hora { get; set; }
        public string Destino { get; set; } = null!;
        public string Status { get; set; } = null!;
        public string ClaveVuelo { get; set; } = null!;
    }
}
