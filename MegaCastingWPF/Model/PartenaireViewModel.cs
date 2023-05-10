using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MegaCastingDB.Class;

namespace MegaCastingWPF.Model
{
    public class PartenaireViewModel
    {

        #region Attributs & Propriétés
        private PartenireDiffusion _selectedPartenaire;
        public PartenireDiffusion SelectedPartenaire
        {
            get { return _selectedPartenaire; }
            set { _selectedPartenaire = value; }
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


        private ObservableCollection<PartenireDiffusion>? _partnairesList;
        public ObservableCollection<PartenireDiffusion>? PartenairesList
        {
            get { return _partnairesList; }
            set
            {
                _partnairesList = value;
            }
        }
        #endregion


        /// <summary>
        /// Remplit la liste des partenaires dans la grille de données (datagrid)
        /// </summary>
        public void RemplirDataGrid()
        {
            Test123Context dbContext = new Test123Context();
            var partenaires = dbContext.PartenireDiffusions.ToList();
            PartenairesList = new ObservableCollection<PartenireDiffusion>(partenaires);
        }

        /// <summary>
        /// Ajoute un nouveau partenaire dans la base de données
        /// </summary>
        public void AddNewPartenaire()
        {
            Test123Context dbContext = new Test123Context();
            if (!string.IsNullOrEmpty(TextBoxNom) &&
                !string.IsNullOrEmpty(TextBoxTel) &&
                !string.IsNullOrEmpty(TextBoxMail))
            {
                PartenireDiffusion newpartenaire = new PartenireDiffusion
                {
                    Nom = TextBoxNom,
                    Tel = TextBoxTel,
                    Mail = TextBoxMail
                };

                // Ajout du nouveau partenaire à la base de données
                dbContext.PartenireDiffusions.Add(newpartenaire);
                dbContext.SaveChanges();
                PartenairesList.Add(newpartenaire);
            }
        }


        /// <summary>
        /// Met à jour un partenaire existant dans la base de données
        /// </summary>
        /// <param name="selectedPartenaire">Le partenaire à mettre à jour</param>
        public void UpdatePartenaire(PartenireDiffusion selectedPartenaire)
        {
            Test123Context dbContext = new Test123Context();

            if (!string.IsNullOrEmpty(TextBoxNom) && !string.IsNullOrEmpty(TextBoxTel) && !string.IsNullOrEmpty(TextBoxMail))
            {
                PartenireDiffusion PartenaireUpdate = dbContext.PartenireDiffusions.Find(selectedPartenaire.Identifiant);

                PartenaireUpdate.Nom = TextBoxNom;
                PartenaireUpdate.Tel = TextBoxTel;
                PartenaireUpdate.Mail = TextBoxMail;

                dbContext.PartenireDiffusions.Update(PartenaireUpdate);
                dbContext.SaveChanges();
                PartenairesList[PartenairesList.IndexOf(SelectedPartenaire)] = PartenaireUpdate;
            }
        }


        /// <summary>
        /// Supprime un partenaire de la base de données
        /// </summary>
        public void DeletePartenaire()
        {
            Test123Context dbContext = new Test123Context();
            if (SelectedPartenaire != null)
            {
                PartenireDiffusion? selectedPartenaire = SelectedPartenaire;
                PartenireDiffusion partenaireToDelete = dbContext.PartenireDiffusions.Find(selectedPartenaire.Identifiant);
                if (partenaireToDelete != null)
                {
                    dbContext.PartenireDiffusions.Remove(partenaireToDelete);
                    dbContext.SaveChanges();
                    PartenairesList.Remove(selectedPartenaire);
                }
            }
        }
    }
}

