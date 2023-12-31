﻿using System;
using System.Collections.Generic;

namespace Domain;

public partial class Paiement
{
    public string IdPaiement { get; set; } = null!;

    public string IdModePaiement { get; set; } = null!;

    public string IDfacturation { get; set; } = null!;

    public string? MomtantPaiement { get; set; }

    public long? Telephone { get; set; }

    public DateTime? DatePaiement { get; set; }

    public string? EtatPaiement { get; set; }

    public virtual Facturation IDfacturationNavigation { get; set; } = null!;

    public virtual ModePaiement IdModePaiementNavigation { get; set; } = null!;
}
