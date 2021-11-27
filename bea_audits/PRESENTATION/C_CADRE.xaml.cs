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
using bea_audits.COORDINATION;

namespace bea_audits.PRESENTATION
{
    /// <summary>
    /// Logique d'interaction pour C_CADRE_ajout_entreprise.xaml
    /// </summary>
    public partial class C_CADRE : Window
    {
        private string P_idEntreprise;
        private string P_idAudit;
        private string P_Type;
        private C_COORDINATION la_coordination;
        public C_CADRE(string P_Type, string P_idEntreprise = null, string P_idAudit = null)
        {
            la_coordination = new C_COORDINATION();
            InitializeComponent();
            DataContext = la_coordination;

            this.P_Type = P_Type;
            if (this.P_Type == "entreprise")
            {
                description.Visibility = Visibility.Hidden;
                label_description.Visibility = Visibility.Hidden;
                fenetre.Width = 272.731;
            }
            else if (this.P_Type == "audit")
            {
                titre_ajout.Content = "Ajouter un Audit";
                description.Visibility = Visibility.Hidden;
                label_description.Visibility = Visibility.Hidden;
                label_adresse.Visibility = Visibility.Hidden;
                adresse.Visibility = Visibility.Hidden;
                fenetre.Width = 272.731;
            }
            else if (this.P_Type == "metrique")
            {
                titre_ajout.Content = "Ajouter une Métrique";
                label_adresse.Content = "Critité (%) :";
            }

        }

        private void BTN_ajouter_Click(object sender, RoutedEventArgs e)
        {
            if (this.P_Type == "entreprise")
            {
                la_coordination.ajoute_entreprise(nom.Text, adresse.Text);
            } 
            else if (this.P_Type == "audit")
            {
                la_coordination.ajoute_audit_by_idEntreprise(nom.Text, this.P_idEntreprise);
            }
            else if (this.P_Type == "metrique")
            {
                la_coordination.ajoute_metrique_by_idAudit(nom.Text, Convert.ToInt32(adresse.Text), description.Text, this.P_idAudit);
            }
            this.Close();
        }

        private void BTN_annule_ajout_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
