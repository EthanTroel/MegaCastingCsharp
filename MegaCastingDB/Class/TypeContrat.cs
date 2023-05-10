using System;
using System.Collections.Generic;

namespace MegaCastingDB.Class;

public partial class TypeContrat
{
    public int Identifiant { get; set; }

    public string Libelle { get; set; } = null!;

    public virtual ICollection<Offre> Offres { get; } = new List<Offre>();
}
