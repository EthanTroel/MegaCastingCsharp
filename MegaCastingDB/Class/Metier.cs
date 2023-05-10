using System;
using System.Collections.Generic;

namespace MegaCastingDB.Class;

public partial class Metier
{
    public int Identifiant { get; set; }

    public string Libelle { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int IdentifiantFicheMetier { get; set; }

    public int IdentifiantDomaineMetier { get; set; }

    public virtual DomaineMetier IdentifiantDomaineMetierNavigation { get; set; } = null!;

    public virtual FicheMetier IdentifiantFicheMetierNavigation { get; set; } = null!;

    public virtual ICollection<Offre> Offres { get; } = new List<Offre>();

    public virtual ICollection<Conseil> IdentifiantConseils { get; } = new List<Conseil>();
}
