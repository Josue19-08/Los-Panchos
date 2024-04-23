using LosPanchosDB;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDLosPanchos
{
    public class ViajeDTO
    {
       public int Id { get; set; }
        public DateOnly FechaViaje { get; set; }
        public DateTime HoraViaje { get; set; }
        public float Costo { get; set; }
        public int DuracionMinutos { get; set; }
        public int RutaRamalID { get; set; }
        public string Origen { get; set; } 
        public string Destino { get; set; }
        public string Ramal { get; set; }
        public string BusID { get; set; }
    }
}
