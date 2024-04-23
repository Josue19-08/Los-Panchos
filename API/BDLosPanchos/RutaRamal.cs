using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace LosPanchosDB
{
    public class RutaRamal
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        public int rutaID { get; set; }
        [ForeignKey("rutaID")]
        public virtual Ruta Ruta { get; set; }

        public int ramalID { get; set; }
        [ForeignKey("ramalID")]
        public virtual Ramal Ramal { get; set; }

    }
}
