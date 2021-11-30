using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Illustrator;

namespace bea_audits.ABSTRACTION
{
    class C_ILLUSTRATOR
    {
        Application Mon_Application;
        Document Mon_Document;
        static private C_ILLUSTRATOR Instance = null;

        static public C_ILLUSTRATOR Get_Instance()
        {
            if (Instance == null)
            {
                Instance = new C_ILLUSTRATOR();
            }
            return Instance;
        }

        public C_ILLUSTRATOR()
        {
            Mon_Application = new Application();
            if (Mon_Application.Documents.Count == 0) Mon_Document = Mon_Application.Documents.Add();
            else Mon_Document = Mon_Application.ActiveDocument;
        }
        //-------------------
        public void Ajoute_Jauges(string P_Nom_Zone, List<String> P_Labels, List<double> P_Valeurs)
        {
            C_GROUPE_JAUGE Groupe = new C_GROUPE_JAUGE(Mon_Document, P_Nom_Zone);

            for (int Index = 0; Index < P_Labels.Count; Index++)
            {
                Groupe.Ajoute_Jauge(P_Labels[Index], P_Valeurs[Index]);
            }
        }
        //--------------------
        public void Ajoute_Jauge(string P_Nom_Zone, string P_Label, double P_Valeur)
        {
            new C_JAUGE_CIRCULAIRE(Mon_Document, P_Nom_Zone, P_Valeur, P_Label);

        }


        //--------------------



        public void Rafraichir_Affichage()
        {
            Mon_Application.Redraw();
        }

    }

    class C_POINT
    {
        public double X;
        public double Y;
        public double DX_Gauche;
        public double DY_Gauche;
        public double DX_Droite;
        public double DY_Droite;
        public override string ToString()
        {
            return $"({X:f}, {Y:f})  ({DX_Gauche:f}, {DY_Gauche:f}) <---> ({DX_Droite:f}, {DY_Droite:f})";
        }
    }

    //========================================================================

    class C_GROUPE_JAUGE
    {
        List<C_JAUGE_CIRCULAIRE> Les_Jauges = new List<C_JAUGE_CIRCULAIRE>();
        Document Le_Document;

        private PathItem _Cadre;
        PathItem _Cadre_Origine;
        bool Cadre_Existant;

        double Rayon_X;
        double Rayon_Y;
        double X;
        double Y;

        private string _Nom_Groupe;
        string Base_Nom;

        private GroupItem _Groupe;

        public C_GROUPE_JAUGE(Document P_Document, string P_Nom)
        {
            Le_Document = P_Document;
            try
            {
                _Cadre_Origine = Le_Document.PathItems[P_Nom];
                _Cadre = _Cadre_Origine;
                Cadre_Existant = true;
                _Cadre_Origine.Opacity = 6;

                Rayon_X = _Cadre.Width / 2.0;
                Rayon_Y = _Cadre.Height / 2.0;
                X = _Cadre.Left + Rayon_X + _Cadre.StrokeWidth / 2.0;
                Y = _Cadre.Top - Rayon_Y - _Cadre.StrokeWidth / 2.0;

                Base_Nom = P_Nom;
                _Nom_Groupe = $"JAUGES_{Base_Nom}";
            }
            catch (Exception) { }
        }
        //-----------------

        public void Ajoute_Jauge(string P_Label, double P_Valeur)
        {
            int Coef = Les_Jauges.Count + 1;
            double Largeur = Rayon_X - Coef * 12;
            double Hauteur = Rayon_Y - Coef * 12;
            //  Creation_Groupe();
            C_JAUGE_CIRCULAIRE La_Jauge = new C_JAUGE_CIRCULAIRE(Le_Document, X, Y, Largeur, Hauteur, P_Valeur, P_Label);

            //   La_Jauge.Attache_Au_Groupe(_Groupe);
            Les_Jauges.Add(La_Jauge);



            // Redessine();
        }
        //-----------------
        //public void Redessine()
        //{
        //    //  Creation_Groupe();
        //    foreach (var element in Les_Jauges) {

