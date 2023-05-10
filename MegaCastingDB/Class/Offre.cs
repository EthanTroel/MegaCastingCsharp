using System;
using System.Collections.Generic;

namespace MegaCastingDB.Class;

public partial class Offre
{
    public int Identifiant { get; set; }

    public string Libelle { get; set; } = null!;

    public DateTime DateDebut { get; set; }

    public DateTime DateFin { get; set; }

    public string Reference { get; set; } = null!;

    public string Localisation { get; set; } = null!;

    public short AgeMin { get; set; }

    public short AgeMax { get; set; }

    public DateTime Date { get; set; }

    public string Description { get; set; } = null!;

    public int IdentifiantClient { get; set; }

    public int IdentifiantMetier { get; set; }

    public int IdentifiantTypeContrat { get; set; }

    public virtual Client IdentifiantClientNavigation { get; set; } = null!;

    public virtual Metier IdentifiantMetierNavigation { get; set; } = null!;

    public virtual TypeContrat IdentifiantTypeContratNavigation { get; set; } = null!;

    public virtual ICollection<PartenireDiffusion> IdentifiantPartenaireDiffusions { get; } = new List<PartenireDiffusion>();

    public virtual ICollection<Sexe> IdentifiantSexes { get; } = new List<Sexe>();
}
