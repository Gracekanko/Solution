﻿using System;
using System.Collections.Generic;

namespace Domain;

public partial class ModePaiement
{
    public string IdModePaiement { get; set; } = null!;

    public string? LibelleMode { get; set; }

    public string? Pourcentage { get; set; }

    public virtual ICollection<Paiement> Paiements { get; set; } = new List<Paiement>();
}
