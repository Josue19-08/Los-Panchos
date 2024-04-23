using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BDLosPanchos;

namespace LosPanchosDB
{
    public class Tiquete
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string email { get; set; }
        public int viajeID { get; set; }
        [ForeignKey("viajeID")]
        public virtual Viaje Viaje { get; set; }

        public float costo {  get; set; }
        public string asiento { get; set; }
    }
}
