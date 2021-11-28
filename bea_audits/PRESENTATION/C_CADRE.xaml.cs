﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using bea_audits.COORDINATION;

namespace bea_audits.PRESENTATION
{
    /// <summary>
    /// Logique d'interaction pour C_CADRE_ajout_entreprise.xaml
    /// </summary>
    public partial class C_CADRE : Window
    {
        string idEntreprise;
        string idAudit;
        string Type;
        C_COORDINATION la_coordination;
        public C_CADRE(string P_Type, string P_idEntreprise_Selectionnee = null, string P_idAudit_selectionnee = null)
        {
            la_coordination = new C_COORDINATION();
            InitializeComponent();
            DataContext = la_coordination;

            Type = P_Type;
            idEntreprise = P_idEntreprise_Selectionnee;
            idAudit = P_idAudit_selectionnee;

            if (Type == "entreprise")
            {
                description.Visibility = Visibility.Hidden;
                label_description.Visibility = Visibility.Hidden;
                fenetre_ajouter.Width = 272.731;
            }
            else if (Type == "audit")
            {
                titre_ajout.Content = "AJOUTER UN AUDIT";
                description.Visibility = Visibility.Hidden;
                label_description.Visibility = Visibility.Hidden;
                label_adresse.Visibility = Visibility.Hidden;
                adresse.Visibility = Visibility.Hidden;
                fenetre_ajouter.Width = 272.731;
            }
            else if (Type == "metrique")
            {
                titre_ajout.Content = "AJOUTER UNE METRIQUE";
                label_adresse.Content = "Critité (%) :";
            }
        }

        private void BTN_ajouter_Click(object sender, RoutedEventArgs e)
        {
            if (Type == "entreprise")
            {
                la_coordination.ajoute_entreprise(nom.Text, adresse.Text);
            }
            else if (Type == "audit")
            {
                la_coordination.ajoute_audit_by_idEntreprise(nom.Text, idEntreprise);
            }
            else if (Type == "metrique")
            {
                la_coordination.ajoute_metrique_by_idAudit(nom.Text, Convert.ToInt32(adresse.Text), description.Text, idAudit);
            }
            Close();
        }

        private void BTN_annule_ajout_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
