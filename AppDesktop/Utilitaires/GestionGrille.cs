using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Personnes.Classes.Utilitaires
{
    public class GestionGrille
    {
        #region VISIBILITY

        public void GridVisibilty(Grid g, int pos)
        {
            int nb = g.Children.Count;
            g.Children[pos].Visibility = Visibility.Visible;
            for (int i = 0; i < pos; ++i)
            {
                g.Children[i].Visibility = Visibility.Hidden;
            }
            for (int i = pos + 1; i < nb; ++i)
            {
                g.Children[i].Visibility = Visibility.Hidden;
            }
        }

        #endregion END VISIBILITY

        public List<Grid> GetGrid(Grid grid)
        {
            List<Grid> listes = new List<Grid>();
            foreach (Grid g in grid.Children)
            {
                listes.Add(g);
            }
            return listes;
        }

        public int GetIndexGrille(Grid grid)
        {
            //Recherche de la grille qui est visible
            int i = -1;
            foreach (Grid g in grid.Children)
            {
                if (g.IsVisible)
                {
                    i = grid.Children.IndexOf(g);
                }
            }
            return i;
        }

        public List<TextBox> GetTextBox(Grid grid)
        {
            List<TextBox> listes = new List<TextBox>();
            foreach (Control c in grid.Children)
            {
                if (c is TextBox)
                {
                    if (c.BorderBrush.ToString() == "#FFFFFF00")
                    {
                        TextBox tb = (TextBox)c;
                        listes.Add(tb);
                    }
                }
            }
            return listes;
        }


        //#region AJOUT UNITDATA


        //#region UNITDATABIOMETRIE

        //public void GridAjoutUnitDataBiometrie(Grid g, int indexCol, int indexDebut, int indexFin)
        //{
        //    int nb = (indexFin - indexDebut) + 1;
        //    for (int j = 0; j < nb; ++j)
        //    {
        //        for (int i = indexCol; i < g.ColumnDefinitions.Count; i = i + 3)
        //        {
        //            UnitDataBiometrie c = new UnitDataBiometrie();
        //            Grid.SetColumnSpan(c, 3);
        //            Grid.SetRow(c, indexDebut);
        //            Grid.SetColumn(c, i);
        //            g.Children.Add(c);
        //        }
        //        indexDebut = indexDebut + 1;
        //    }
        //}
        //#endregion

        //#region UNITDATAANATOMIE
        //public void GridAjoutUnitDataAnatomie(Grid g, int indexCol, int indexDebut, int indexFin)
        //{
        //    int nb = (indexFin - indexDebut) + 1;
        //    for (int j = 0; j < nb; ++j)
        //    {
        //        for (int i = indexCol; i < g.ColumnDefinitions.Count; i = i + 3)
        //        {
        //            UnitDataAnatomie c = new UnitDataAnatomie();
        //            Grid.SetColumnSpan(c, 3);
        //            Grid.SetRow(c, indexDebut);
        //            Grid.SetColumn(c, i);
        //            g.Children.Add(c);
        //        }
        //        indexDebut = indexDebut + 1;
        //    }
        //}
        //#endregion

        //#endregion FIN AJOUT UNITDATA

        //#region REMOVE UNITDATA
        //public void RemoveUnitDataAnatomie(Grid g, List<ElementAnatomique> l)
        //{
        //    List<UnitData> elements = new List<UnitData>();
        //    foreach (UnitData element in g.Children)
        //    {
        //        elements.Add(element);
        //    }
        //    while (elements.Count > l.Count)
        //    {
        //        g.Children.RemoveAt(elements.Count - 1);
        //        elements.RemoveAt(elements.Count - 1);

        //    }
        //}

        //public void RemoveUnitDataBiometrie(Grid g, List<ElementBiometrique> l)
        //{
        //    List<UnitData> elements = new List<UnitData>();
        //    foreach (UnitData element in g.Children)
        //    {
        //        elements.Add(element);
        //    }
        //    while (elements.Count > l.Count)
        //    {
        //        g.Children.RemoveAt(elements.Count - 1);
        //        elements.RemoveAt(elements.Count - 1);

        //    }
        //}


        //#endregion

        //#region BINDINGS UNITDATA

        //#region UNITDATAANATOMIE
        //public void SetBindingUnitDatAnatomie(Grid grid, List<ElementAnatomique> elements)
        //{
        //    List<UnitDataAnatomie> unites = new List<UnitDataAnatomie>();
        //    foreach (UnitDataAnatomie unite in grid.Children)
        //    {
        //        unites.Add(unite);
        //    }
        //    for (int i = 0; i < elements.Count; ++i)
        //    {
        //        unites[i].DataContext = elements[i];

        //        Binding bElement = new Binding();
        //        Binding bCle = new Binding();
        //        //Binding bEvaluation = new Binding();
        //        Binding bBool = new Binding();
        //        Binding bLabelEvaluation = new Binding();

        //        bElement.Path = new System.Windows.PropertyPath("Label");
        //        bCle.Path = new System.Windows.PropertyPath("CleElement");
        //        //bEvaluation.Path = new System.Windows.PropertyPath("Evaluation");
        //        bBool.Path = new System.Windows.PropertyPath("Evalue");
        //        bLabelEvaluation.Path = new System.Windows.PropertyPath("LabelEvaluation");

        //        unites[i].Label1.SetBinding(ContentControl.ContentProperty, bElement);
        //        unites[i].Tb1.SetBinding(TextBox.TextProperty, bCle);
        //        //unites[i].Cb1.SetBinding(CheckBox.IsCheckedProperty, bEvaluation);
        //        //unites[i].Cb1.SetBinding(CheckBox.ContentProperty, bLabelEvaluation);
        //        //unites[i].Cb1.SetBinding(CheckBox.IsCheckedProperty, bLabelEvaluation);
        //    }
        //}

        //public List<ElementAnatomique> GetBindingUnitDataAnatomie(Grid grid)
        //{
        //    List<ElementAnatomique> elements = new List<ElementAnatomique>();
        //    foreach (UnitDataBiometrie control in grid.Children)
        //    {
        //        object o = control.DataContext;
        //        ElementAnatomique elt = o as ElementAnatomique;
        //        if (elt is ElementAnatomique)
        //        {
        //            elements.Add(elt);
        //        }
        //    }
        //    return elements;
        //}
        //#endregion

        //#region DATABIOMETRIE
        //public void SetBindingUnitDataBiometrie(Grid grid, List<ElementBiometrique> elements)
        //{
        //    List<UnitDataBiometrie> unites = new List<UnitDataBiometrie>();
        //    foreach (UnitDataBiometrie unite in grid.Children)
        //    {
        //        unites.Add(unite);
        //    }
        //    for (int i = 0; i < unites.Count; ++i)
        //    {
        //        unites[i].DataContext = elements[i];

        //        Binding bElement = new Binding();
        //        Binding bCle = new Binding();
        //        Binding bDimension = new Binding();
        //        Binding bTaille = new Binding();

        //        bElement.Path = new System.Windows.PropertyPath("Label");
        //        bCle.Path = new System.Windows.PropertyPath("CleElement");
        //        bDimension.Path = new System.Windows.PropertyPath("CleDimension");
        //        bTaille.Path = new System.Windows.PropertyPath("Dimension");

        //        unites[i].Label1.SetBinding(ContentControl.ContentProperty, bElement);
        //        unites[i].Tb1.SetBinding(TextBox.TextProperty, bCle);
        //        unites[i].Tb2.SetBinding(TextBox.TextProperty, bDimension);
        //        unites[i].Tb3.SetBinding(TextBox.TextProperty, bTaille);
        //    }
        //}


        //public List<ElementBiometrique> GetBindingUnitDataBiometrie(Grid grid)
        //{
        //    List<ElementBiometrique> elements = new List<ElementBiometrique>();
        //    foreach (UnitDataBiometrie control in grid.Children)
        //    {
        //        object o = control.DataContext;
        //        ElementBiometrique elt = o as ElementBiometrique;
        //        if (elt is ElementBiometrique)
        //        {
        //            elements.Add(elt);
        //        }
        //    }
        //    return elements;
        //}
        //#endregion

        //#endregion END BINDINGS UNITDATA


        //public void SetBindingGridCentre(List<Classes.Element> l, Grid g)
        //{
        //    List<Grid> grids = new GestionGrille().GetGrid(g);
        //    for (int i = 0; i < l.Count; ++i)
        //    {
        //        //Pas de datacontext sur la premiere grille
        //        grids[i + 1].DataContext = l[i];
        //    }
        //}

        /////////////////////////////////////////////////////////////////////
        //#region BINDINGS CLASSIQUE AVEC OU SANS LIST COMME PARAMETRE

        //public void SetBindingMorphology(Grid grid, List<ElementAnatomique> elements)
        //{
        //    //Liste des elements du 1T

        //    //Liaison DataContext pour chaque uniteData de la grid biometric 1T
        //    //Le seul moyen en attendant les UserControl eest de slectionner les UnitData sur leur nom gridUD
        //    //1.Liste des gridUnit
        //    List<Grid> grids = new List<Grid>();
        //    foreach (Panel control in grid.Children)
        //    {
        //        Grid g = control as Grid;
        //        if (g is Grid)
        //        {
        //            if (g.Background.ToString() == "#00FFFFFF")
        //            {
        //                grids.Add(g);
        //            }
        //        }
        //    }
        //    //2.Affection du DataContext
        //    for (int i = 0; i < grids.Count; ++i)
        //    {
        //        grids[i].DataContext = elements[i];
        //    }
        //}

        //public void SetBindingBiometrics(Grid grid, List<ElementBiometrique> elements)
        //{
        //    List<Grid> grids = new List<Grid>();
        //    foreach (Panel control in grid.Children)
        //    {
        //        Grid g = control as Grid;
        //        if (g is Grid)
        //        {

        //            if (g.Background.ToString() == "#00FFFFFF")
        //            {
        //                grids.Add(g);
        //            }
        //        }
        //    }

        //    for (int i = 0; i < grids.Count; ++i)
        //    {
        //        grids[i].DataContext = elements[i];
        //    }
        //}

        //public List<ElementBiometrique> GetBindingBiometrics(Grid grid)
        //{
        //    List<ElementBiometrique> elements = new List<ElementBiometrique>();
        //    foreach (Panel control in grid.Children)
        //    {
        //        Grid g = control as Grid;
        //        if (g is Grid)
        //        {
        //            if (g.Background.ToString() == "#00FFFFFF")
        //            {
        //                object o = g.DataContext;
        //                ElementBiometrique elt = o as ElementBiometrique;
        //                if (elt is ElementBiometrique)
        //                {
        //                    elements.Add(elt);
        //                }
        //            }
        //        }
        //    }
        //    return elements;
        //}

        //public List<ElementAnatomique> GetBindingAnatomie(Grid grid)
        //{
        //    List<ElementAnatomique> elements = new List<ElementAnatomique>();
        //    foreach (Panel control in grid.Children)
        //    {
        //        Grid g = control as Grid;
        //        if (g is Grid)
        //        {
        //            if (g.Background.ToString() == "#00FFFFFF")
        //            {
        //                object o = g.DataContext;
        //                ElementAnatomique elt = o as ElementAnatomique;
        //                if (elt is ElementAnatomique)
        //                {
        //                    elements.Add(elt);
        //                }
        //            }
        //        }
        //    }
        //    return elements;
        //}

        //public List<ElementAnatomique> GetBindingUnitAnatomie(Grid grid)
        //{
        //    List<ElementAnatomique> elements = new List<ElementAnatomique>();
        //    foreach (Panel control in grid.Children)
        //    {
        //        Grid g = control as Grid;
        //        if (g is Grid)
        //        {
        //            if (g.Background.ToString() == "#00FFFFFF")
        //            {
        //                object o = g.DataContext;
        //                ElementAnatomique elt = o as ElementAnatomique;
        //                if (elt is ElementAnatomique)
        //                {
        //                    elements.Add(elt);
        //                }
        //            }
        //        }
        //    }
        //    return elements;
        //}

        //#endregion FINBINDINGS CLASSIQUE AVEC OU SANS LIST COMME PARAMETRE


        //#region USER CONTROL
        //internal void RemoveUCBiometrie(Grid g, List<ElementBiometrique> l)
        //{
        //    List<Biometrie> elements = new List<Biometrie>();
        //    foreach (Biometrie element in g.Children)
        //    {
        //        elements.Add(element);
        //    }
        //    while (elements.Count > l.Count)
        //    {
        //        g.Children.RemoveAt(elements.Count - 1);
        //        elements.RemoveAt(elements.Count - 1);

        //    }
        //}

        //internal void SetBindingUCBiometrie(Grid grid, List<ElementBiometrique> elements)
        //{

        //    //grid.DataContext = elements;

        //    List<Biometrie> unites = new List<Biometrie>();
        //    foreach (Biometrie unite in grid.Children)
        //    {
        //        unites.Add(unite);
        //    }
        //    for (int i = 0; i < unites.Count; ++i)
        //    {


        //        Binding bElement = new Binding();
        //        Binding bCle = new Binding();
        //        Binding bDimension = new Binding();
        //        Binding bTaille = new Binding();

        //        bElement.Source = elements[i];
        //        bCle.Source = elements[i];
        //        bDimension.Source = elements[i];
        //        bTaille.Source = elements[i];

        //        bElement.Path = new System.Windows.PropertyPath("Label");
        //        bCle.Path = new System.Windows.PropertyPath("CleElement");
        //        bDimension.Path = new System.Windows.PropertyPath("CleDimension");
        //        bTaille.Path = new System.Windows.PropertyPath("Dimension");

        //        unites[i].SetBinding(Biometrie.ElementProperty, bElement);
        //        unites[i].SetBinding(Biometrie.CleProperty, bCle);
        //        unites[i].SetBinding(Biometrie.DimensionProperty, bDimension);
        //        unites[i].SetBinding(Biometrie.TailleProperty, bTaille);
        //    }
        //}

        //public void GridAjoutUCBiometrie(Grid g, int indexCol, int indexDebut, int indexFin)
        //{
        //    int nb = (indexFin - indexDebut) + 1;
        //    for (int j = 0; j < nb; ++j)
        //    {
        //        for (int i = indexCol; i < g.ColumnDefinitions.Count; i = i + 3)
        //        {
        //            Biometrie c = new Biometrie();
        //            Grid.SetColumnSpan(c, 3);
        //            Grid.SetRow(c, indexDebut);
        //            Grid.SetColumn(c, i);
        //            g.Children.Add(c);
        //        }
        //        indexDebut = indexDebut + 1;
        //    }
        //}


        //#endregion
    }
}
