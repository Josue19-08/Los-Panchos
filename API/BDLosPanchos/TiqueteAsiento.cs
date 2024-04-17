using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LosPanchosDB
{
    public class TiqueteAsiento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        public int tiqueteID { get; set; }
        [ForeignKey("tiqueteID")]
        public virtual Tiquete Tiquete { get; set; }

        public int asientoID { get; set; }
        [ForeignKey("asientoID")]
        public virtual Asiento Asiento { get; set; }
    }
}
