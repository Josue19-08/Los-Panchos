using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LosPanchosDB
{
    public class Ruta
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string origen { get; set; }
        public string destino { get; set; }
        public int km { get; set; }
        public DateTime horaSalida { get; set; }
        public DateOnly fechaViaje { get; set; }
    }
}
