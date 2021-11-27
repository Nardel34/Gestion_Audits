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

            Console.WriteLine(la_base.auto_increment_entreprise());

            //for (int i = 0; i < 15; i++)
            //{
            //    C_ENTREPRISE une_entreprise = new C_ENTREPRISE()
            //    {
            //        id_entreprise = $"{i}",
            //        nom_entreprise = $"Entreprise_{i}",
            //        adresse_entreprise = $"Résidence Entreprise_{i}"
            //    };
            //    C_AUDIT un_audit = new C_AUDIT()
            //    {
            //        id_audit = $"{i}",
            //        nom_audit = $"Audit_{i}",
            //        date_audit = DateTime.Now,
            //        id_entreprise = $"{i}"
            //    };
            //    C_METRIQUE une_metrique = new C_METRIQUE()
            //    {
            //        id_metrique = $"{i}",
            //        nom_faille = $"Méga faille_{i}",
            //        criticite = 40,
            //        description = $"Elle a tout cassé_{i}",
            //        id_audit = $"{i}"
            //    };
            //    la_base.Ajouter_entreprise(une_entreprise);
            //    la_base.Ajouter_audit(un_audit);
            //    la_base.Ajouter_metrique(une_metrique);
            //}
            //la_base.Encryptage();

            //Console.WriteLine();
            //List<C_ENTREPRISE> test = la_base.get_all_entreprises();

            //foreach (var item in test)
            //{
            //    Console.WriteLine(item.id_entreprise);
            //}

            //la_base.suppression_json_entreprise();
            //la_base.suppression_json_audit();
            //la_base.suppression_json_metrique();
        }
    }
}
