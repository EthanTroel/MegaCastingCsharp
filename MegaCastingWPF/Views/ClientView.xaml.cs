using MegaCastingDB.Class;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;
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
using MegaCastingWPF.Model;

namespace MegaCastingWPF.Views
{
    public partial class ClientView : UserControl
    {
        /// <summary>
        /// Champ privé qui contient l'instance du ViewModel
        /// </summary>
        private ClientViewModel _viewModel;

        /// <summary>
        /// Propriété publique qui permet d'accéder à l'instance du ViewModel
        /// </summary>
        public ClientViewModel ViewModel
        {
            get { return _viewModel; }
            set { _viewModel = value; }
        }

        /// <summary>
        /// Constructeur de la classe
        /// </summary>
        public ClientView()
        {
            InitializeComponent();

            // Crée une nouvelle instance du ViewModel
            ViewModel = new ClientViewModel();

            // Associe l'instance du ViewModel au DataContext de la vue
            DataContext = ViewModel;

            // Initialise le DataGrid avec les clients
            ViewModel.RemplirDataGrid();

            // Initialise la ComboBox avec les packs de casting
            ViewModel.PackCastingComboBoxLoaded();
        }



        /// <summary>
        /// Méthode appelée lorsqu'un client est sélectionné dans la grille de données.
        /// Récupère le client sélectionné et appelle la méthode SelectionClient de l'objet ViewModel pour le sélectionner.
        /// </summary>
        /// <param name="sender">L'objet qui a déclenché l'événement</param>
        /// <param name="e">Les arguments de l'événement</param>
        private void CastingDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
                {
                    if (ClientsDataGrid.SelectedItem != null)
                    {
                        Client selectedClient = (Client)ClientsDataGrid.SelectedItem;
                        ViewModel.SelectionClient(selectedClient);
                    }
                }

        /// <summary>
        /// Méthode appelée lorsqu'un nouveau client doit être ajouté.
        /// Appelle la méthode AddNewClient de l'objet ViewModel pour ajouter le nouveau client.
        /// </summary>
        /// <param name="sender">L'objet qui a déclenché l'événement</param>
        /// <param name="e">Les arguments de l'événement</param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.AddNewClient();
            ClientsDataGrid.Items.Refresh();
        }

        /// <summary>
        /// Méthode appelée lorsqu'un client existant doit être mis à jour.
        /// Appelle la méthode UpdateClient de l'objet ViewModel pour mettre à jour le client existant.
        /// </summary>
        /// <param name="sender">L'objet qui a déclenché l'événement</param>
        /// <param name="e">Les arguments de l'événement</param>
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ViewModel.UpdateClient(ClientsDataGrid.SelectedItem as Client);
            ClientsDataGrid.Items.Refresh();
        }

        /// <summary>
        /// Méthode appelée lorsqu'un client doit être supprimé.
        /// Appelle la méthode DeleteClient de l'objet ViewModel pour supprimer le client sélectionné.
        /// </summary>
        /// <param name="sender">L'objet qui a déclenché l'événement</param>
        /// <param name="e">Les arguments de l'événement</param>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ViewModel.DeleteClient();
            ClientsDataGrid.Items.Refresh();
        }

        private void TextBoxLibelle_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void TextBoxNom_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ClientsDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Test123Context dbContext = new Test123Context();
            if (ClientsDataGrid.SelectedItem != null)
            {
                Client selectedClient = ClientsDataGrid.SelectedItem as Client;

                // Remplissage des champs de la vue avec les informations du client sélectionné
                ViewModel.SelectionClient(selectedClient);
            }
        }
    }
}
