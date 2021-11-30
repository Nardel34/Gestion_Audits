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
        private static C_COORDINATION la_coordination;

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
        private void entreprise_selectionnee(object sender, SelectionChangedEventArgs e)
        {
            la_coordination.entreprise_selectionnee = e.AddedItems[0] as C_ENTREPRISE;
            la_coordination.get_audit_by_idEntreprise(la_coordination.entreprise_selectionnee.id_entreprise);
        }
        private void audit_selectionnee(object sender, SelectionChangedEventArgs e)
        {
            la_coordination.audit_selectionnee = e.AddedItems[0] as C_AUDIT;
            la_coordination.get_metrique_by_idAudit(la_coordination.audit_selectionnee.id_audit);
        }
        private void metrique_selectionnee(object sender, SelectionChangedEventArgs e)
        {
            la_coordination.metrique_selectionnee = e.AddedItems[0] as C_METRIQUE;
        }
        private void BTN_ajouter_entreprise_Click(object sender, RoutedEventArgs e)
        {
            C_CADRE le_cadre = new C_CADRE("entreprise");
            le_cadre.Show();
        }
        private void BTN_ajouter_audit_Click(object sender, RoutedEventArgs e)
        {
            C_CADRE le_cadre = new C_CADRE("audit", la_coordination.entreprise_selectionnee.id_entreprise);
            le_cadre.Show();
        }
        private void BTN_ajouter_metrique_Click(object sender, RoutedEventArgs e)
        {
            C_CADRE le_cadre = new C_CADRE("metrique", null, la_coordination.audit_selectionnee.id_audit);
            le_cadre.Show();
        }

        private void BTN_modifier_entreprise_Click(object sender, RoutedEventArgs e)
        {
            C_CADRE_modifier le_cadre = new C_CADRE_modifier("entreprise", la_coordination.entreprise_selectionnee.id_entreprise);
            le_cadre.Show();
        }

        private void BTN_modifier_audit_Click(object sender, RoutedEventArgs e)
        {
            C_CADRE_modifier le_cadre = new C_CADRE_modifier("audit", null, la_coordination.audit_selectionnee.id_audit);
            le_cadre.Show();
        }

        private void BTN_modifier_metrique_Click(object sender, RoutedEventArgs e)
        {
            C_CADRE_modifier le_cadre = new C_CADRE_modifier("metrique", null, null, la_coordination.metrique_selectionnee.id_metrique);
            le_cadre.Show();
        }

        private void BTN_update_Click(object sender, RoutedEventArgs e)
        {
            la_coordination.Mise_A_jour_Illustrator();
        }
    }
}
