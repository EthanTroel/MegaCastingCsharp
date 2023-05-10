using MegaCastingDB.Class;
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
using MegaCastingWPF.Model;

namespace MegaCastingWPF.Views
{
    public partial class CastingsView : UserControl
    {
        private CastingViewModel _viewModel;
        public CastingViewModel ViewModel
        {
            get { return _viewModel; }
            set { _viewModel = value; }
        }

        /// <summary>
        /// Constructeur de la vue
        /// </summary>
        public CastingsView()
        {
            InitializeComponent();
            ViewModel = new CastingViewModel();
            DataContext = ViewModel;

            // Remplissage des éléments de la vue
            ViewModel.RemplirDataGrid();
            ViewModel.ContratsComboBoxLoaded();
            ViewModel.MetiersComboBoxLoaded();
            ViewModel.ClientsComboBoxLoaded();
        }

        /// <summary>
        ///  Fonction appelée lorsqu'une sélection change dans la grille des castings
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CastingDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }


        /// <summary>
        ///  Fonction appelée lorsqu'on clique sur le bouton "Ajouter"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.AddNewCasting();
            CastingDataGrid.Items.Refresh();
        }


        /// <summary>
        ///  Fonction appelée lorsqu'on clique sur le bouton "Modifier"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ViewModel.UpdateCasting(CastingDataGrid.SelectedItem as Offre);
            CastingDataGrid.Items.Refresh();
        }


        /// <summary>
        /// Fonction appelée lorsqu'on clique sur le bouton "Supprimer"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ViewModel.DeleteCasting();
            CastingDataGrid.Items.Refresh();
        }



        private void TextBoxLibelle_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }


       
    }
}

