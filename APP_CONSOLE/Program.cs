using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

            //for (int i = 1; i < 15; i++)
            //{
            //    C_ENTREPRISE une_entreprise = new C_ENTREPRISE()
            //    {
            //        id_entreprise = $"{i}",
            //        nom_entreprise = $"Entreprise_{i}",
            //        adresse_entreprise = $"Adresse_{i}",
            //    };
            //    la_base.Ajouter_entreprise(une_entreprise);
                
            //}
            for (int i2 = 1; i2 < 15; i2++)
            {
                C_AUDIT un_audit = new C_AUDIT()
                {
                    id_audit = $"{i2}",
                    nom_audit = $"Audit_{i2}",
                    date_audit = DateTime.Now,
                    id_entreprise = $"1"
                };
                //la_base.Ajouter_audit(un_audit);

                for (int i3 = 1; i3 < 15; i3++)
                {
                    C_METRIQUE une_metrique = new C_METRIQUE()
                    {
                        id_metrique = $"{i3}",
                        nom_faille = $"Faille_{i3}",
                        criticite = 40,
                        description = $"Lorem ipsum dolor sit amet. Aut aliquam voluptatem sed odio similique hic tempore dolor ea eligendi voluptatibus. Ut vero voluptas a quaerat exercitationem eos necessitatibus iure sed eius numquam.",
                        nom_liaison = $"j{i3}",
                        label_courbe = $"Label{i3}",
                        id_audit = $"{i2}"
                    };
                    la_base.Ajouter_metrique(une_metrique);
                }
            }
            la_base.Encryptage();
            //la_base.Supprimer_entreprise("1");

            //foreach (var item in la_base.les_entreprises)
            //{
            //    Console.WriteLine(item.nom_entreprise);
            //}
            //foreach (var item in la_base.les_audits)
            //{
            //    Console.WriteLine($"{item.nom_audit}, {item.id_entreprise}");
            //}
            foreach (var item in la_base.les_metriques)
            {
                Console.WriteLine(item.id_audit);
            }

            //la_base.suppression_json_entreprise();
            //la_base.suppression_json_audit();
            //la_base.suppression_json_metrique();
            //la_base.Supprimer_metrique("3");
            //foreach (var item in la_base.les_metriques)
            //{
            //    Console.WriteLine($"{item.id_metrique} : {item.nom_faille}");
            //}
        }
    }
}
