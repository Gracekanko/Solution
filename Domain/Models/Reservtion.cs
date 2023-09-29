using System;
using System.Collections.Generic;

namespace Domain;

public partial class Reservtion
{
    public string IdReservation { get; set; } = null!;

    public string IdPersonne { get; set; } = null!;

    public string IdClient { get; set; } = null!;

    public string? IdPosition { get; set; }

    public string IdTypeReservation { get; set; } = null!;

    public DateTime? DateReservation { get; set; }

    public DateTime? HeureDebut { get; set; }

    public DateTime? HeureFin { get; set; }

    public bool? Position { get; set; }

    public int? NbrePassages { get; set; }

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

    public virtual ICollection<Facturation> Facturations { get; set; } = new List<Facturation>();

    public virtual Client Id { get; set; } = null!;

    public virtual Position? IdPositionNavigation { get; set; }

    public virtual TypeReservation IdTypeReservationNavigation { get; set; } = null!;
}
