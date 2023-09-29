using System;
using System.Collections.Generic;

namespace GogoDriver.Models;

public partial class Chauffeur
{
    public string IdPersonne { get; set; } = null!;

    public string IdChauffeur { get; set; } = null!;

    public string? NumPermi { get; set; }

    public string? NumCapacite { get; set; }

    public int? EtatChauffeur { get; set; }

    public virtual Personne IdPersonneNavigation { get; set; } = null!;

    public virtual ICollection<Vehicule> Vehicules { get; set; } = new List<Vehicule>();
}
