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
    public class AsientoDTO
    {
        public int id { get; set; }
        public int numAsiento { get; set; }
        public int? tiqueteID { get; set; }
        public string busID { get; set; }
    }
}
