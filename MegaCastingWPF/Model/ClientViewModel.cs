using MegaCastingDB.Class;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using MegaCastingWPF.Views;
using System.Security.Cryptography;

namespace MegaCastingWPF.Model
{

    public class ClientViewModel
    {
        #region Attributs & Propriétés
        private Client _selectedClient;
        public Client SelectedClient
        {
            get { return _selectedClient; }
            set { _selectedClient = value; } 
        }


        private string _textBoxNom;
        public string TextBoxNom
        {
            get { return _textBoxNom; }
            set { _textBoxNom = value; }
        }


        private string _textBoxTel;
        public string TextBoxTel
        {
            get { return _textBoxTel; }
            set { _textBoxTel = value; }
        }

        private string _textBoxMail;
        public string TextBoxMail
        {
            get { return _textBoxMail; }
            set { _textBoxMail = value; }
        }

        private string _textBoxUrl;
        public string TextBoxUrl
        {
            get { return _textBoxUrl; }
            set { _textBoxUrl = value; }
        }

        private string _textBoxSiret;
        public string TextBoxSiret
        {
            get { return _textBoxSiret; }
            set { _textBoxSiret = value; }
        }

        private string _textBoxVille;
        public string TextBoxVille
        {
            get { return _textBoxVille; }
            set { _textBoxVille = value; }
        }


        private string _textBoxLogin;
        public string TextBoxLogin
        {
            get { return _textBoxLogin; }
            set { _textBoxLogin = value; }
        }


        private string _textBoxPassword;
        public string TextBoxPassword
        {
            get { return _textBoxPassword; }
            set { _textBoxPassword = value; }
        }


        private string _textBoxNbOffres;
        public string TextBoxNbOffres
        {
            get { return _textBoxNbOffres; }
            set { _textBoxNbOffres = value; }
        }

        private int _selectedPackCastingId;
        public int SelectedPackCastingId
        {
            get { return _selectedPackCastingId; }
            set { _selectedPackCastingId = value; }
        }


        private ObservableCollection<Client>? _clientsList;
        public ObservableCollection<Client>? ClientsList
        {
            get { return _clientsList; }
            set
            {
                _clientsList = value;
            }
        }

        private ObservableCollection<PackCasting>? _packCastings;

        public ObservableCollection<PackCasting>? PackCastings
        {
            get { return _packCastings; }
            set { _packCastings = value; }
        }

        #endregion
        public void RemplirDataGrid()
        {
            Test123Context dbContext = new Test123Context();
            var clients = dbContext.Clients.ToList();
            ClientsList = new ObservableCollection<Client>(clients);
        }

        public void PackCastingComboBoxLoaded()
        {
            Test123Context dbContext = new Test123Context();
            var packcastings = dbContext.PackCastings.ToList();
            PackCastings = new ObservableCollection<PackCasting>(packcastings);
        }

        public void SelectionClient(Client selectedClient)
        {
            // Remplissage des champs avec les informations du client sélectionné
            TextBoxNom = selectedClient.Nom;
            TextBoxTel = selectedClient.Tel;
            TextBoxMail = selectedClient.Mail;
            TextBoxPassword = selectedClient.Password;
            TextBoxUrl = selectedClient.Url;
            TextBoxSiret = selectedClient.Siret;
            TextBoxLogin = selectedClient.Login;
            TextBoxVille = selectedClient.Ville;
            TextBoxNbOffres = selectedClient.NombreOffresRestantes.ToString();
            SelectedPackCastingId = selectedClient.IdentifiantPackCasting;

        }


        public void AddNewClient()
        {
            Test123Context dbContext = new Test123Context();
            {
                if (!string.IsNullOrEmpty(TextBoxNom) &&
                !string.IsNullOrEmpty(TextBoxTel) &&
                !string.IsNullOrEmpty(TextBoxMail) &&
                !string.IsNullOrEmpty(TextBoxPassword) &&
                !string.IsNullOrEmpty(TextBoxUrl) &&
                !string.IsNullOrEmpty(TextBoxSiret) &&
                !string.IsNullOrEmpty(TextBoxLogin) &&
                !string.IsNullOrEmpty(TextBoxVille) &&
                !string.IsNullOrEmpty(TextBoxNbOffres) &&
                SelectedPackCastingId != null)
                {
                    Client newclient = new Client
                    {
                        Nom = TextBoxNom,
                        Tel = TextBoxTel,
                        Mail = TextBoxMail,
                        Password = GetHashedPassword(TextBoxPassword),
                        Url = TextBoxUrl,
                        Siret = TextBoxSiret,
                        Login = TextBoxLogin,
                        Ville = TextBoxVille,
                        NombreOffresRestantes = int.Parse(TextBoxNbOffres),
                        IdentifiantPackCasting = SelectedPackCastingId,
                    };

                    // Ajout du nouveau client à la base de données
                    if (newclient != null)
                    {
                        dbContext.Clients.Add(newclient);
                        dbContext.SaveChanges();
                        ClientsList.Add(newclient);
                    }
                }
            }
        }


        public void UpdateClient(Client selectedClient)
        {
            Test123Context dbContext = new Test123Context();
            Client ClientUpdate = dbContext.Clients.Find(SelectedClient.Identifiant);

            if (!string.IsNullOrEmpty(TextBoxNom) &&
               !string.IsNullOrEmpty(TextBoxTel) &&
               !string.IsNullOrEmpty(TextBoxMail) &&
               !string.IsNullOrEmpty(TextBoxPassword) &&
               !string.IsNullOrEmpty(TextBoxUrl) &&
               !string.IsNullOrEmpty(TextBoxSiret) &&
               !string.IsNullOrEmpty(TextBoxLogin) &&
               !string.IsNullOrEmpty(TextBoxVille) &&
               !string.IsNullOrEmpty(TextBoxNbOffres) &&
               SelectedPackCastingId != null)
            {
                ClientUpdate.Nom = TextBoxNom;
                ClientUpdate.Tel = TextBoxTel;
                ClientUpdate.Mail = TextBoxMail;
                ClientUpdate.Password = GetHashedPassword(TextBoxPassword);
                ClientUpdate.Url = TextBoxUrl;
                ClientUpdate.Siret = TextBoxSiret;
                ClientUpdate.Login = TextBoxLogin;
                ClientUpdate.Ville = TextBoxVille;
                ClientUpdate.NombreOffresRestantes = int.Parse(TextBoxNbOffres);
                ClientUpdate.IdentifiantPackCasting = SelectedPackCastingId;

                dbContext.Clients.Update(ClientUpdate);
                dbContext.SaveChanges();
                ClientsList[ClientsList.IndexOf(SelectedClient)] = ClientUpdate;
            }
        }


        public void DeleteClient()
        {
            Test123Context dbContext = new Test123Context();
            if (SelectedClient != null)
            {
                Client? selectedClient = SelectedClient;
                Client clientToDelete = dbContext.Clients.Find(selectedClient.Identifiant);
                if (clientToDelete != null)
                {
                    dbContext.Clients.Remove(clientToDelete);
                    dbContext.SaveChanges();
                    ClientsList.Remove(selectedClient);
                }



            }
        }


        private static string GetHashedPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = sha256.ComputeHash(passwordBytes);
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    builder.Append(hashBytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

    }
}
