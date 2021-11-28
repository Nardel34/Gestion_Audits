using System;
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
using LIB_BASE;
using bea_audits.COORDINATION;

namespace bea_audits.PRESENTATION
{
    public partial class C_CADRE_modifier : Window
    {
        C_COORDINATION la_coordination;
        string Type;
        string idEntreprise;
        string idAudit;
        string idMetrique;
        public C_CADRE_modifier(string P_Type, string P_idEntreprise_Selectionnee = null, string P_idAudit_selectionnee = null, string P_idMetrique_selectionnee = null)
        {
            la_coordination = new C_COORDINATION();
            InitializeComponent();
            DataContext = la_coordination;


            Type = P_Type;
            idEntreprise = P_idEntreprise_Selectionnee;
            idAudit = P_idAudit_selectionnee;
            idMetrique = P_idMetrique_selectionnee;

            if (Type == "entreprise")
            {
                description.Visibility = Visibility.Hidden;
                label_description.Visibility = Visibility.Hidden;
                fenetre_modifier.Width = 272.731;
            }
            else if (Type == "audit")
            {
                titre_ajout.Content = "MODIFIER UN AUDIT";
                description.Visibility = Visibility.Hidden;
                label_description.Visibility = Visibility.Hidden;
                label_adresse.Visibility = Visibility.Hidden;
                adresse.Visibility = Visibility.Hidden;
                fenetre_modifier.Width = 272.731;
            }
            else if (Type == "metrique")
            {
                titre_ajout.Content = "MODIFIER UNE METRIQUE";
                label_adresse.Content = "Critité (%) :";
            }
        }

        private void BTN_annul_modif_Clic(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BTN_modif_Click(object sender, RoutedEventArgs e)
        {
            if (Type == "entreprise")
            {
                la_coordination.modifier_entreprise(idEntreprise, nom.Text, adresse.Text);
            }
            else if (Type == "audit")
            {
                la_coordination.modifier_audit(idAudit, nom.Text);
            }
            else if (Type == "metrique")
            {
                la_coordination.modifier_metrique(idMetrique, nom.Text, Convert.ToInt32(adresse.Text), description.Text);
            }
            Close();
        }
    }
}
