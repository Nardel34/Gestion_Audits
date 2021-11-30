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

            Console.WriteLine(la_base.auto_increment_entreprise());

            for (int i = 0; i < 15; i++)
            {

                C_METRIQUE une_metrique = new C_METRIQUE()
                {
                    id_metrique = $"{i}",
                    nom_faille = $"Méga faille_{i}",
                    criticite = 40,
                    description = $"Elle a tout cassé_{i}",
                    nom_liaison = $"j{i}",
                    label_courbe = "aha",
                    id_audit = $"{i}"
                };

                la_base.Ajouter_metrique(une_metrique);
            }
            la_base.Encryptage();

            //Console.WriteLine();
            //la_base.Modifier_entreprise("9", "Test", "Residence Test");
            //ObservableCollection<C_ENTREPRISE> test = la_base.get_all_entreprises();



            //la_base.suppression_json_entreprise();
            //la_base.suppression_json_audit();
            //la_base.suppression_json_metrique();
        }
    }
}
