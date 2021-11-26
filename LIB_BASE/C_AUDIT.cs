using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIB_BASE
{
    public class C_AUDIT
    {
        public int id_audit { get; set; }
        public string nom_audit { get; set; }
        public DateTime date_audit { get; set; }
        public int id_entreprise { get; set; }
    }
}
