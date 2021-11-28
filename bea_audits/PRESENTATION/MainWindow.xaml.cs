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
using System.Windows.Navigation;
using System.Windows.Shapes;
using bea_audits.COORDINATION;
using LIB_BASE;

namespace bea_audits.PRESENTATION
{

    public partial class MainWindow : Window
    {
        C_COORDINATION la_coordination;
        string idEntreprise_selectionnee;
        string idAudit_selectionnee;
        string idMetrique_selectionnee;
        public MainWindow()
        {
            la_coordination = new C_COORDINATION();
            InitializeComponent();
            DataContext = la_coordination;
        }

        private void TXB_trie_entreprise_TextChanged(object sender, TextChangedEventArgs e)
        {
            la_coordination.trier_les_entreprises(TXB_trie_entreprise.Text);
        }
        private void TBX_trie_audit_TextChanged(object sender, TextChangedEventArgs e)
        {
            la_coordination.trier_les_audits(TXB_trie_audits.Text);
        }


        private void entreprise_selectionnee(object sender, SelectionChangedEventArgs e)
        {
            string id_entreprise = (e.AddedItems[0] as C_ENTREPRISE).id_entreprise;
            ListBox_audits.Items.Clear();
            idEntreprise_selectionnee = id_entreprise;
            la_coordination.get_audit_by_idEntreprise(id_entreprise);

            foreach (var item in la_coordination.liste_audits)
            {
                ListBox_audits.Items.Add(item);
            }
        }
        private void audit_selectionnee(object sender, SelectionChangedEventArgs e)
        {
            string id_audit = (e.AddedItems[0] as C_AUDIT).id_audit;
            idAudit_selectionnee = id_audit;
            ListBox_metriques.Items.Clear();
            la_coordination.get_metrique_by_idAudit(id_audit);

            foreach (var item in la_coordination.liste_metriques)
            {
                ListBox_metriques.Items.Add(item);
            }
        }
        private void metrique_selectionnee(object sender, SelectionChangedEventArgs e)
        {
            string id_metrique = (e.AddedItems[0] as C_METRIQUE).id_metrique;
            idMetrique_selectionnee = id_metrique;
        }
        private void BTN_ajouter_entreprise_Click(object sender, RoutedEventArgs e)
        {
            C_CADRE le_cadre = new C_CADRE("entreprise");
            le_cadre.Show();
        }
        private void BTN_ajouter_audit_Click(object sender, RoutedEventArgs e)
        {
            C_CADRE le_cadre = new C_CADRE("audit", idEntreprise_selectionnee);
            le_cadre.Show();
        }
        private void BTN_ajouter_metrique_Click(object sender, RoutedEventArgs e)
        {
            C_CADRE le_cadre = new C_CADRE("metrique", null, idAudit_selectionnee);
            le_cadre.Show();
        }

        private void BTN_modifier_entreprise_Click(object sender, RoutedEventArgs e)
        {
            C_CADRE_modifier le_cadre = new C_CADRE_modifier("entreprise", idEntreprise_selectionnee);
            le_cadre.Show();
        }

        private void BTN_modifier_audit_Click(object sender, RoutedEventArgs e)
        {
            C_CADRE_modifier le_cadre = new C_CADRE_modifier("audit", null, idAudit_selectionnee);
            le_cadre.Show();
        }

        private void BTN_modifier_metrique_Click(object sender, RoutedEventArgs e)
        {
            C_CADRE_modifier le_cadre = new C_CADRE_modifier("metrique", null, null, idMetrique_selectionnee);
            le_cadre.Show();
        }
    }
}
