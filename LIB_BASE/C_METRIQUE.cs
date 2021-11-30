using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LIB_BASE
{
    public class C_METRIQUE
    {
        public string id_metrique { get; set; }
        public string nom_faille { get; set; }
        public int criticite { get; set; }
        public string description { get; set; }
        public string nom_liaison { get; set; }
        public string label_courbe { get; set; }
        public string id_audit { get; set; }
    }
}
