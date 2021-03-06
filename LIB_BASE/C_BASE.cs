using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using System.Collections.ObjectModel;

using Illustrator;

namespace LIB_BASE
{
    public class C_BASE
    {
        // ----------- collections des Json -----------
        public ObservableCollection<C_ENTREPRISE> les_entreprises;
        public ObservableCollection<C_AUDIT> les_audits;
        public ObservableCollection<C_METRIQUE> les_metriques;

        // ----------- Nom des ficiers d'écriture et de lecture -----------
        const string file_entreprise = "entreprises.dat";
        const string file_audit = "audits.dat";
        const string file_metrique = "metriques.dat";

        // ----------- instance de cryptage -----------
        C_CRYPT le_cryptage = new C_CRYPT();


        // ------------------------------------ Constructeur de décryptage et de lecture des fichiers dat --------------------------------------
        public C_BASE()
        {
            if (File.Exists(file_entreprise))
            {
                string data_entreprises = File.ReadAllText(file_entreprise);
                string data_entreprises_decrypt = le_cryptage.Decrypt(data_entreprises);
                les_entreprises = JsonSerializer.Deserialize<ObservableCollection<C_ENTREPRISE>>(data_entreprises_decrypt);
            }
            else
            {
                les_entreprises = new ObservableCollection<C_ENTREPRISE>();
            }
            if (File.Exists(file_audit))
            {
                string data_audits = File.ReadAllText(file_audit);
                string data_audits_decrypt = le_cryptage.Decrypt(data_audits);
                les_audits = JsonSerializer.Deserialize<ObservableCollection<C_AUDIT>>(data_audits_decrypt);
            }
            else
            {
                les_audits = new ObservableCollection<C_AUDIT>();
            }
            if (File.Exists(file_metrique))
            {
                string data_metriques = File.ReadAllText(file_metrique);
                string data_metriques_decrypt = le_cryptage.Decrypt(data_metriques);
                les_metriques = JsonSerializer.Deserialize<ObservableCollection<C_METRIQUE>>(data_metriques_decrypt);
            }
            else
            {
                les_metriques = new ObservableCollection<C_METRIQUE>();
            }
        }


        // ------------------------------------ Fonctions suppression des fichiers dat --------------------------------------
        public void suppression_json_entreprise()
        {
            File.Delete(file_entreprise);
        }
        public void suppression_json_audit()
        {
            File.Delete(file_audit);
        }
        public void suppression_json_metrique()
        {
            File.Delete(file_metrique);
        }


        // ------------------------------------ Fonctions de CRUD aux collections --------------------------------------
        //------- Ajouter -------
        public void Ajouter_entreprise(C_ENTREPRISE P_entreprise)
        {
            les_entreprises.Add(P_entreprise);
        }
        public void Ajouter_audit(C_AUDIT P_audit)
        {
            les_audits.Add(P_audit);
        }
        public void Ajouter_metrique(C_METRIQUE P_metrique)
        {
            les_metriques.Add(P_metrique);
        }

        //------- Supprimer -------
        public void Supprimer_entreprise(string P_idEntreprise)
        {
            for (int i = 0; i < les_entreprises.Count; i++)
            {
                if (les_entreprises[i].id_entreprise == P_idEntreprise)
                {
                    les_entreprises.RemoveAt(i);

                    break;
                }
            }
            List<string> id_audits_supprimes = new List<string>();
            foreach (var item in les_audits.ToList())
            {
                if (item.id_entreprise == P_idEntreprise)
                {
                    les_audits.Remove(item);
                    id_audits_supprimes.Add(item.id_audit);
                }
            }
            foreach (var item in les_metriques.ToList())
            {
                foreach (var item2 in id_audits_supprimes)
                {
                    if (item2 == item.id_audit)
                    {
                        les_metriques.Remove(item);
                    }
                }
            }
        }
        public void Supprimer_audit(string P_idAudit)
        {
            for (int i = 0; i < les_audits.Count; i++)
            {
                if (les_audits[i].id_audit == P_idAudit)
                {
                    les_audits.RemoveAt(i);

                    break;
                }
            }
            foreach (var item in les_metriques.ToList())
            {
                if (item.id_audit == P_idAudit)
                {
                    les_metriques.Remove(item);
                }
            }
        }
        public void Supprimer_metrique(string P_idMetrique)
        {
            for (int i = 0; i < les_metriques.Count; i++)
            {
                if (les_metriques[i].id_metrique == P_idMetrique)
                {
                    les_metriques.RemoveAt(i);

                    break;
                }
            }
        }

