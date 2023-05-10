using System;
using System.Collections.Generic;

namespace MegaCastingDB.Class;

public partial class PackCasting
{
    public int Identifiant { get; set; }

    public string Libelle { get; set; } = null!;

    public short NombreOffres { get; set; }

    public short PrixPack { get; set; }

    public virtual ICollection<Client> Clients { get; } = new List<Client>();
}
