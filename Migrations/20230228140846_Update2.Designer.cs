﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace WeTravel.Migrations
{
    [DbContext(typeof(WeTravelContext))]
    [Migration("20230228140846_Update2")]
    partial class Update2
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.2");

            modelBuilder.Entity("Amitie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Compte1Id")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Compte2Id")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("Compte1Id");

                    b.HasIndex("Compte2Id");

                    b.ToTable("Amities");
                });

            modelBuilder.Entity("Appreciation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Commentaire")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("CompteId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

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

            modelBuilder.Entity("Favori", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CompteId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("LieuId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CompteId");

                    b.HasIndex("LieuId");

                    b.ToTable("Favoris");
                });

            modelBuilder.Entity("Lieu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("CompteId")
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

            modelBuilder.Entity("Photo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CompteId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Lien")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("LieuId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CompteId");

                    b.HasIndex("LieuId");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("Ville", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("PaysId")
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

                    b.Property<int>("CompteId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<int>("LieuId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CompteId");

                    b.HasIndex("LieuId");

                    b.ToTable("Visites");
                });

            modelBuilder.Entity("Amitie", b =>
                {
                    b.HasOne("Compte", "Compte1")
                        .WithMany()
                        .HasForeignKey("Compte1Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Compte", "Compte2")
                        .WithMany()
                        .HasForeignKey("Compte2Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Compte1");

                    b.Navigation("Compte2");
                });

            modelBuilder.Entity("Appreciation", b =>
                {
                    b.HasOne("Compte", "Compte")
                        .WithMany()
                        .HasForeignKey("CompteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lieu", "Lieu")
                        .WithMany()
                        .HasForeignKey("LieuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Compte");

                    b.Navigation("Lieu");
                });

            modelBuilder.Entity("Culture", b =>
                {
                    b.HasOne("Lieu", "Lieu")
                        .WithMany()
                        .HasForeignKey("LieuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lieu");
                });

            modelBuilder.Entity("Favori", b =>
                {
                    b.HasOne("Compte", "Compte")
                        .WithMany()
                        .HasForeignKey("CompteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lieu", "Lieu")
                        .WithMany()
                        .HasForeignKey("LieuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Compte");

                    b.Navigation("Lieu");
                });

            modelBuilder.Entity("Lieu", b =>
                {
                    b.HasOne("Compte", null)
                        .WithMany("Favoris")
                        .HasForeignKey("CompteId");

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
                        .WithMany()
                        .HasForeignKey("ContinentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Continent");
                });

            modelBuilder.Entity("Photo", b =>
                {
                    b.HasOne("Compte", "Compte")
                        .WithMany()
                        .HasForeignKey("CompteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lieu", "Lieu")
                        .WithMany()
                        .HasForeignKey("LieuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Compte");

                    b.Navigation("Lieu");
                });

            modelBuilder.Entity("Ville", b =>
                {
                    b.HasOne("Pays", "Pays")
                        .WithMany()
                        .HasForeignKey("PaysId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pays");
                });

            modelBuilder.Entity("Visite", b =>
                {
                    b.HasOne("Compte", "Compte")
                        .WithMany()
                        .HasForeignKey("CompteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Lieu", "Lieu")
                        .WithMany()
                        .HasForeignKey("LieuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Compte");

                    b.Navigation("Lieu");
                });

            modelBuilder.Entity("Compte", b =>
                {
                    b.Navigation("Favoris");
                });

            modelBuilder.Entity("Ville", b =>
                {
                    b.Navigation("Lieux");
                });
#pragma warning restore 612, 618
        }
    }
}
