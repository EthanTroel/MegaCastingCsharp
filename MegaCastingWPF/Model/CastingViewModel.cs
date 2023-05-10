using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MegaCastingDB.Class;

namespace MegaCastingWPF.Model
{
    public class CastingViewModel
    {
        #region Attributs & Propriétés
        private Offre _selectedOffre;
        public Offre SelectedOffre
        {
            get { return _selectedOffre; }
            set { _selectedOffre = value; }
        }

        private string _textBoxLibelle;
        public string TextBoxLibelle
        {
            get { return _textBoxLibelle; }
            set { _textBoxLibelle = value; }
        }


        private DateTime _textBoxDateDeb;
        public DateTime TextBoxDateDeb
        {
            get { return _textBoxDateDeb; }
            set { _textBoxDateDeb = value; }
        }

        private DateTime _textBoxDateFin;
        public DateTime TextBoxDateFin
        {
            get { return _textBoxDateFin; }
            set { _textBoxDateFin = value; }
        }

        private string _textBoxReference;
        public string TextBoxReference
        {
            get { return _textBoxReference; }
            set { _textBoxReference = value; }
        }

        private string _textBoxLocalisation;
        public string TextBoxLocalisation
        {
            get { return _textBoxLocalisation; }
            set { _textBoxLocalisation = value; }
        }

        private short _textBoxAgeMin;
        public short TextBoxAgeMin
        {
            get { return _textBoxAgeMin; }
            set { _textBoxAgeMin = value; }
        }

        private short _textBoxAgeMax;
        public short TextBoxAgeMax
        {
            get { return _textBoxAgeMax; }
            set { _textBoxAgeMax = value; }
        }

        private DateTime _textBoxDate;
        public DateTime TextBoxDate
        {
            get { return _textBoxDate; }
            set { _textBoxDate = value; }
        }

        private string _textBoxDescription;
        public string TextBoxDescription
        {
            get { return _textBoxDescription; }
            set { _textBoxDescription = value; }
        }

        private int _selectedContratId;
        public int SelectedContratId
        {
            get { return _selectedContratId; }
            set { _selectedContratId = value; }
        }

        private int _selectedMetierId;
        public int SelectedMetierId
        {
            get { return _selectedMetierId; }
            set { _selectedMetierId = value; }
        }

        private int _selectedClientId;
        public int SelectedClientId
        {
            get { return _selectedClientId; }
            set { _selectedClientId = value; }
        }

        private ObservableCollection<Offre>? _offresList;
        public ObservableCollection<Offre>? OffresList
        {
            get { return _offresList; }
            set
            {
                _offresList = value;
            }
        }

        private ObservableCollection<TypeContrat>? _contratsList;
        public ObservableCollection<TypeContrat>? ContratsList
        {
            get { return _contratsList; }
            set
            {
                _contratsList = value;
            }
        }

