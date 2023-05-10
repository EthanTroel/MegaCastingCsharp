using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using MegaCastingDB.Class;
using MegaCastingWPF.Model;

namespace MegaCastingWPF.Views
{

    public partial class PartenairesView : UserControl
    {

        private PartenaireViewModel _viewModel;

        public PartenaireViewModel ViewModel
        {
            get { return _viewModel; }
            set { _viewModel = value; }
        }

        public PartenairesView()
        {
            InitializeComponent();

            // Instancie le ViewModel
            ViewModel = new PartenaireViewModel();
            DataContext = ViewModel;

            // Remplit le DataGrid avec les partenaires
            ViewModel.RemplirDataGrid();
        }

        /// <summary>
        /// Appelé lors du clic sur le bouton "Ajouter"
        /// Ajoute un nouveau partenaire à la base de données
        /// </summary>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.AddNewPartenaire();
            PartenairesDataGrid.Items.Refresh();
        }

        /// <summary>
        /// Appelé lors du clic sur le bouton "Supprimer"
        /// Supprime le partenaire sélectionné de la base de données
        /// </summary>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ViewModel.DeletePartenaire();
            PartenairesDataGrid.Items.Refresh();
        }

        /// <summary>
        /// Appelé lors du clic sur le bouton "Modifier"
        /// Modifie les informations du partenaire sélectionné dans la base de données
        /// </summary>
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ViewModel.UpdatePartenaire(PartenairesDataGrid.SelectedItem as PartenireDiffusion);
            PartenairesDataGrid.Items.Refresh();
        }

        /// <summary>
        /// Appelé lorsqu'un partenaire est sélectionné dans le DataGrid
        /// Affiche les informations du partenaire sélectionné dans les TextBox correspondantes
        /// </summary>
        private void PartenairesDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }

        private void TextBoxLibelle_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBoxNom_TextChanged(object sender, TextChangedEventArgs e)
        {

        }


    }
}