        //        element.Redessine();
        //        //          element.Attache_Au_Groupe(_Groupe);
        //    }
        //}
        //-----------------
        //void Creation_Groupe()
        //{
        //    try {
        //        _Groupe = Le_Document.GroupItems[_Nom_Groupe];
        //        //   Le_Document.GroupItems.Remove(_Groupe);
        //    }
        //    catch (Exception) {
        //        _Groupe = Le_Document.GroupItems.Add();
        //        _Groupe.Name = _Nom_Groupe;
        //    }
        //}
    }

    //=============================================================
    class C_JAUGE_CIRCULAIRE
    {
        private PathItem _Cadre;
        private PathItem _Cadre_Origine;

        private GroupItem _Groupe;
        private PathItem _Graphique = null;
        private PathItem _Graphique_Label = null;
        private TextFrame _Graphique_Texte_Label = null;
        private string _Nom_Groupe;

        public PathItem Graphique { get { return _Graphique; } }
        public PathItem Graphique_Label { get { return _Graphique_Label; } }
        public TextFrame Graphique_Texte_Label { get { return _Graphique_Texte_Label; } }
        public string Nom_Groupe { get { return _Nom_Groupe; } }

        public bool Cadre_Existant { get; set; }

        double Rayon_X;
        double Rayon_Y;
        double X;
        double Y;
        double Pourcent = double.MinValue;

        List<C_POINT> Points_Beziers_Arc;

        Document Le_Document;

        string Texte_Label;
        string Base_Nom;

        //------------------------
        public C_JAUGE_CIRCULAIRE(Document P_Document, double P_X, double P_Y, double P_Rayon_X, double P_Rayon_Y,
            double P_Pourcentage, string P_Label)
        {
            Le_Document = P_Document;
            Rayon_X = P_Rayon_X;
            Rayon_Y = P_Rayon_Y;
            X = P_X;
            Y = P_Y;

            Texte_Label = P_Label;
            Base_Nom = $"{DateTime.Now.Ticks}";
            _Nom_Groupe = $"JAUGE_{Base_Nom}";
            Cadre_Existant = false;

            Redessine(P_Pourcentage);
            Pourcent = P_Pourcentage;
        }
        //----------------------------------

        public C_JAUGE_CIRCULAIRE(Document P_Document, string P_Nom, double P_Pourcentage, string P_Label)
        {
            Le_Document = P_Document;

            try
            {
                _Cadre_Origine = Le_Document.PathItems[P_Nom];
                _Cadre_Origine.Opacity = 6;

                _Cadre = _Cadre_Origine;
                Cadre_Existant = true;

                Rayon_X = _Cadre.Width / 2.0;
                Rayon_Y = _Cadre.Height / 2.0;
                X = _Cadre.Left + Rayon_X + _Cadre.StrokeWidth / 2.0;
                Y = _Cadre.Top - Rayon_Y - _Cadre.StrokeWidth / 2.0;

                Base_Nom = P_Nom;
            }
            catch (Exception)
            {
                Rayon_X = 25;
                Rayon_Y = 25;
                X = Le_Document.Width / 2.0;
                Y = Le_Document.Height / 2.0;
                Base_Nom = $"{DateTime.Now.Ticks}";
                Cadre_Existant = false;
            }


            _Nom_Groupe = $"JAUGE_{Base_Nom}";
            Texte_Label = P_Label;

            Redessine(P_Pourcentage);
            Pourcent = P_Pourcentage;
        }
        //---------------------------

        public void Attache_Au_Groupe(GroupItem P_Groupe)
        {
            _Groupe.Move(P_Groupe, AiElementPlacement.aiPlaceAtBeginning);
        }