        private ObservableCollection<Metier>? _metiersList;
        public ObservableCollection<Metier>? MetiersList
        {
            get { return _metiersList; }
            set
            {
                _metiersList = value;
            }
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


        #endregion


        /// <summary>
        /// Remplit la liste des offres dans le DataGrid
        /// </summary>
        public void RemplirDataGrid()
        {
            Test123Context dbContext = new Test123Context();
            var offres = dbContext.Offres.ToList();
            OffresList = new ObservableCollection<Offre>(offres);
        }

        /// <summary>
        /// Remplit la liste des types de contrat dans la ComboBox
        /// </summary>
        public void ContratsComboBoxLoaded()
        {
            Test123Context dbContext = new Test123Context();
            var contrats = dbContext.TypeContrats.ToList();
            ContratsList = new ObservableCollection<TypeContrat>(contrats);
        }

        /// <summary>
        /// Remplit la liste des métiers dans la ComboBox
        /// </summary>
        public void MetiersComboBoxLoaded()
        {
            Test123Context dbContext = new Test123Context();
            var metiers = dbContext.Metiers.ToList();
            MetiersList = new ObservableCollection<Metier>(metiers);
        }

        /// <summary>
        /// Remplit la liste des clients dans la ComboBox
        /// </summary>
        public void ClientsComboBoxLoaded()
        {
            Test123Context dbContext = new Test123Context();
            var clients = dbContext.Clients.ToList();
            ClientsList = new ObservableCollection<Client>(clients);
        }

        /// <summary>
        ///  Ajoute une nouvelle offre à la base de données
        /// </summary>
        public void AddNewCasting()
        {
            Test123Context dbContext = new Test123Context();
            if (!string.IsNullOrEmpty(TextBoxLibelle) &&
                !string.IsNullOrEmpty(TextBoxReference) &&
                !string.IsNullOrEmpty(TextBoxLocalisation) &&
                !string.IsNullOrEmpty(TextBoxDescription) &&
                SelectedClientId != null &&
                SelectedMetierId != null &&
                SelectedContratId != null)
            {
                Offre newoffre = new Offre
                {
                    Libelle = TextBoxLibelle,
                    DateDebut = TextBoxDateDeb,
                    DateFin = TextBoxDateFin,
                    Reference = TextBoxReference,
                    Localisation = TextBoxLocalisation,
                    AgeMin = TextBoxAgeMin,
                    AgeMax = TextBoxAgeMax,
                    Date = TextBoxDate,
                    Description = TextBoxDescription,
                    IdentifiantClient = SelectedClientId,
                    IdentifiantMetier = SelectedMetierId,
                    IdentifiantTypeContrat = SelectedContratId,

                };

                // Ajout de la nouvelle offre à la base de données
                if (newoffre != null)
                {
                    dbContext.Offres.Add(newoffre);
                    dbContext.SaveChanges();
                    OffresList.Add(newoffre);
                }
            }
        }


        /// <summary>
        ///  Met à jour une offre dans la base de données
        /// </summary>
        /// <param name="selectedOffre"></param>
        public void UpdateCasting(Offre selectedOffre)
        {
            Test123Context dbContext = new Test123Context();

            if (!string.IsNullOrEmpty(TextBoxLibelle) &&
                !string.IsNullOrEmpty(TextBoxReference) &&
                !string.IsNullOrEmpty(TextBoxLocalisation) &&
                !string.IsNullOrEmpty(TextBoxDescription) &&
                SelectedClientId != null &&
                SelectedMetierId != null &&
                SelectedContratId != null)
            {
                Offre OffreUpdate = dbContext.Offres.Find(selectedOffre.Identifiant);

                OffreUpdate.Libelle = TextBoxLibelle;
                OffreUpdate.DateDebut = TextBoxDateDeb;
                OffreUpdate.DateFin = TextBoxDateFin;
                OffreUpdate.Reference = TextBoxReference;
                OffreUpdate.Localisation = TextBoxLocalisation;
                OffreUpdate.AgeMin = TextBoxAgeMin;
                OffreUpdate.AgeMax = TextBoxAgeMax;
                OffreUpdate.Date = TextBoxDate;
                OffreUpdate.Description = TextBoxDescription;
                OffreUpdate.IdentifiantClient = SelectedClientId;
                OffreUpdate.IdentifiantMetier = SelectedMetierId;
                OffreUpdate.IdentifiantTypeContrat = SelectedContratId;

                dbContext.Offres.Update(OffreUpdate);
                dbContext.SaveChanges();
                OffresList[OffresList.IndexOf(SelectedOffre)] = OffreUpdate;
            }
        }


        /// <summary>
        /// Supprime une offre dans la base de données
        /// </summary>
        public void DeleteCasting()
        {
            Test123Context dbContext = new Test123Context();
            if (SelectedOffre != null)
            {
                Offre? selectedOffre = SelectedOffre;
                Offre offfreToDelete = dbContext.Offres.Find(selectedOffre.Identifiant);
                if (offfreToDelete != null)
                {
                    dbContext.Offres.Remove(offfreToDelete);
                    dbContext.SaveChanges();
                    OffresList.Remove(selectedOffre);
                }



            }
        }

    }
}
