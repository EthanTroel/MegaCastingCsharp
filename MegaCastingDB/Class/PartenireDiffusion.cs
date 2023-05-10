using System;
using System.Collections.Generic;

namespace MegaCastingDB.Class;

public partial class PartenireDiffusion
{
    public int Identifiant { get; set; }

    public string Tel { get; set; } = null!;

    public string Mail { get; set; } = null!;

    public string Nom { get; set; } = null!;

    public virtual ICollection<Offre> IdentifiantOffres { get; } = new List<Offre>();
}
