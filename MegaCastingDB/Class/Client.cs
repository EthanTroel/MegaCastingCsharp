using System;
using System.Collections.Generic;

namespace MegaCastingDB.Class;

public partial class Client
{
    public int Identifiant { get; set; }

    public string Nom { get; set; } = null!;

    public string Tel { get; set; } = null!;

    public string Mail { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Url { get; set; } = null!;

    public string Siret { get; set; } = null!;

    public string Login { get; set; } = null!;

    public string Ville { get; set; } = null!;

    public int NombreOffresRestantes { get; set; }

    public int IdentifiantPackCasting { get; set; }

    public virtual PackCasting IdentifiantPackCastingNavigation { get; set; } = null!;

    public virtual ICollection<Offre> Offres { get; } = new List<Offre>();
}
