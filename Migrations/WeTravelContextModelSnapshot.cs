﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace WeTravel.Migrations
{
    [DbContext(typeof(WeTravelContext))]
    partial class WeTravelContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.2");

            modelBuilder.Entity("Appreciation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Commentaire")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("CompteId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("LieuId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CompteId");

                    b.HasIndex("LieuId");

                    b.ToTable("Appreciations");
                });

            modelBuilder.Entity("Compte", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Mail")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("MotDePasse")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Comptes");
                });

            modelBuilder.Entity("Continent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Continents");
                });

            modelBuilder.Entity("Culture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("LieuId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("LieuId");

                    b.ToTable("Cultures");
                });

            modelBuilder.Entity("Lieu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CompteId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CompteId1")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("VilleId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CompteId");

                    b.HasIndex("CompteId1");

                    b.HasIndex("VilleId");

                    b.ToTable("Lieux");
                });

            modelBuilder.Entity("Pays", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ContinentId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ContinentId");

                    b.ToTable("Pays");
                });

            modelBuilder.Entity("Ville", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("PaysId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PaysId");

                    b.ToTable("Villes");
                });

            modelBuilder.Entity("Visite", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Compte")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<int>("LieuId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("LieuId");

                    b.ToTable("Visites");
                });

            modelBuilder.Entity("Appreciation", b =>
                {
                    b.HasOne("Compte", null)
                        .WithMany("Appreciations")
                        .HasForeignKey("CompteId");

                    b.HasOne("Lieu", "Lieu")
                        .WithMany("Appreciations")
                        .HasForeignKey("LieuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lieu");
                });

            modelBuilder.Entity("Culture", b =>
                {
                    b.HasOne("Lieu", "Lieu")
                        .WithMany("Cultures")
                        .HasForeignKey("LieuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lieu");
                });

            modelBuilder.Entity("Lieu", b =>
                {
                    b.HasOne("Compte", null)
                        .WithMany("Favoris")
                        .HasForeignKey("CompteId");

                    b.HasOne("Compte", null)
                        .WithMany("Visites")
                        .HasForeignKey("CompteId1");

                    b.HasOne("Ville", "Ville")
                        .WithMany("Lieux")
                        .HasForeignKey("VilleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ville");
                });

            modelBuilder.Entity("Pays", b =>
                {
                    b.HasOne("Continent", "Continent")
                        .WithMany("Pays")
                        .HasForeignKey("ContinentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Continent");
                });

            modelBuilder.Entity("Ville", b =>
                {
                    b.HasOne("Pays", null)
                        .WithMany("Villes")
                        .HasForeignKey("PaysId");
                });

            modelBuilder.Entity("Visite", b =>
                {
                    b.HasOne("Lieu", "Lieu")
                        .WithMany()
                        .HasForeignKey("LieuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lieu");
                });

            modelBuilder.Entity("Compte", b =>
                {
                    b.Navigation("Appreciations");

                    b.Navigation("Favoris");

                    b.Navigation("Visites");
                });

            modelBuilder.Entity("Continent", b =>
                {
                    b.Navigation("Pays");
                });

            modelBuilder.Entity("Lieu", b =>
                {
                    b.Navigation("Appreciations");

                    b.Navigation("Cultures");
                });

            modelBuilder.Entity("Pays", b =>
                {
                    b.Navigation("Villes");
                });

            modelBuilder.Entity("Ville", b =>
                {
                    b.Navigation("Lieux");
                });
#pragma warning restore 612, 618
        }
    }
}