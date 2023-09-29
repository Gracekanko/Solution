using System;
using System.Collections.Generic;

namespace Domain;

public partial class Vehicule
{
    public string IdVehicule { get; set; } = null!;

    public string IdPersonne { get; set; } = null!;

    public string IdChauffeur { get; set; } = null!;

    public string IdTypeReservation { get; set; } = null!;

    public string? NomVehicule { get; set; }

    public string? Immatriculation { get; set; }

    public string? Couleur { get; set; }

    public string? Assurance { get; set; }

    public int? NumeroChassis { get; set; }

    public string? Marque { get; set; }

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();

    public virtual Chauffeur Id { get; set; } = null!;

    public virtual TypeReservation IdTypeReservationNavigation { get; set; } = null!;
}
