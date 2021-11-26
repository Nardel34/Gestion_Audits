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


        // ------------------------------------ Fonctions d'ajouts aux collections --------------------------------------
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
        public List<C_AUDIT> get_audit_by_idEntreprise(int P_idEntreprise)
        {
            var req = from un_audit
                      in les_audits
                      where un_audit.id_entreprise == P_idEntreprise
                      select un_audit;

            return new List<C_AUDIT>(req);
        }
        public List<C_METRIQUE> get_metrique_by_idAudit(int P_idAudit)
        {
            var req = from une_metrique
                      in les_metriques
                      where une_metrique.id_audit == P_idAudit
                      select une_metrique;

            return new List<C_METRIQUE>(req);
        }
    }
}
