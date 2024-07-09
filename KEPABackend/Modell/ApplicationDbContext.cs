﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace KEPABackend.Modell
{
    /// <summary>
    /// ApplicationDbContext
    /// </summary>
    public partial class ApplicationDbContext : DbContext
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public ApplicationDbContext()
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="options"></param>
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public virtual DbSet<Tbl9erRatten> Tbl9erRattens { get; set; } = null!;

        /// <summary>
        /// 
        /// </summary>
        public virtual DbSet<TblDbchangeLog> TblDbchangeLogs { get; set; } = null!;

        /// <summary>
        /// 
        /// </summary>
        public virtual DbSet<TblMeisterschaften> TblMeisterschaftens { get; set; } = null!;

        /// <summary>
        /// 
        /// </summary>
        public virtual DbSet<TblMeisterschaftstyp> TblMeisterschaftstyps { get; set; } = null!;

        /// <summary>
        /// 
        /// </summary>
        public virtual DbSet<TblMitglieder> TblMitglieders { get; set; } = null!;

        /// <summary>
        /// 
        /// </summary>
        public virtual DbSet<TblSetting> TblSettings { get; set; } = null!;

        /// <summary>
        /// 
        /// </summary>
        public virtual DbSet<TblSpiel6TageRennen> TblSpiel6TageRennens { get; set; } = null!;

        /// <summary>
        /// 
        /// </summary>
        public virtual DbSet<TblSpielBlitztunier> TblSpielBlitztuniers { get; set; } = null!;

        /// <summary>
        /// 
        /// </summary>
        public virtual DbSet<TblSpielKombimeisterschaft> TblSpielKombimeisterschafts { get; set; } = null!;

        /// <summary>
        /// 
        /// </summary>
        public virtual DbSet<TblSpielMeisterschaft> TblSpielMeisterschafts { get; set; } = null!;

        /// <summary>
        /// 
        /// </summary>
        public virtual DbSet<TblSpielPokal> TblSpielPokals { get; set; } = null!;

        /// <summary>
        /// 
        /// </summary>
        public virtual DbSet<TblSpielSargKegeln> TblSpielSargKegelns { get; set; } = null!;

        /// <summary>
        /// 
        /// </summary>
        public virtual DbSet<TblSpieltag> TblSpieltags { get; set; } = null!;

        /// <summary>
        /// 
        /// </summary>
        public virtual DbSet<TblTeilnehmer> TblTeilnehmers { get; set; } = null!;


        /// <summary>
        /// OnConfiguring
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("server=w01bdc60.kasserver.com;database=d03c455b;uid=d03c455b;pwd=KKpJnQJsm2t6VNXo;sslmode=Required", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.5.25-mariadb"));
            }
        }

        /// <summary>
        /// OnModelCreating
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_general_ci").HasCharSet("utf8mb4");

            modelBuilder.Entity<Tbl9erRatten>(entity =>
            {
                entity.ToTable("tbl9erRatten");

                entity.HasIndex(e => e.SpielerId, "FK_tbl9erRatten_tblMitglieder");

                entity.HasIndex(e => e.SpieltagId, "FK_tbl9erRatten_tblSpieltag");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.Neuner).HasColumnType("int(11)");

                entity.Property(e => e.Ratten).HasColumnType("int(11)");

                entity.Property(e => e.SpielerId)
                    .HasColumnType("int(11)")
                    .HasColumnName("SpielerID");

                entity.Property(e => e.SpieltagId)
                    .HasColumnType("int(11)")
                    .HasColumnName("SpieltagID");

                entity.HasOne(d => d.Spieler)
                    .WithMany(p => p.Tbl9erRattens)
                    .HasForeignKey(d => d.SpielerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl9erRatten_tblMitglieder");

                entity.HasOne(d => d.Spieltag)
                    .WithMany(p => p.Tbl9erRattens)
                    .HasForeignKey(d => d.SpieltagId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tbl9erRatten_tblSpieltag");
            });

            modelBuilder.Entity<TblDbchangeLog>(entity =>
            {
                entity.ToTable("tblDBChangeLog");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.Zeitstempel).HasColumnType("datetime");
            });

            modelBuilder.Entity<TblMeisterschaften>(entity =>
            {
                entity.ToTable("tblMeisterschaften");

                entity.HasIndex(e => e.MeisterschaftstypId, "FK_tblMeisterschaften_tblMeisterschaftstyp");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.Aktiv).HasColumnType("int(11)");

                entity.Property(e => e.Beginn)
                    .IsRequired()
                    .HasColumnType("datetime");

                entity.Property(e => e.Bezeichnung)
                    .IsRequired()
                    .HasMaxLength(100)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Ende).HasColumnType("datetime");

                entity.Property(e => e.MeisterschaftstypId)
                    .HasColumnType("int(11)")
                    .HasColumnName("MeisterschaftstypID");

                entity.Property(e => e.TurboDbnummer)
                    .HasColumnType("int(11)")
                    .HasColumnName("TurboDBNummer");

                entity.HasOne(d => d.Meisterschaftstyp)
                    .WithMany(p => p.TblMeisterschaftens)
                    .HasForeignKey(d => d.MeisterschaftstypId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblMeisterschaften_tblMeisterschaftstyp");
            });

            modelBuilder.Entity<TblMeisterschaftstyp>(entity =>
            {
                entity.ToTable("tblMeisterschaftstyp");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.Meisterschaftstyp)
                    .HasMaxLength(100)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");
            });

            modelBuilder.Entity<TblMitglieder>(entity =>
            {
                entity.ToTable("tblMitglieder");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.Anrede)
                    .HasMaxLength(50)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.AusgeschiedenAm).HasColumnType("datetime");

                entity.Property(e => e.Ehemaliger).HasColumnType("bit(1)");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .HasColumnName("EMail")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Fax)
                    .HasMaxLength(50)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Geburtsdatum).HasColumnType("datetime");

                entity.Property(e => e.HolzGes).HasColumnType("int(11)");

                entity.Property(e => e.HolzMax).HasColumnType("int(11)");

                entity.Property(e => e.HolzMin).HasColumnType("int(11)");

                entity.Property(e => e.MitgliedSeit)
                    .IsRequired()
                    .HasColumnType("datetime");

                entity.Property(e => e.Nachname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Ort)
                    .HasMaxLength(50)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.PassivSeit).HasColumnType("datetime");

                entity.Property(e => e.Platz).HasMaxLength(255);

                entity.Property(e => e.Plz)
                    .HasMaxLength(5)
                    .HasColumnName("PLZ")
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Punkte).HasColumnType("int(11)");

                entity.Property(e => e.SpAnz).HasColumnType("int(11)");

                entity.Property(e => e.SpGew).HasColumnType("int(11)");

                entity.Property(e => e.SpUn).HasColumnType("int(11)");

                entity.Property(e => e.SpVerl).HasColumnType("int(11)");

                entity.Property(e => e.Spitzname)
                    .HasMaxLength(50)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.Straße)
                    .HasMaxLength(50)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.TelefonFirma)
                    .HasMaxLength(50)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.TelefonMobil)
                    .HasMaxLength(50)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.TelefonPrivat)
                    .HasMaxLength(50)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");

                entity.Property(e => e.TurboDbnummer)
                    .HasColumnType("int(11)")
                    .HasColumnName("TurboDBNummer");

                entity.Property(e => e.Vorname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .UseCollation("utf8_general_ci")
                    .HasCharSet("utf8");
            });

            modelBuilder.Entity<TblSetting>(entity =>
            {
                entity.ToTable("tblSettings");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.Computername).HasMaxLength(50);

                entity.Property(e => e.Parametername).HasMaxLength(100);

                entity.Property(e => e.Parameterwert).HasMaxLength(4000);
            });

            modelBuilder.Entity<TblSpiel6TageRennen>(entity =>
            {
                entity.ToTable("tblSpiel6TageRennen");

                entity.HasIndex(e => e.SpielerId1, "FK_tblSpiel6TageRennen_tblMitglieder");

                entity.HasIndex(e => e.SpielerId2, "FK_tblSpiel6TageRennen_tblMitglieder1");

                entity.HasIndex(e => e.SpieltagId, "FK_tblSpiel6TageRennen_tblSpieltag");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.Punkte).HasColumnType("int(11)");

                entity.Property(e => e.Runden).HasColumnType("int(11)");

                entity.Property(e => e.SpielerId1)
                    .HasColumnType("int(11)")
                    .HasColumnName("SpielerID1");

                entity.Property(e => e.SpielerId2)
                    .HasColumnType("int(11)")
                    .HasColumnName("SpielerID2");

                entity.Property(e => e.Spielnummer)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.SpieltagId)
                    .HasColumnType("int(11)")
                    .HasColumnName("SpieltagID");

                entity.HasOne(d => d.SpielerId1Navigation)
                    .WithMany(p => p.TblSpiel6TageRennenSpielerId1Navigations)
                    .HasForeignKey(d => d.SpielerId1)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblSpiel6TageRennen_tblMitglieder");

                entity.HasOne(d => d.SpielerId2Navigation)
                    .WithMany(p => p.TblSpiel6TageRennenSpielerId2Navigations)
                    .HasForeignKey(d => d.SpielerId2)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblSpiel6TageRennen_tblMitglieder1");

                entity.HasOne(d => d.Spieltag)
                    .WithMany(p => p.TblSpiel6TageRennens)
                    .HasForeignKey(d => d.SpieltagId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblSpiel6TageRennen_tblSpieltag");
            });

            modelBuilder.Entity<TblSpielBlitztunier>(entity =>
            {
                entity.ToTable("tblSpielBlitztunier");

                entity.HasIndex(e => e.SpielerId1, "FK_tblSpielBlitztunier_tblMitglieder");

                entity.HasIndex(e => e.SpielerId2, "FK_tblSpielBlitztunier_tblMitglieder1");

                entity.HasIndex(e => e.SpieltagId, "FK_tblSpielBlitztunier_tblSpieltag");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.HinRückrunde).HasColumnType("int(11)");

                entity.Property(e => e.PunkteSpieler1).HasColumnType("int(11)");

                entity.Property(e => e.PunkteSpieler2).HasColumnType("int(11)");

                entity.Property(e => e.SpielerId1)
                    .HasColumnType("int(11)")
                    .HasColumnName("SpielerID1");

                entity.Property(e => e.SpielerId2)
                    .HasColumnType("int(11)")
                    .HasColumnName("SpielerID2");

                entity.Property(e => e.SpieltagId)
                    .HasColumnType("int(11)")
                    .HasColumnName("SpieltagID");

                entity.HasOne(d => d.SpielerId1Navigation)
                    .WithMany(p => p.TblSpielBlitztunierSpielerId1Navigations)
                    .HasForeignKey(d => d.SpielerId1)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblSpielBlitztunier_tblMitglieder");

                entity.HasOne(d => d.SpielerId2Navigation)
                    .WithMany(p => p.TblSpielBlitztunierSpielerId2Navigations)
                    .HasForeignKey(d => d.SpielerId2)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblSpielBlitztunier_tblMitglieder1");

                entity.HasOne(d => d.Spieltag)
                    .WithMany(p => p.TblSpielBlitztuniers)
                    .HasForeignKey(d => d.SpieltagId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblSpielBlitztunier_tblSpieltag");
            });

            modelBuilder.Entity<TblSpielKombimeisterschaft>(entity =>
            {
                entity.ToTable("tblSpielKombimeisterschaft");

                entity.HasIndex(e => e.SpielerId1, "FK_tblSpielKombimeisterschaft_tblMitglieder");

                entity.HasIndex(e => e.SpielerId2, "FK_tblSpielKombimeisterschaft_tblMitglieder1");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.HinRückrunde)
                    .HasColumnType("int(11)")
                    .HasComment("0 = Hinrunde; 1 = Rückrunde");

                entity.Property(e => e.Spieler1Punkte3bis8).HasColumnType("int(11)");

                entity.Property(e => e.Spieler1Punkte5Kugeln).HasColumnType("int(11)");

                entity.Property(e => e.Spieler2Punkte3bis8).HasColumnType("int(11)");

                entity.Property(e => e.Spieler2Punkte5Kugeln).HasColumnType("int(11)");

                entity.Property(e => e.SpielerId1)
                    .HasColumnType("int(11)")
                    .HasColumnName("SpielerID1");

                entity.Property(e => e.SpielerId2)
                    .HasColumnType("int(11)")
                    .HasColumnName("SpielerID2");

                entity.Property(e => e.SpieltagId)
                    .HasColumnType("int(11)")
                    .HasColumnName("SpieltagID");

                entity.HasOne(d => d.SpielerId1Navigation)
                    .WithMany(p => p.TblSpielKombimeisterschaftSpielerId1Navigations)
                    .HasForeignKey(d => d.SpielerId1)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblSpielKombimeisterschaft_tblMitglieder");

                entity.HasOne(d => d.SpielerId2Navigation)
                    .WithMany(p => p.TblSpielKombimeisterschaftSpielerId2Navigations)
                    .HasForeignKey(d => d.SpielerId2)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblSpielKombimeisterschaft_tblMitglieder1");
            });

            modelBuilder.Entity<TblSpielMeisterschaft>(entity =>
            {
                entity.ToTable("tblSpielMeisterschaft");

                entity.HasIndex(e => e.SpielerId1, "FK_tblSpielMeisterschaft_tblMitglieder");

                entity.HasIndex(e => e.SpielerId2, "FK_tblSpielMeisterschaft_tblMitglieder1");

                entity.HasIndex(e => e.SpieltagId, "FK_tblSpielMeisterschaft_tblSpieltag");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.HinRückrunde).HasColumnType("int(11)");

                entity.Property(e => e.HolzSpieler1).HasColumnType("int(11)");

                entity.Property(e => e.HolzSpieler2).HasColumnType("int(11)");

                entity.Property(e => e.SpielerId1)
                    .HasColumnType("int(11)")
                    .HasColumnName("SpielerID1");

                entity.Property(e => e.SpielerId2)
                    .HasColumnType("int(11)")
                    .HasColumnName("SpielerID2");

                entity.Property(e => e.SpieltagId)
                    .HasColumnType("int(11)")
                    .HasColumnName("SpieltagID");

                entity.HasOne(d => d.SpielerId1Navigation)
                    .WithMany(p => p.TblSpielMeisterschaftSpielerId1Navigations)
                    .HasForeignKey(d => d.SpielerId1)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblSpielMeisterschaft_tblMitglieder");

                entity.HasOne(d => d.SpielerId2Navigation)
                    .WithMany(p => p.TblSpielMeisterschaftSpielerId2Navigations)
                    .HasForeignKey(d => d.SpielerId2)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblSpielMeisterschaft_tblMitglieder1");

                entity.HasOne(d => d.Spieltag)
                    .WithMany(p => p.TblSpielMeisterschafts)
                    .HasForeignKey(d => d.SpieltagId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblSpielMeisterschaft_tblSpieltag");
            });

            modelBuilder.Entity<TblSpielPokal>(entity =>
            {
                entity.ToTable("tblSpielPokal");

                entity.HasIndex(e => e.SpieltagId, "FK_tblSpielPokal__tblSpieltag");

                entity.HasIndex(e => e.SpielerId, "FK_tblSpielPokal_tblMitglieder");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.Platzierung).HasColumnType("int(11)");

                entity.Property(e => e.SpielerId)
                    .HasColumnType("int(11)")
                    .HasColumnName("SpielerID");

                entity.Property(e => e.SpieltagId)
                    .HasColumnType("int(11)")
                    .HasColumnName("SpieltagID");

                entity.HasOne(d => d.Spieler)
                    .WithMany(p => p.TblSpielPokals)
                    .HasForeignKey(d => d.SpielerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblSpielPokal_tblMitglieder");

                entity.HasOne(d => d.Spieltag)
                    .WithMany(p => p.TblSpielPokals)
                    .HasForeignKey(d => d.SpieltagId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblSpielPokal__tblSpieltag");
            });

            modelBuilder.Entity<TblSpielSargKegeln>(entity =>
            {
                entity.ToTable("tblSpielSargKegeln");

                entity.HasIndex(e => e.SpielerId, "FK_tblSargKegeln_tblMitglieder");

                entity.HasIndex(e => e.SpieltagId, "FK_tblSargKegeln_tblSpieltag");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.Platzierung).HasColumnType("int(11)");

                entity.Property(e => e.SpielerId)
                    .HasColumnType("int(11)")
                    .HasColumnName("SpielerID");

                entity.Property(e => e.SpieltagId)
                    .HasColumnType("int(11)")
                    .HasColumnName("SpieltagID");

                entity.HasOne(d => d.Spieler)
                    .WithMany(p => p.TblSpielSargKegelns)
                    .HasForeignKey(d => d.SpielerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblSargKegeln_tblMitglieder");

                entity.HasOne(d => d.Spieltag)
                    .WithMany(p => p.TblSpielSargKegelns)
                    .HasForeignKey(d => d.SpieltagId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblSargKegeln_tblSpieltag");
            });

            modelBuilder.Entity<TblSpieltag>(entity =>
            {
                entity.ToTable("tblSpieltag");

                entity.HasIndex(e => e.MeisterschaftsId, "FK_tblSpieltag_tblMeisterschaften");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.InBearbeitung).HasColumnType("bit(1)");

                entity.Property(e => e.MeisterschaftsId)
                    .HasColumnType("int(11)")
                    .HasColumnName("MeisterschaftsID");

                entity.Property(e => e.Spieltag).HasColumnType("datetime");

                entity.HasOne(d => d.Meisterschafts)
                    .WithMany(p => p.TblSpieltags)
                    .HasForeignKey(d => d.MeisterschaftsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblSpieltag_tblMeisterschaften");
            });

            modelBuilder.Entity<TblTeilnehmer>(entity =>
            {
                entity.ToTable("tblTeilnehmer");

                entity.HasIndex(e => e.MeisterschaftsId, "FK_tblTeilnehmer_tblMeisterschaften");

                entity.HasIndex(e => e.SpielerId, "FK_tblTeilnehmer_tblMitglieder");

                entity.Property(e => e.Id)
                    .HasColumnType("int(11)")
                    .HasColumnName("ID");

                entity.Property(e => e.MeisterschaftsId)
                    .HasColumnType("int(11)")
                    .HasColumnName("MeisterschaftsID");

                entity.Property(e => e.SpielerId)
                    .HasColumnType("int(11)")
                    .HasColumnName("SpielerID");

                entity.HasOne(d => d.Meisterschafts)
                    .WithMany(p => p.TblTeilnehmers)
                    .HasForeignKey(d => d.MeisterschaftsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblTeilnehmer_tblMeisterschaften");

                entity.HasOne(d => d.Spieler)
                    .WithMany(p => p.TblTeilnehmers)
                    .HasForeignKey(d => d.SpielerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblTeilnehmer_tblMitglieder");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        /// <summary>
        /// OnModelCreatingPartial
        /// </summary>
        /// <param name="modelBuilder"></param>
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
