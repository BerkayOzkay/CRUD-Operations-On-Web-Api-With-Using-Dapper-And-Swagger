using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperWeb.Model
{
    public class Staff
    {
        public Guid SiparisKod { get; set; }
        public int Miktar { get; set; }
        public string Ad { get; set; }
        public float Maliyet { get; set; }
    }
}
