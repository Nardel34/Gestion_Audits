using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LIB_BASE;


namespace APP_CONSOLE
{
    class Program
    {
        static void Main(string[] args)
        {
            C_BASE la_base = new C_BASE();

            C_AUDIT un_audit = new C_AUDIT()
            {
                id_audit = 1,
                nom_entreprise = "test",
                adresse_entreprise = "residence test",
                date_audit = DateTime.Now
            };
            C_METRIQUE une_metrique = new C_METRIQUE()
            {
                id_metrique = 1,
                nom_faille = "chocapic",
                criticite = 40,
                description = "tatoucassé",
                id_audit = 1
            };

            la_base.ajouter_audit(un_audit);
            la_base.ajouter_metrique(une_metrique);

            la_base.Encryptage();
            
        }
    }
}
