using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDLosPanchos
{
    public class TiqueteDTO
    {
        public int id { get; set; }
        public string email { get; set; }
        public int viajeID { get; set; }
        public float costo { get; set; }
        public string asiento { get; set; }

    }
}
