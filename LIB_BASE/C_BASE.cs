using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using System.Security.AccessControl;

namespace LIB_BASE
{
    public class C_BASE
    {
        List<C_AUDIT> les_audits;
        List<C_METRIQUE> les_metriques;
        const string file_audit = "audits.json";
        const string file_metrique = "metriques.json";

        public C_BASE()
        {
            //string data_audits = File.ReadAllText("audits.json");
            //les_audits = JsonSerializer.Deserialize<List<C_AUDIT>>(data_audits);
            
            //string data_metriques = File.ReadAllText("metriques.json");
            //les_metriques = JsonSerializer.Deserialize<List<C_METRIQUE>>(data_audits);
        }
        public void suppression_json_audit()
        {
            File.Delete(file_audit);
        }
        public void suppression_json_metrique()
        {
            File.Delete(file_metrique);
        }
        public void Encryptage()
        {
            if (File.Exists(file_audit))
            {
                suppression_json_audit();
                string audit_serialize = JsonSerializer.Serialize<List<C_AUDIT>>(les_audits);
                File.WriteAllText(file_audit, audit_serialize);
            }
            else
            {
                string audit_serialize = JsonSerializer.Serialize<List<C_AUDIT>>(les_audits);
                File.WriteAllText(file_audit, audit_serialize);
            }

            if (File.Exists(file_metrique))
            {
                suppression_json_metrique();
                string metrique_serialize = JsonSerializer.Serialize<List<C_METRIQUE>>(les_metriques);
                File.WriteAllText(file_metrique, metrique_serialize);
            }
            else
            {
                string metrique_serialize = JsonSerializer.Serialize<List<C_METRIQUE>>(les_metriques);
                File.WriteAllText(file_metrique, metrique_serialize);
            }
            
        }
        public void ajouter_audit(C_AUDIT P_audit)
        {
            les_audits.Add(P_audit);
        }
        public void ajouter_metrique(C_METRIQUE P_metrique)
        {
            les_metriques.Add(P_metrique);
        }
    }
}