        //------- Modifier ------
        public void Modifier_entreprise(string P_idEntreprise, string P_nomEntreprise, string P_adresseEntreprise)
        {
            for (int i = 0; i < les_entreprises.Count; i++)
            {
                if (les_entreprises[i].id_entreprise == P_idEntreprise)
                { 
                    les_entreprises[i].nom_entreprise = P_nomEntreprise;
                    les_entreprises[i].adresse_entreprise = P_adresseEntreprise;

                    break;
                }
            }
        }
        public void Modifier_audit(string P_idAudit, string P_nomAudit)
        {
            for (int i = 0; i < les_audits.Count; i++)
            {
                if (les_audits[i].id_audit == P_idAudit)
                {
                    les_audits[i].nom_audit = P_nomAudit;

                    break;
                }
            }
        }
        public void Modifier_metrique(string P_idMetrique, string P_nomFaille, int P_criticite, string P_description, string P_nomLiaison, string P_nomLabel)
        {
            for (int i = 0; i < les_metriques.Count; i++)
            {
                if (les_metriques[i].id_metrique == P_idMetrique)
                {
                    les_metriques[i].nom_faille = P_nomFaille;
                    les_metriques[i].criticite = P_criticite;
                    les_metriques[i].description = P_description;
                    les_metriques[i].nom_liaison = P_nomLiaison;
                    les_metriques[i].label_courbe = P_nomLabel;

                    break;
                }
            }
        }


        // ------------------------------------ Auto incrémation d'id --------------------------------------
        public string auto_increment_entreprise()
        {
            string req = les_entreprises.Last().id_entreprise;
            int last_id = 1 + Convert.ToInt32(req);

            return last_id.ToString();
        }
        public string auto_increment_audit()
        {
            string req = les_audits.Last().id_audit;
            int last_id = 1 + Convert.ToInt32(req);

            return last_id.ToString();
        }
        public string auto_increment_metrique()
        {
            string req = les_metriques.Last().id_metrique;
            int last_id = 1 + Convert.ToInt32(req);

            return last_id.ToString();
        }


        // ------------------------------------ Fonctions d'encryptage et d'écriture dans les fichiers dat --------------------------------------
        public void Encryptage()
        {
            if (File.Exists(file_entreprise))
            {
                suppression_json_entreprise();
                string entreprise_serialize = JsonSerializer.Serialize<ObservableCollection<C_ENTREPRISE>>(les_entreprises);
                string entreprise_crypt = le_cryptage.Encrypt(entreprise_serialize);
                File.WriteAllText(file_entreprise, entreprise_crypt);
            }
            else
            {
                string entreprise_serialize = JsonSerializer.Serialize<ObservableCollection<C_ENTREPRISE>>(les_entreprises);
                string entreprise_crypt = le_cryptage.Encrypt(entreprise_serialize);
                File.WriteAllText(file_entreprise, entreprise_crypt);
            }


            if (File.Exists(file_audit))
            {
                suppression_json_audit();
                string audit_serialize = JsonSerializer.Serialize<ObservableCollection<C_AUDIT>>(les_audits);
                string audit_crypt = le_cryptage.Encrypt(audit_serialize);
                File.WriteAllText(file_audit, audit_crypt);
            }
            else
            {
                string audit_serialize = JsonSerializer.Serialize<ObservableCollection<C_AUDIT>>(les_audits);
                string audit_crypt = le_cryptage.Encrypt(audit_serialize);
                File.WriteAllText(file_audit, audit_crypt);
            }


            if (File.Exists(file_metrique))
            {
                suppression_json_metrique();
                string metrique_serialize = JsonSerializer.Serialize<ObservableCollection<C_METRIQUE>>(les_metriques);
                string metrique_crypt = le_cryptage.Encrypt(metrique_serialize);
                File.WriteAllText(file_metrique, metrique_crypt);
            }
            else
            {
                string metrique_serialize = JsonSerializer.Serialize<ObservableCollection<C_METRIQUE>>(les_metriques);
                string metrique_crypt = le_cryptage.Encrypt(metrique_serialize);
                File.WriteAllText(file_metrique, metrique_crypt);
            }

        }


        // ------------------------------------ Retourne la collection entière --------------------------------------
        public ObservableCollection<C_ENTREPRISE> get_all_entreprises()
        {
            return les_entreprises;
        }


        // ------------------------------------ Retourne la collection trié par nom filtrer --------------------------------------
        public ObservableCollection<C_ENTREPRISE> get_entreprise_byName(string P_nomEntreprise)
        {
            var req = from une_entreprise
                      in les_entreprises
                      where une_entreprise.nom_entreprise.Contains(P_nomEntreprise)
                      select une_entreprise;

            return new ObservableCollection<C_ENTREPRISE>(req);
        }


        // ------------------------------------ Retourne la collection par trié par Id --------------------------------------
        public ObservableCollection<C_AUDIT> get_audit_by_idEntreprise(string P_idEntreprise)
        {
            var req = from un_audit
                      in les_audits
                      where un_audit.id_entreprise == P_idEntreprise
                      select un_audit;

            return new ObservableCollection<C_AUDIT>(req);
        }
        public ObservableCollection<C_METRIQUE> get_metrique_by_idAudit(string P_idAudit)
        {
            var req = from une_metrique
                      in les_metriques
                      where une_metrique.id_audit == P_idAudit
                      select une_metrique;

            return new ObservableCollection<C_METRIQUE>(req);
        }

        public void Ajoute_block_text(string P_nomZone, string P_textZone)
        {
            Document mon_document;
            Application mon_application = new Application();

            if (mon_application.Documents.Count == 0) mon_document = mon_application.Documents.Add();
            else mon_document = mon_application.ActiveDocument;

            TextFrame Mon_Objet = mon_document.TextFrames[P_nomZone];

            Mon_Objet.Contents = P_textZone;
        }
    }
}
