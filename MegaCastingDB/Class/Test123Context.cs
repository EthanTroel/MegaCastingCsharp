using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MegaCastingDB.Class;

public partial class Test123Context : DbContext
{
    public Test123Context()
    {
    }

    public Test123Context(DbContextOptions<Test123Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Conseil> Conseils { get; set; }

    public virtual DbSet<DoctrineMigrationVersion> DoctrineMigrationVersions { get; set; }

    public virtual DbSet<DomaineMetier> DomaineMetiers { get; set; }

    public virtual DbSet<FicheMetier> FicheMetiers { get; set; }

    public virtual DbSet<Interview> Interviews { get; set; }

    public virtual DbSet<Metier> Metiers { get; set; }

    public virtual DbSet<Offre> Offres { get; set; }

    public virtual DbSet<PackCasting> PackCastings { get; set; }

    public virtual DbSet<PartenireDiffusion> PartenireDiffusions { get; set; }

    public virtual DbSet<Sexe> Sexes { get; set; }

    public virtual DbSet<TypeContrat> TypeContrats { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=Test123;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Identifiant).HasName("PK__Client__DD380E4E5EA8F8CC");

            entity.ToTable("Client");

            entity.HasIndex(e => e.IdentifiantPackCasting, "IDX_C0E801632719DBC1");

            entity.Property(e => e.Login).HasMaxLength(255);
            entity.Property(e => e.Mail).HasMaxLength(255);
            entity.Property(e => e.Nom).HasMaxLength(255);
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.Siret).HasMaxLength(255);
            entity.Property(e => e.Tel).HasMaxLength(10);
            entity.Property(e => e.Url).HasMaxLength(255);
            entity.Property(e => e.Ville).HasMaxLength(255);

