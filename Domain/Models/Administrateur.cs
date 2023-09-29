using System;
using System.Collections.Generic;

namespace Domain;

public partial class Administrateur
{
    public string IdPersonne { get; set; } = null!;

    public string IdAdmin { get; set; } = null!;

    public int? EtatAdmin { get; set; }

    public virtual Personne IdPersonneNavigation { get; set; } = null!;
}
