using System;
using System.Collections.Generic;

namespace Domain;

public partial class Personne
{
    public string IdPersonne { get; set; } = null!;

    public string? Nom { get; set; }

    public string? Prenom { get; set; }

    public string? EMail { get; set; }

    public string? Sexe { get; set; }

    public long? Cni { get; set; }

    public string? Login { get; set; }

    public string? MotDePasse { get; set; }

    public virtual ICollection<Administrateur> Administrateurs { get; set; } = new List<Administrateur>();

    public virtual ICollection<Chauffeur> Chauffeurs { get; set; } = new List<Chauffeur>();

    public virtual ICollection<Client> Clients { get; set; } = new List<Client>();
}
