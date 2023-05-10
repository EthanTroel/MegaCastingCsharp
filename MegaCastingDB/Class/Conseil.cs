﻿using System;
using System.Collections.Generic;

namespace MegaCastingDB.Class;

public partial class Conseil
{
    public int Identifiant { get; set; }

    public string Libelle { get; set; } = null!;

    public string Description { get; set; } = null!;

    public virtual ICollection<Metier> IdentifiantMetiers { get; } = new List<Metier>();
}
