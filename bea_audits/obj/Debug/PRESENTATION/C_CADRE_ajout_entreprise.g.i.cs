#pragma checksum "..\..\..\PRESENTATION\C_CADRE_ajout_entreprise.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "B9DE801BB99DD6C328733B72AA3C87EC8C937E68E817B09F3094399A8097A73A"
//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//     Version du runtime :4.0.30319.42000
//
//     Les modifications apportées à ce fichier peuvent provoquer un comportement incorrect et seront perdues si
//     le code est régénéré.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using bea_audits.PRESENTATION;


namespace bea_audits.PRESENTATION {
    
    
    /// <summary>
    /// C_CADRE
    /// </summary>
    public partial class C_CADRE : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 8 "..\..\..\PRESENTATION\C_CADRE_ajout_entreprise.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal bea_audits.PRESENTATION.C_CADRE fenetre;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\PRESENTATION\C_CADRE_ajout_entreprise.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox nom;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\PRESENTATION\C_CADRE_ajout_entreprise.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label label_adresse;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\PRESENTATION\C_CADRE_ajout_entreprise.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox adresse;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\PRESENTATION\C_CADRE_ajout_entreprise.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label label_description;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\PRESENTATION\C_CADRE_ajout_entreprise.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox description;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/bea_audits;component/presentation/c_cadre_ajout_entreprise.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\PRESENTATION\C_CADRE_ajout_entreprise.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.fenetre = ((bea_audits.PRESENTATION.C_CADRE)(target));
            return;
            case 2:
            this.nom = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.label_adresse = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.adresse = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            
            #line 19 "..\..\..\PRESENTATION\C_CADRE_ajout_entreprise.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BTN_ajouter_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 20 "..\..\..\PRESENTATION\C_CADRE_ajout_entreprise.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.BTN_annule_ajout_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.label_description = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.description = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

