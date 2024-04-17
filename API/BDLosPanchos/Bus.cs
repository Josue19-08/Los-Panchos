using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LosPanchosDB
{
    public class Bus
    {
        [Key]
        public string placa { get; set; }
        public string modelo { get; set; }
        public int rutaRamalID { get; set; }
        [ForeignKey("rutaRamalID")]
        public virtual RutaRamal RutaRamal { get; set; }
    }
}
