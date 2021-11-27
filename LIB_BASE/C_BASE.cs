using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;

namespace LIB_BASE
{
    public class C_BASE
    {
        // ----------- collections des Json -----------
        List<C_ENTREPRISE> les_entreprises = new List<C_ENTREPRISE>();
        List<C_AUDIT> les_audits = new List<C_AUDIT>();
        List<C_METRIQUE> les_metriques = new List<C_METRIQUE>();

        // ----------- Nom des ficiers d'écriture et de lecture -----------
        const string file_entreprise = "entreprises.dat";
        const string file_audit = "audits.dat";
        const string file_metrique = "metriques.dat";

        // ----------- instance de cryptage -----------
        EncryptionHelper le_cryptage = new EncryptionHelper();


        // ------------------------------------ Constructeur de décryptage et de lecture des fichiers dat --------------------------------------
        public C_BASE()
        {
            if (File.Exists(file_entreprise))
            {
                string data_entreprises = File.ReadAllText(file_entreprise);
                string data_entreprises_decrypt = le_cryptage.Decrypt(data_entreprises);
                les_entreprises = JsonSerializer.Deserialize<List<C_ENTREPRISE>>(data_entreprises_decrypt);
            }
            if (File.Exists(file_audit))
            {
                string data_audits = File.ReadAllText(file_audit);
                string data_audits_decrypt = le_cryptage.Decrypt(data_audits);
                les_audits = JsonSerializer.Deserialize<List<C_AUDIT>>(data_audits_decrypt);
            }
            if (File.Exists(file_metrique))
            {
                string data_metriques = File.ReadAllText(file_metrique);
                string data_metriques_decrypt = le_cryptage.Decrypt(data_metriques);
                les_metriques = JsonSerializer.Deserialize<List<C_METRIQUE>>(data_metriques_decrypt);
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
            foreach (var item in les_entreprises)
            {
                if (item.id_entreprise == P_idEntreprise)
                {
                    les_entreprises.RemoveAt(Convert.ToInt32(item));
                    break;
                }
            }
        }
        public void Supprimer_audit(string P_idAudit)
        {
            foreach (var item in les_audits)
            {
                if (item.id_audit == P_idAudit)
                {
                    les_entreprises.RemoveAt(Convert.ToInt32(item));
                    break;
                }
            }
        }
        public void Supprimer_metrique(string P_idMetrique)
        {
            foreach (var item in les_metriques)
            {
                if (item.id_metrique == P_idMetrique)
                {
                    les_entreprises.RemoveAt(Convert.ToInt32(item));
                    break;
                }
            }
        }

        //------- Modifier ------
        public void Modifier_entreprise(string P_idEntreprise, string P_nomEntreprise, string P_adresseEntreprise)
        {
            foreach (var item in les_entreprises)
            {
                if (item.id_entreprise == P_idEntreprise)
                {
                    les_entreprises.RemoveAt(Convert.ToInt32(item));
                    les_entreprises.Add(new C_ENTREPRISE() {id_entreprise = auto_increment_entreprise(), nom_entreprise = P_nomEntreprise, adresse_entreprise = P_adresseEntreprise});

                    break;
                }
            }
        }
        public void Modifier_audit(string P_idAudit, string P_nomAudit)
        {
            foreach (var item in les_audits)
            {
                if (item.id_audit == P_idAudit)
                {
                    les_audits.RemoveAt(Convert.ToInt32(item));
                    les_audits.Add(new C_AUDIT() { id_audit = auto_increment_audit(), nom_audit = P_nomAudit, id_entreprise = item.id_entreprise});

                    break;
                }
            }
        }
        public void Modifier_metrique(string P_idMetrique, string P_nomFaille, int P_criticite, string P_description)
        {
            foreach (var item in les_metriques)
            {
                if (item.id_metrique == P_idMetrique)
                {
                    les_metriques.RemoveAt(Convert.ToInt32(item));
                    les_metriques.Add(new C_METRIQUE() { id_metrique = auto_increment_metrique(), nom_faille = P_nomFaille, criticite = P_criticite, description = P_description, id_audit = item.id_audit });

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
                string entreprise_serialize = JsonSerializer.Serialize<List<C_ENTREPRISE>>(les_entreprises);
                string entreprise_crypt = le_cryptage.Encrypt(entreprise_serialize);
                File.WriteAllText(file_entreprise, entreprise_crypt);
            }
            else
            {
                string entreprise_serialize = JsonSerializer.Serialize<List<C_ENTREPRISE>>(les_entreprises);
                string entreprise_crypt = le_cryptage.Encrypt(entreprise_serialize);
                File.WriteAllText(file_entreprise, entreprise_crypt);
            }


            if (File.Exists(file_audit))
            {
                suppression_json_audit();
                string audit_serialize = JsonSerializer.Serialize<List<C_AUDIT>>(les_audits);
                string audit_crypt = le_cryptage.Encrypt(audit_serialize);
                File.WriteAllText(file_audit, audit_crypt);
            }
            else
            {
                string audit_serialize = JsonSerializer.Serialize<List<C_AUDIT>>(les_audits);
                string audit_crypt = le_cryptage.Encrypt(audit_serialize);
                File.WriteAllText(file_audit, audit_crypt);
            }


            if (File.Exists(file_metrique))
            {
                suppression_json_metrique();
                string metrique_serialize = JsonSerializer.Serialize<List<C_METRIQUE>>(les_metriques);
                string metrique_crypt = le_cryptage.Encrypt(metrique_serialize);
                File.WriteAllText(file_metrique, metrique_crypt);
            }
            else
            {
                string metrique_serialize = JsonSerializer.Serialize<List<C_METRIQUE>>(les_metriques);
                string metrique_crypt = le_cryptage.Encrypt(metrique_serialize);
                File.WriteAllText(file_metrique, metrique_crypt);
            }

        }


        // ------------------------------------ Retourne la collection entière --------------------------------------
        public List<C_ENTREPRISE> get_all_entreprises()
        {
            return les_entreprises;
        }


        // ------------------------------------ Retourne la collection trié par nom filtrer --------------------------------------
        public List<C_ENTREPRISE> get_entreprise_byName(string P_nomEntreprise)
        {
            var req = from une_entreprise
                      in les_entreprises
                      where une_entreprise.nom_entreprise.Contains(P_nomEntreprise)
                      select une_entreprise;

            return new List<C_ENTREPRISE>(req);
        }
        public List<C_AUDIT> get_audit_byName(string P_nomAudit, List<C_AUDIT> P_les_audits)
        {
            var req = from un_audit
                      in P_les_audits
                      where un_audit.nom_audit.Contains(P_nomAudit)
                      select un_audit;

            return new List<C_AUDIT>(req);
        }


        // ------------------------------------ Retourne la collection par trié par Id --------------------------------------
        public List<C_AUDIT> get_audit_by_idEntreprise(string P_idEntreprise)
        {
            var req = from un_audit
                      in les_audits
                      where un_audit.id_entreprise == P_idEntreprise
                      select un_audit;

            return new List<C_AUDIT>(req);
        }
        public List<C_METRIQUE> get_metrique_by_idAudit(string P_idAudit)
        {
            var req = from une_metrique
                      in les_metriques
                      where une_metrique.id_audit == P_idAudit
                      select une_metrique;

            return new List<C_METRIQUE>(req);
        }
    }
}