        void Creation_Cadre()
        {
            if (Cadre_Existant == true)
            {
                _Cadre = _Cadre_Origine.Duplicate();

            }
            else
            {
                _Cadre = Le_Document.PathItems.Ellipse(Y + Rayon_Y, X - Rayon_X, Rayon_X * 2, Rayon_Y * 2);
                _Cadre.StrokeWidth = 10;
                _Cadre.FillColor = new RGBColor() { Blue = 255, Green = 255, Red = 255 };
                try
                {
                    Swatch Couleur_Bleu = Le_Document.Swatches["C=85 M=50 J=0 N=0"];
                    _Cadre.StrokeColor = Couleur_Bleu.Color;
                }
                catch (Exception)
                {
                    _Cadre.StrokeColor = new RGBColor() { Blue = 250, Red = 10 };
                }
            }
            _Cadre.Move(_Groupe, AiElementPlacement.aiPlaceAtBeginning);
            _Cadre.Name = $"Cadre_{Base_Nom}";
            _Cadre.Opacity = 6;
        }
        //---------------------------
        void Creation_Groupe()
        {
            try
            {
                _Groupe = Le_Document.GroupItems[_Nom_Groupe];
                Le_Document.GroupItems.Remove(_Groupe);
            }
            catch (Exception) { }

            _Groupe = Le_Document.GroupItems.Add();
            _Groupe.Name = _Nom_Groupe;
        }
        //---------------------------
        void Creation_Graphique_Jauge()
        {
            _Graphique = Le_Document.PathItems.Add();
            _Graphique.Move(_Groupe, AiElementPlacement.aiPlaceAtBeginning);
            _Graphique.Name = $"Niveau_{Base_Nom}";
            _Graphique.StrokeWidth = _Cadre.StrokeWidth;
            _Graphique.StrokeColor = _Cadre.StrokeColor;
            _Graphique.Filled = false;
            _Graphique.StrokeJoin = AiStrokeJoin.aiRoundEndJoin;
            _Graphique.StrokeCap = AiStrokeCap.aiRoundEndCap;
        }
        //---------------------------
        public void Dessine_Label()
        {
            C_POINT Centre = Points_Beziers_Arc[0];

            double Diametre_Label = _Cadre.StrokeWidth; ;// _Cadre.Width / 10.0;
                                                         //  if (Diametre_Label < _Cadre.StrokeWidth ) Diametre_Label = _Cadre.StrokeWidth;


            PathItem _Graphique_Label = Le_Document.PathItems.Ellipse(Y + Centre.Y + Diametre_Label / 2, X + Centre.X - Diametre_Label / 2, Diametre_Label, Diametre_Label);
            _Graphique_Label.Name = $"Label_{Base_Nom}";
            _Graphique_Label.Move(_Groupe, AiElementPlacement.aiPlaceAtBeginning);
            _Graphique_Label.StrokeWidth = 1;  // _Graphique.StrokeWidth / 8.0;
            _Graphique_Label.StrokeColor = _Graphique.StrokeColor;
            _Graphique_Label.FillColor = _Cadre.FillColor;

            _Graphique_Texte_Label = Le_Document.TextFrames.Add();
            _Graphique_Texte_Label.Name = $"Texte_{Base_Nom}";
            _Graphique_Texte_Label.Move(_Groupe, AiElementPlacement.aiPlaceAtBeginning);

            _Graphique_Texte_Label.Contents = Texte_Label;

            _Graphique_Texte_Label.TextRange.CharacterAttributes.Size = Diametre_Label * 0.8;
            //_Graphique_Texte_Label.TextRange.CharacterAttributes.FillColor = _Graphique.StrokeColor;

            _Graphique_Texte_Label.Left = X + Centre.X - _Graphique_Texte_Label.Width / 2;
            _Graphique_Texte_Label.Top = Y + Centre.Y + _Graphique_Texte_Label.Height / 2;
        }
        //------------------------
        public void Suppression()
        {
            try
            {
                Le_Document.GroupItems.Remove(_Groupe);
            }
            catch (Exception) { }
        }
        //------------------------

        public GroupItem Redessine(double P_Pourcent)
        {
            if (P_Pourcent == Pourcent) return _Groupe;
            Pourcent = P_Pourcent;
            return Redessine();

        }

