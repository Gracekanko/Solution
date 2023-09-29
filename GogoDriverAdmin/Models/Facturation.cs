using System;
using System.Collections.Generic;

namespace GogoDriver.Models;

public partial class Facturation
{
    public string IdReservation { get; set; } = null!;

    public string IDfacturation { get; set; } = null!;

    public long? NomFacturation { get; set; }

    public decimal? PrixTtc { get; set; }

    public virtual Reservtion IdReservationNavigation { get; set; } = null!;

    public virtual ICollection<Paiement> Paiements { get; set; } = new List<Paiement>();
}
