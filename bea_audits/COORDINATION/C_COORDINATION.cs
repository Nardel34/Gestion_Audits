using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LIB_BASE;

namespace bea_audits.COORDINATION
{
    class C_COORDINATION : C_NOTIFIABLE
    {
        C_BASE la_base;


        // ------------------------------------ Données membres avec ascesseurs et mutateurs --------------------------------------
        private List<C_ENTREPRISE> _liste_entreprises;
        public List<C_ENTREPRISE> liste_entreprises
        {
            get { return _liste_entreprises; }
            set { _liste_entreprises = value; Signal_changement(); }
        }

        private List<C_AUDIT> _liste_audits;
        public List<C_AUDIT> liste_audits
        {
            get { return _liste_audits; }
            set { _liste_audits = value; Signal_changement(); }
        }

        private List<C_METRIQUE> _liste_metriques;
        public List<C_METRIQUE> liste_metriques
        {
            get { return _liste_metriques; }
            set { _liste_metriques = value; Signal_changement(); }
        }

        private C_METRIQUE _metrique_selectionnee;
        public C_METRIQUE metrique_selectionnee
        {
            get { return _metrique_selectionnee; }
            set { _metrique_selectionnee = value; Signal_changement(); }
        }
        // ------------------------------------ Constructeur de recupération des collections de C_BASE dans les données membres de C_COORDINATION --------------------------------------
        public C_COORDINATION()
        {
            la_base = new C_BASE();
            liste_entreprises = la_base.get_all_entreprises();
        }


        // ------------------------------------ fonction de filtre par le Nom --------------------------------------
        public void trier_les_entreprises(string P_nomEntreprise)
        {
            if (P_nomEntreprise == "")
            {
                liste_entreprises = la_base.get_all_entreprises();
            }
            else
            {
                liste_entreprises = la_base.get_entreprise_byName(P_nomEntreprise);
            }
        }
        public void trier_les_audits(string P_nomAudit)
        {
            if (P_nomAudit != "")
            {
                liste_audits = la_base.get_audit_byName(P_nomAudit, liste_audits);
            }
        }
        // ------------------------------------ Récupération de collections par Id --------------------------------------
        public void get_audit_by_idEntreprise(int P_idEntreprise)
        {
            liste_audits = la_base.get_audit_by_idEntreprise(P_idEntreprise);
        }
        public void get_metrique_by_idAudit(int P_idAudit)
        {
            liste_metriques = la_base.get_metrique_by_idAudit(P_idAudit);
        }


        // ------------------------------------ Fonction d'encryptage et d'écriture dans les fichiers dat --------------------------------------
        public void sauvegarder()
        {
            la_base.Encryptage();
        }


        // ------------------------------------ Fonctions d'ajout aux collections --------------------------------------
        public void ajoute_entreprise(string P_nomEntreprise, string P_adresseEntreprise)
        {
            if (P_nomEntreprise != "")
            {
                C_ENTREPRISE une_entreprise = new C_ENTREPRISE() { nom_entreprise = P_nomEntreprise, adresse_entreprise = P_adresseEntreprise };
                liste_entreprises.Add(une_entreprise);
                la_base.Ajouter_entreprise(une_entreprise);

                sauvegarder();
            }
        }
        public void ajoute_audit_by_idEntreprise(string P_nomAudit, int P_idEntreprise)
        {
            if (P_nomAudit != "")
            {
                C_AUDIT un_audit = new C_AUDIT() { nom_audit = P_nomAudit, date_audit = DateTime.Now, id_entreprise = P_idEntreprise };
                liste_audits.Add(un_audit);
                la_base.Ajouter_audit(un_audit);

                sauvegarder();
            }
        }
        public void ajoute_metrique_by_idAudit(string P_nomFaille, int P_criticite, string P_description, int P_idAudit)
        {
            if (P_nomFaille != "" && P_description != "")
            {
                if (P_criticite != 0)
                {
                    C_METRIQUE une_metrique = new C_METRIQUE() { nom_faille = P_nomFaille, criticite = P_criticite, description = P_description, id_audit = P_idAudit };
                    liste_metriques.Add(une_metrique);
                    la_base.Ajouter_metrique(une_metrique);

                    sauvegarder();
                }
                //else
                //{
                //    string err = "La criticité ne peux pas être Null";
                //}
            }
            //else
            //{
            //    string err = "Veuillez remplir les tous champs ou Annuler";
            //}
        }
    }
}