        public GroupItem Redessine()
        {
            Creation_Groupe();
            //if (Cadre_Existant!=true)  
            Creation_Cadre();
            Creation_Graphique_Jauge();

            Points_Beziers_Arc = new List<C_POINT>();

            double Angle_Courant = 2.0 * Math.PI;
            double Pas_Angle_ = -Math.PI / 2.0; ;
            double Norme_Standard = 4.0 / 3.0 * Math.Tan(Math.PI / (2 * 4));

            double Angle_Final = 2 * Math.PI * (100 - Pourcent) / 100.0;

            C_POINT Nouveau_Point = null;

            while (Angle_Courant > Angle_Final)
            {
                Nouveau_Point = new C_POINT();

                Nouveau_Point.X = Rayon_X * Math.Sin(Angle_Courant);
                Nouveau_Point.Y = Rayon_Y * Math.Cos(Angle_Courant);
                Nouveau_Point.DX_Gauche = Rayon_X * Norme_Standard * Math.Cos(Angle_Courant);
                Nouveau_Point.DY_Gauche = -Rayon_Y * Norme_Standard * Math.Sin(Angle_Courant);
                Nouveau_Point.DX_Droite = -Rayon_X * Norme_Standard * Math.Cos(Angle_Courant);
                Nouveau_Point.DY_Droite = +Rayon_Y * Norme_Standard * Math.Sin(Angle_Courant);
                Points_Beziers_Arc.Add(Nouveau_Point);
                Angle_Courant += Pas_Angle_;
            }

            C_POINT Dernier_Point_Standard = Nouveau_Point;

            double Delta_Angle_Final = Angle_Courant - Pas_Angle_ - Angle_Final;
            double Nombre_Secteurs_Fins = 2.0 * Math.PI / Delta_Angle_Final;
            double Norme_Finale = 4.0 / 3.0 * Math.Tan(Math.PI / (2 * Nombre_Secteurs_Fins));

            C_POINT Point_Final = new C_POINT();

            Point_Final.X = Rayon_X * Math.Sin(Angle_Final);
            Point_Final.Y = Rayon_Y * Math.Cos(Angle_Final);
            Point_Final.DX_Gauche = Rayon_X * Norme_Finale * Math.Cos(Angle_Final);
            Point_Final.DY_Gauche = -Rayon_Y * Norme_Finale * Math.Sin(Angle_Final);
            Point_Final.DX_Droite = -Rayon_X * Norme_Finale * Math.Cos(Angle_Final);
            Point_Final.DY_Droite = +Rayon_Y * Norme_Finale * Math.Sin(Angle_Final);

            Points_Beziers_Arc.Add(Point_Final);

            if (Dernier_Point_Standard != null)
            {
                Dernier_Point_Standard.DX_Droite = Norme_Finale * Dernier_Point_Standard.DX_Droite / Norme_Standard;
                Dernier_Point_Standard.DY_Droite = Norme_Finale * Dernier_Point_Standard.DY_Droite / Norme_Standard;
            }

            for (int Index = 0; Index < Points_Beziers_Arc.Count; Index++)
            {
                PathPoint Le_Point_Graphique = _Graphique.PathPoints.Add();
                C_POINT Le_Point = Points_Beziers_Arc[Index];
                Le_Point_Graphique.Anchor = new object[] { X + Le_Point.X, Y + Le_Point.Y };
                //  Le_Point_Graphique.PointType = AiPointType.aiSmooth;
                Le_Point_Graphique.LeftDirection = new object[] { X + Le_Point.X + Le_Point.DX_Gauche, Y + Le_Point.Y + Le_Point.DY_Gauche };
                Le_Point_Graphique.RightDirection = new object[] { X + Le_Point.X + Le_Point.DX_Droite, Y + Le_Point.Y + Le_Point.DY_Droite };
            }

            Dessine_Label();
            return _Groupe;
        }
    }
}