            entity.HasOne(d => d.IdentifiantPackCastingNavigation).WithMany(p => p.Clients)
                .HasForeignKey(d => d.IdentifiantPackCasting)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_C0E801632719DBC1");
        });

        modelBuilder.Entity<Conseil>(entity =>
        {
            entity.HasKey(e => e.Identifiant).HasName("PK__Conseil__DD380E4E323D303D");

            entity.ToTable("Conseil");

            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.Libelle).HasMaxLength(255);

            entity.HasMany(d => d.IdentifiantMetiers).WithMany(p => p.IdentifiantConseils)
                .UsingEntity<Dictionary<string, object>>(
                    "ConseilMetier",
                    r => r.HasOne<Metier>().WithMany()
                        .HasForeignKey("IdentifiantMetier")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_38A13BC8525B950"),
                    l => l.HasOne<Conseil>().WithMany()
                        .HasForeignKey("IdentifiantConseil")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_38A13BC8B00E1DCA"),
                    j =>
                    {
                        j.HasKey("IdentifiantConseil", "IdentifiantMetier").HasName("PK__ConseilM__D0AECADA1C02EEE9");
                        j.ToTable("ConseilMetier");
                        j.HasIndex(new[] { "IdentifiantMetier" }, "IDX_38A13BC8525B950");
                        j.HasIndex(new[] { "IdentifiantConseil" }, "IDX_38A13BC8B00E1DCA");
                    });
        });

        modelBuilder.Entity<DoctrineMigrationVersion>(entity =>
        {
            entity.HasKey(e => e.Version).HasName("PK__doctrine__79B5C94CB3FF9F0E");

            entity.ToTable("doctrine_migration_versions");

            entity.Property(e => e.Version)
                .HasMaxLength(191)
                .HasColumnName("version");
            entity.Property(e => e.ExecutedAt)
                .HasPrecision(6)
                .HasColumnName("executed_at");
            entity.Property(e => e.ExecutionTime).HasColumnName("execution_time");
        });

        modelBuilder.Entity<DomaineMetier>(entity =>
        {
            entity.HasKey(e => e.Identifiant).HasName("PK__DomaineM__DD380E4E9EA9B94F");

            entity.ToTable("DomaineMetier");

            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.Libelle).HasMaxLength(255);
        });

        modelBuilder.Entity<FicheMetier>(entity =>
        {
            entity.HasKey(e => e.Identifiant).HasName("PK__FicheMet__DD380E4E6A16FF15");

            entity.ToTable("FicheMetier");

            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.Libelle).HasMaxLength(255);
        });

        modelBuilder.Entity<Interview>(entity =>
        {
            entity.HasKey(e => e.Identifiant).HasName("PK__Intervie__DD380E4EB1819C0E");

            entity.ToTable("Interview");

            entity.Property(e => e.Libelle).HasMaxLength(255);
        });

        modelBuilder.Entity<Metier>(entity =>
        {
            entity.HasKey(e => e.Identifiant).HasName("PK__Metier__DD380E4E48C91D69");

            entity.ToTable("Metier");

            entity.HasIndex(e => e.IdentifiantFicheMetier, "IDX_560C08BA418804B7");

            entity.HasIndex(e => e.IdentifiantDomaineMetier, "IDX_560C08BAE52D612A");

            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.Libelle).HasMaxLength(255);

            entity.HasOne(d => d.IdentifiantDomaineMetierNavigation).WithMany(p => p.Metiers)
                .HasForeignKey(d => d.IdentifiantDomaineMetier)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_560C08BAE52D612A");

            entity.HasOne(d => d.IdentifiantFicheMetierNavigation).WithMany(p => p.Metiers)
                .HasForeignKey(d => d.IdentifiantFicheMetier)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_560C08BA418804B7");
        });

        modelBuilder.Entity<Offre>(entity =>
        {
            entity.HasKey(e => e.Identifiant).HasName("PK__Offre__DD380E4E2272D991");

            entity.ToTable("Offre");

            entity.HasIndex(e => e.IdentifiantMetier, "IDX_6E47A96B525B950");

            entity.HasIndex(e => e.IdentifiantTypeContrat, "IDX_6E47A96B9251261A");

            entity.HasIndex(e => e.IdentifiantClient, "IDX_6E47A96B93C1B089");

            entity.Property(e => e.Date).HasPrecision(6);
            entity.Property(e => e.DateDebut).HasPrecision(6);
            entity.Property(e => e.DateFin).HasPrecision(6);
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.Libelle).HasMaxLength(255);
            entity.Property(e => e.Localisation).HasMaxLength(255);
            entity.Property(e => e.Reference).HasMaxLength(255);

            entity.HasOne(d => d.IdentifiantClientNavigation).WithMany(p => p.Offres)
                .HasForeignKey(d => d.IdentifiantClient)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_6E47A96B93C1B089");

            entity.HasOne(d => d.IdentifiantMetierNavigation).WithMany(p => p.Offres)
                .HasForeignKey(d => d.IdentifiantMetier)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_6E47A96B525B950");

            entity.HasOne(d => d.IdentifiantTypeContratNavigation).WithMany(p => p.Offres)
                .HasForeignKey(d => d.IdentifiantTypeContrat)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_6E47A96B9251261A");
        });

        modelBuilder.Entity<PackCasting>(entity =>
        {
            entity.HasKey(e => e.Identifiant).HasName("PK__PackCast__DD380E4E2849B5B3");

            entity.ToTable("PackCasting");

            entity.Property(e => e.Libelle).HasMaxLength(255);
        });

        modelBuilder.Entity<PartenireDiffusion>(entity =>
        {
            entity.HasKey(e => e.Identifiant).HasName("PK__Partenir__DD380E4ECFB4D65B");

            entity.ToTable("PartenireDiffusion");

            entity.Property(e => e.Mail).HasMaxLength(255);
            entity.Property(e => e.Nom).HasMaxLength(255);
            entity.Property(e => e.Tel).HasMaxLength(255);

            entity.HasMany(d => d.IdentifiantOffres).WithMany(p => p.IdentifiantPartenaireDiffusions)
                .UsingEntity<Dictionary<string, object>>(
                    "PartenaireDiffusionOffre",
                    r => r.HasOne<Offre>().WithMany()
                        .HasForeignKey("IdentifiantOffre")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_E50AB74F4657399"),
                    l => l.HasOne<PartenireDiffusion>().WithMany()
                        .HasForeignKey("IdentifiantPartenaireDiffusion")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_E50AB741F5A46F8"),
                    j =>
                    {
                        j.HasKey("IdentifiantPartenaireDiffusion", "IdentifiantOffre").HasName("PK__Partenai__A24770CE9BC8DB5B");
                        j.ToTable("PartenaireDiffusionOffre");
                        j.HasIndex(new[] { "IdentifiantPartenaireDiffusion" }, "IDX_E50AB741F5A46F8");
                        j.HasIndex(new[] { "IdentifiantOffre" }, "IDX_E50AB74F4657399");
                    });
        });

        modelBuilder.Entity<Sexe>(entity =>
        {
            entity.HasKey(e => e.Identifiant).HasName("PK__Sexe__DD380E4E92D010A7");

            entity.ToTable("Sexe");

            entity.Property(e => e.Libelle).HasMaxLength(255);

            entity.HasMany(d => d.IdentifiantOffres).WithMany(p => p.IdentifiantSexes)
                .UsingEntity<Dictionary<string, object>>(
                    "SexeOffre",
                    r => r.HasOne<Offre>().WithMany()
                        .HasForeignKey("IdentifiantOffre")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_1A069911F4657399"),
                    l => l.HasOne<Sexe>().WithMany()
                        .HasForeignKey("IdentifiantSexe")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_1A069911F1B75433"),
                    j =>
                    {
                        j.HasKey("IdentifiantSexe", "IdentifiantOffre").HasName("PK__SexeOffr__5A11104BAE3724D9");
                        j.ToTable("SexeOffre");
                        j.HasIndex(new[] { "IdentifiantSexe" }, "IDX_1A069911F1B75433");
                        j.HasIndex(new[] { "IdentifiantOffre" }, "IDX_1A069911F4657399");
                    });
        });

        modelBuilder.Entity<TypeContrat>(entity =>
        {
            entity.HasKey(e => e.Identifiant).HasName("PK__TypeCont__DD380E4EA2F8768B");

            entity.ToTable("TypeContrat");

            entity.Property(e => e.Libelle).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
