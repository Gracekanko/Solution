using System;
using System.Collections.Generic;

namespace Domain;

public partial class Position
{
    public string IdPosition { get; set; } = null!;

    public string? LibellePosition { get; set; }

    public bool? Depart { get; set; }

    public double? Geolocalisation { get; set; }

    public virtual ICollection<Reservtion> Reservtions { get; set; } = new List<Reservtion>();
}
