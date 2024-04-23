using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LosPanchosDB;

namespace BDLosPanchos
{
    public class Viaje
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public DateOnly fechaViaje { get; set; }
        public DateTime horaViaje { get; set; }
        public int duracionMinutos { get; set; }
        public int rutaRamalID { get; set; }
        [ForeignKey("rutaRamalID")]
        public virtual RutaRamal RutaRamal { get; set; }

        public string busID { get; set; }
        [ForeignKey("busID")]
        public virtual Bus Bus { get; set; }

    }
}
