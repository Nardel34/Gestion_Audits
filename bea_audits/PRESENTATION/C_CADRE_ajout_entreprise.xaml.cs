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
    public partial class C_CADRE_ajout_entreprise : Window
    {
        C_COORDINATION la_coordination;
        public C_CADRE_ajout_entreprise()
        {
            la_coordination = new C_COORDINATION();
            InitializeComponent();
            DataContext = la_coordination;
        }

        private void BTN_ajouter_entreprise_Click(object sender, RoutedEventArgs e)
        {
            la_coordination.ajoute_entreprise(nomEntreprise.Text, adresse_entreprise.Text);
            this.Close();
        }

        private void BTN_annule_ajout_entreprise_Click(object sender, RoutedEventArgs e)
        {
            
            this.Close();
        }
    }
}
