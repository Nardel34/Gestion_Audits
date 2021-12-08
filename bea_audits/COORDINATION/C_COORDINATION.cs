using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LIB_BASE;
using bea_audits.ABSTRACTION;

namespace bea_audits.COORDINATION
{
    class C_COORDINATION : C_NOTIFIABLE
    {
        C_BASE la_base;
        C_ILLUSTRATOR un_illustrator = C_ILLUSTRATOR.Get_Instance();

        // ------------------------------------ Données membres avec ascesseurs et mutateurs --------------------------------------
        private ObservableCollection<C_ENTREPRISE> _liste_entreprises;
        public ObservableCollection<C_ENTREPRISE> liste_entreprises
        {
            get { return _liste_entreprises; }
            set { _liste_entreprises = value; Signal_changement(); }
        }

        private ObservableCollection<C_AUDIT> _liste_audits;
        public ObservableCollection<C_AUDIT> liste_audits
        {
            get { return _liste_audits; }
            set { _liste_audits = value; Signal_changement(); }
        }

        private ObservableCollection<C_METRIQUE> _liste_metriques;
        public ObservableCollection<C_METRIQUE> liste_metriques
        {
            get { return _liste_metriques; }
            set { _liste_metriques = value; Signal_changement(); }
        }

        private C_ENTREPRISE _entreprise_selectionnee;
        public C_ENTREPRISE entreprise_selectionnee
        {
            get { return _entreprise_selectionnee; }
            set { _entreprise_selectionnee = value; Signal_changement(); }
        }

        private C_AUDIT _audit_selectionnee;
        public C_AUDIT audit_selectionnee
        {
            get { return _audit_selectionnee; }
            set { _audit_selectionnee = value; Signal_changement(); }
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


        // ------------------------------------ Récupération de collections par Id --------------------------------------
        public void get_audit_by_idEntreprise()
        {
            if (entreprise_selectionnee != null)
            {
                liste_audits = la_base.get_audit_by_idEntreprise(entreprise_selectionnee.id_entreprise);
            }
        }
        public void get_metrique_by_idAudit()
        {
            if (audit_selectionnee != null)
            {
                liste_metriques = la_base.get_metrique_by_idAudit(audit_selectionnee.id_audit);
            }
        }


        // ------------------------------------ Fonction d'encryptage et d'écriture dans les fichiers dat --------------------------------------
        public void sauvegarder()
        {
            la_base.Encryptage();
        }


        // ------------------------------------ Fonctions de CRUD aux collections --------------------------------------
        // --------- Ajouter un objet de la collection -------------
        public void ajoute_entreprise(string P_nomEntreprise, string P_adresseEntreprise)
        {
            if (P_nomEntreprise != "")
            {
                C_ENTREPRISE une_entreprise = new C_ENTREPRISE() { id_entreprise = la_base.auto_increment_entreprise(), nom_entreprise = P_nomEntreprise, adresse_entreprise = P_adresseEntreprise };
                la_base.Ajouter_entreprise(une_entreprise);
                //liste_entreprises.Add(une_entreprise);

                sauvegarder();
            }
        }
        public void ajoute_audit_by_idEntreprise(string P_nomAudit, string P_idEntreprise)
        {
            if (P_nomAudit != "")
            {
                C_AUDIT un_audit = new C_AUDIT() { id_audit = la_base.auto_increment_audit(), nom_audit = P_nomAudit, date_audit = DateTime.Now, id_entreprise = P_idEntreprise };
                la_base.Ajouter_audit(un_audit);
                //liste_audits.Add(un_audit);

                sauvegarder();
            }
        }
        public void ajoute_metrique_by_idAudit(string P_nomFaille, int P_criticite, string P_description, string P_nomLiaison, string P_labelCourbe, string P_idAudit)
        {
            if (P_nomFaille != "" && P_description != "")
            {
                if (P_criticite != 0)
                {
                    C_METRIQUE une_metrique = new C_METRIQUE() { id_metrique = la_base.auto_increment_metrique(), nom_faille = P_nomFaille, criticite = P_criticite, description = P_description, nom_liaison = P_nomLiaison, label_courbe = P_labelCourbe, id_audit = P_idAudit };
                    la_base.Ajouter_metrique(une_metrique);
                    //liste_metriques.Add(une_metrique);

                    sauvegarder();
                }
            }
        }


        // --------- Supprimer un objet de la collection -----------
        public void supprime_entreprise(string P_idEntreprise)
        {
            if (entreprise_selectionnee != null)
            {
                la_base.Supprimer_entreprise(P_idEntreprise);
                sauvegarder();
            }
        }
        public void supprime_audit(string P_idAudit)
        {
            if (audit_selectionnee != null)
            {
                la_base.Supprimer_audit(P_idAudit);
                sauvegarder();
            }
        }
        public void supprime_metrique(string P_idMetrique)
        {
            if (metrique_selectionnee != null)
            {
                la_base.Supprimer_metrique(P_idMetrique);
                sauvegarder();
            }
        }
        // ---------- Modifier un objet de la collections -----------
        public void modifier_entreprise(string P_idEntreprise, string P_nomEntreprise, string P_adresseEntreprise)
        {
            la_base.Modifier_entreprise(P_idEntreprise, P_nomEntreprise, P_adresseEntreprise);
            sauvegarder();
        }
        public void modifier_audit(string P_idAudit, string P_nomAudit)
        {
            la_base.Modifier_audit(P_idAudit, P_nomAudit);
            sauvegarder();
        }
        public void modifier_metrique(string P_idMetrique, string P_nomFaille, int P_criticite, string P_description, string P_nomLiaison, string P_nomLabel)
        {
            la_base.Modifier_metrique(P_idMetrique, P_nomFaille, P_criticite, P_description, P_nomLiaison, P_nomLabel);
            sauvegarder();
        }


        //----------------------- Mise en page Illustrator -----------------
        public void Mise_A_jour_Illustrator_sphere()
        {
            if (metrique_selectionnee != null)
            {
                un_illustrator.Ajoute_Jauge(metrique_selectionnee.nom_liaison, metrique_selectionnee.label_courbe, metrique_selectionnee.criticite);
            }
        }
        public void Mise_A_jour_Illustrator_block()
        {
            if (metrique_selectionnee != null)
            {
                la_base.Ajoute_block_text(metrique_selectionnee.nom_liaison, metrique_selectionnee.description);
            }
        }
    }
}
