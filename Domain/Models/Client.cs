using System;
using System.Collections.Generic;

namespace Domain;

public partial class Client
{
    public string IdPersonne { get; set; } = null!;

    public string IdClient { get; set; } = null!;

    public int? EtatClient { get; set; }

    public virtual Personne IdPersonneNavigation { get; set; } = null!;

    public virtual ICollection<Reservtion> Reservtions { get; set; } = new List<Reservtion>();

    public virtual ICollection<Suggestion> Suggestions { get; set; } = new List<Suggestion>();
}
