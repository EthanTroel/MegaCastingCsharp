using System;
using System.Collections.Generic;

namespace MegaCastingDB.Class;

public partial class Sexe
{
    public int Identifiant { get; set; }

    public string Libelle { get; set; } = null!;

    public virtual ICollection<Offre> IdentifiantOffres { get; } = new List<Offre>();
}
