using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace GogoDriver.Models;

public partial class GogoBdContext : DbContext
{
    public GogoBdContext()
    {
    }

    public GogoBdContext(DbContextOptions<GogoBdContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Administrateur> Administrateurs { get; set; }

    public virtual DbSet<Chauffeur> Chauffeurs { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Facturation> Facturations { get; set; }

    public virtual DbSet<ModePaiement> ModePaiements { get; set; }

    public virtual DbSet<Paiement> Paiements { get; set; }

    public virtual DbSet<Personne> Personnes { get; set; }

    public virtual DbSet<Position> Positions { get; set; }

    public virtual DbSet<Reservtion> Reservtions { get; set; }

    public virtual DbSet<Suggestion> Suggestions { get; set; }

    public virtual DbSet<TypeReservation> TypeReservations { get; set; }

    public virtual DbSet<Vehicule> Vehicules { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.\\;Initial Catalog=gogoBD; Trusted_Connection=True; TrustServerCertificate=True; ");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Administrateur>(entity =>
        {
            entity.HasKey(e => new { e.IdPersonne, e.IdAdmin })
                .HasName("PK_ADMINISTRATEUR")
                .IsClustered(false);

            entity.ToTable("Administrateur");

            entity.HasIndex(e => e.IdAdmin, "AK_IDENTIFIANT_1_ADMINIST").IsUnique();

            entity.HasIndex(e => e.IdPersonne, "GENERALISATION_3_FK");

            entity.Property(e => e.IdPersonne)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("idPersonne");
            entity.Property(e => e.IdAdmin)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("idAdmin");
            entity.Property(e => e.EtatAdmin).HasColumnName("etatAdmin");

            entity.HasOne(d => d.IdPersonneNavigation).WithMany(p => p.Administrateurs)
                .HasForeignKey(d => d.IdPersonne)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ADMINIST_GENERALIS_PERSONNE");
        });

        modelBuilder.Entity<Chauffeur>(entity =>
        {
            entity.HasKey(e => new { e.IdPersonne, e.IdChauffeur })
                .HasName("PK_CHAUFFEUR")
                .IsClustered(false);

            entity.ToTable("Chauffeur");

            entity.HasIndex(e => e.IdPersonne, "GENERALISATION_2_FK");

            entity.Property(e => e.IdPersonne)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("idPersonne");
            entity.Property(e => e.IdChauffeur)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("idChauffeur");
            entity.Property(e => e.EtatChauffeur).HasColumnName("etatChauffeur");
            entity.Property(e => e.NumCapacite)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("numCapacite");
            entity.Property(e => e.NumPermi)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("numPermi");

            entity.HasOne(d => d.IdPersonneNavigation).WithMany(p => p.Chauffeurs)
                .HasForeignKey(d => d.IdPersonne)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CHAUFFEU_GENERALIS_PERSONNE");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => new { e.IdPersonne, e.IdClient })
                .HasName("PK_CLIENT")
                .IsClustered(false);

            entity.ToTable("Client");

            entity.HasIndex(e => e.IdClient, "AK_IDENTIFIANT_1_CLIENT").IsUnique();

            entity.HasIndex(e => e.IdPersonne, "GENERALISATION_1_FK");

            entity.Property(e => e.IdPersonne)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("idPersonne");
            entity.Property(e => e.IdClient)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("idClient");
            entity.Property(e => e.EtatClient).HasColumnName("etatClient");

            entity.HasOne(d => d.IdPersonneNavigation).WithMany(p => p.Clients)
                .HasForeignKey(d => d.IdPersonne)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CLIENT_GENERALIS_PERSONNE");
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.IdCourse)
                .HasName("PK_COURSE")
                .IsClustered(false);

            entity.ToTable("Course");

            entity.HasIndex(e => e.IdReservation, "ASSOCIATION5_FK");

            entity.HasIndex(e => e.IdVehicule, "ASSOCIATION6_FK");

            entity.Property(e => e.IdCourse)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("idCourse");
            entity.Property(e => e.DateCourse)
                .HasColumnType("datetime")
                .HasColumnName("dateCourse");
            entity.Property(e => e.Destination).HasColumnName("destination");
            entity.Property(e => e.EtatCourse).HasColumnName("etatCourse");
            entity.Property(e => e.HeureCourse)
                .HasColumnType("datetime")
                .HasColumnName("heureCourse");
            entity.Property(e => e.IdReservation)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("idReservation");
            entity.Property(e => e.IdVehicule)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("idVehicule");

            entity.HasOne(d => d.IdReservationNavigation).WithMany(p => p.Courses)
                .HasForeignKey(d => d.IdReservation)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_COURSE_ASSOCIATI_RESERVTI");

            entity.HasOne(d => d.IdVehiculeNavigation).WithMany(p => p.Courses)
                .HasForeignKey(d => d.IdVehicule)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_COURSE_ASSOCIATI_VEHICULE");
        });

        modelBuilder.Entity<Facturation>(entity =>
        {
            entity.HasKey(e => e.IDfacturation)
                .HasName("PK_FACTURATION")
                .IsClustered(false);

            entity.ToTable("Facturation");

            entity.HasIndex(e => e.IdReservation, "ASSOCIATION13_FK");

            entity.Property(e => e.IDfacturation)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("iDFacturation");
            entity.Property(e => e.IdReservation)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("idReservation");
            entity.Property(e => e.NomFacturation).HasColumnName("nomFacturation");
            entity.Property(e => e.PrixTtc)
                .HasColumnType("numeric(18, 0)")
                .HasColumnName("prixTTC");

            entity.HasOne(d => d.IdReservationNavigation).WithMany(p => p.Facturations)
                .HasForeignKey(d => d.IdReservation)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_FACTURAT_ASSOCIATI_RESERVTI");
        });

        modelBuilder.Entity<ModePaiement>(entity =>
        {
            entity.HasKey(e => e.IdModePaiement)
                .HasName("PK_MODEPAIEMENT")
                .IsClustered(false);

            entity.ToTable("ModePaiement");

            entity.Property(e => e.IdModePaiement)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("idModePaiement");
            entity.Property(e => e.LibelleMode)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("libelleMode");
            entity.Property(e => e.Pourcentage)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("pourcentage");
        });

        modelBuilder.Entity<Paiement>(entity =>
        {
            entity.HasKey(e => e.IdPaiement)
                .HasName("PK_PAIEMENT")
                .IsClustered(false);

            entity.ToTable("Paiement");

            entity.HasIndex(e => e.IdModePaiement, "ASSOCIATION11_FK");

            entity.HasIndex(e => e.IDfacturation, "ASSOCIATION16_FK");

            entity.Property(e => e.IdPaiement)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("idPaiement");
            entity.Property(e => e.DatePaiement)
                .HasColumnType("datetime")
                .HasColumnName("datePaiement");
            entity.Property(e => e.EtatPaiement)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("etatPaiement");
            entity.Property(e => e.IDfacturation)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("iDFacturation");
            entity.Property(e => e.IdModePaiement)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("idModePaiement");
            entity.Property(e => e.MomtantPaiement)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("momtantPaiement");
            entity.Property(e => e.Telephone).HasColumnName("telephone");

            entity.HasOne(d => d.IDfacturationNavigation).WithMany(p => p.Paiements)
                .HasForeignKey(d => d.IDfacturation)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PAIEMENT_ASSOCIATI_FACTURAT");

            entity.HasOne(d => d.IdModePaiementNavigation).WithMany(p => p.Paiements)
                .HasForeignKey(d => d.IdModePaiement)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PAIEMENT_ASSOCIATI_MODEPAIE");
        });

        modelBuilder.Entity<Personne>(entity =>
        {
            entity.HasKey(e => e.IdPersonne)
                .HasName("PK_PERSONNE")
                .IsClustered(false);

            entity.ToTable("Personne");

            entity.Property(e => e.IdPersonne)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("idPersonne");
            entity.Property(e => e.Cni).HasColumnName("cni");
            entity.Property(e => e.EMail)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("eMail");
            entity.Property(e => e.Login)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("login");
            entity.Property(e => e.MotDePasse)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("motDePasse");
            entity.Property(e => e.Nom)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("nom");
            entity.Property(e => e.Prenom)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("prenom");
            entity.Property(e => e.Sexe)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("sexe");
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.HasKey(e => e.IdPosition)
                .HasName("PK_POSITION")
                .IsClustered(false);

            entity.ToTable("Position");

            entity.HasIndex(e => e.IdPosition, "AK_IDENTIFIANT_1_POSITION").IsUnique();

            entity.Property(e => e.IdPosition)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("idPosition");
            entity.Property(e => e.Depart).HasColumnName("depart");
            entity.Property(e => e.Geolocalisation).HasColumnName("geolocalisation");
            entity.Property(e => e.LibellePosition)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("libellePosition");
        });

        modelBuilder.Entity<Reservtion>(entity =>
        {
            entity.HasKey(e => e.IdReservation)
                .HasName("PK_RESERVTION")
                .IsClustered(false);

            entity.ToTable("Reservtion");

            entity.HasIndex(e => e.IdReservation, "AK_IDENTIFIANT_1_RESERVTI").IsUnique();

            entity.HasIndex(e => e.IdPosition, "ASSOCIATION12_FK");

            entity.HasIndex(e => new { e.IdPersonne, e.IdClient }, "ASSOCIATION3_FK");

            entity.HasIndex(e => e.IdTypeReservation, "ASSOCIATION8_FK");

            entity.Property(e => e.IdReservation)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("idReservation");
            entity.Property(e => e.DateReservation)
                .HasColumnType("datetime")
                .HasColumnName("dateReservation");
            entity.Property(e => e.HeureDebut)
                .HasColumnType("datetime")
                .HasColumnName("heureDebut");
            entity.Property(e => e.HeureFin)
                .HasColumnType("datetime")
                .HasColumnName("heureFin");
            entity.Property(e => e.IdClient)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("idClient");
            entity.Property(e => e.IdPersonne)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("idPersonne");
            entity.Property(e => e.IdPosition)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("idPosition");
            entity.Property(e => e.IdTypeReservation)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("idTypeReservation");
            entity.Property(e => e.NbrePassages).HasColumnName("nbrePassages");
            entity.Property(e => e.Position).HasColumnName("position");

            entity.HasOne(d => d.IdPositionNavigation).WithMany(p => p.Reservtions)
                .HasForeignKey(d => d.IdPosition)
                .HasConstraintName("FK_RESERVTI_ASSOCIATI_POSITION");

            entity.HasOne(d => d.IdTypeReservationNavigation).WithMany(p => p.Reservtions)
                .HasForeignKey(d => d.IdTypeReservation)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RESERVTI_ASSOCIATI_TYPERESE");

            entity.HasOne(d => d.Id).WithMany(p => p.Reservtions)
                .HasForeignKey(d => new { d.IdPersonne, d.IdClient })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RESERVTI_ASSOCIATI_CLIENT");
        });

        modelBuilder.Entity<Suggestion>(entity =>
        {
            entity.HasKey(e => e.IdSuggestion)
                .HasName("PK_SUGGESTION")
                .IsClustered(false);

            entity.ToTable("Suggestion");

            entity.HasIndex(e => new { e.IdPersonne, e.IdClient }, "ASSOCIATION14_FK");

            entity.Property(e => e.IdSuggestion)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("idSuggestion");
            entity.Property(e => e.DateSuggetion)
                .HasColumnType("datetime")
                .HasColumnName("dateSuggetion");
            entity.Property(e => e.IdClient)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("idClient");
            entity.Property(e => e.IdPersonne)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("idPersonne");
            entity.Property(e => e.LibelleSuggestion)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("libelleSuggestion");

            entity.HasOne(d => d.Id).WithMany(p => p.Suggestions)
                .HasForeignKey(d => new { d.IdPersonne, d.IdClient })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SUGGESTI_ASSOCIATI_CLIENT");
        });

        modelBuilder.Entity<TypeReservation>(entity =>
        {
            entity.HasKey(e => e.IdTypeReservation)
                .HasName("PK_TYPERESERVATION")
                .IsClustered(false);

            entity.ToTable("TypeReservation");

            entity.Property(e => e.IdTypeReservation)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("idTypeReservation");
            entity.Property(e => e.NomType)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("nomType");
            entity.Property(e => e.PrixUnitaire).HasColumnName("prixUnitaire");
            entity.Property(e => e.TauxPeriodique).HasColumnName("tauxPeriodique");
        });

        modelBuilder.Entity<Vehicule>(entity =>
        {
            entity.HasKey(e => e.IdVehicule)
                .HasName("PK_VEHICULE")
                .IsClustered(false);

            entity.ToTable("Vehicule");

            entity.HasIndex(e => e.IdVehicule, "AK_IDENTIFIANT_1_VEHICULE").IsUnique();

            entity.HasIndex(e => new { e.IdPersonne, e.IdChauffeur }, "ASSOCIATION4_FK");

            entity.HasIndex(e => e.IdTypeReservation, "ASSOCIATION7_FK");

            entity.Property(e => e.IdVehicule)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("idVehicule");
            entity.Property(e => e.Assurance)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("assurance");
            entity.Property(e => e.Couleur)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("couleur");
            entity.Property(e => e.IdChauffeur)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("idChauffeur");
            entity.Property(e => e.IdPersonne)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("idPersonne");
            entity.Property(e => e.IdTypeReservation)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("idTypeReservation");
            entity.Property(e => e.Immatriculation)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("immatriculation");
            entity.Property(e => e.Marque)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("marque");
            entity.Property(e => e.NomVehicule)
                .HasMaxLength(254)
                .IsUnicode(false)
                .HasColumnName("nomVehicule");
            entity.Property(e => e.NumeroChassis).HasColumnName("numeroChassis");

            entity.HasOne(d => d.IdTypeReservationNavigation).WithMany(p => p.Vehicules)
                .HasForeignKey(d => d.IdTypeReservation)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VEHICULE_ASSOCIATI_TYPERESE");

            entity.HasOne(d => d.Id).WithMany(p => p.Vehicules)
                .HasForeignKey(d => new { d.IdPersonne, d.IdChauffeur })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VEHICULE_ASSOCIATI_CHAUFFEU");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
