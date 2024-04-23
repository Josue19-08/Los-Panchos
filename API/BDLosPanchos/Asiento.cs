using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LosPanchosDB
{
    public class Asiento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public int numAsiento { get; set; }
        public int? tiqueteID { get; set; } 
        [ForeignKey("tiqueteID")]
        public virtual Tiquete Tiquete { get; set; }
        public string busID { get; set; } 
        [ForeignKey("busID")]
        public virtual Bus Bus { get; set; }
    }
}
