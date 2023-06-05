﻿// <auto-generated />
using System;
using Bookly.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Bookly.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(AplikacioniDbContext))]
    [Migration("20230604224303_status-rezervacije")]
    partial class statusrezervacije
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Bookly.Domain.Entiteti.Apartman", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Cena")
                        .HasColumnType("float");

                    b.Property<string>("Drzava")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mesto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Ocena")
                        .HasColumnType("float");

                    b.Property<string>("Opis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Apartmani");
                });

            modelBuilder.Entity("Bookly.Domain.Entiteti.Korisnik", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Adresa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DatumRodjenja")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Kornisici");
                });

            modelBuilder.Entity("Bookly.Domain.Entiteti.Rezervacija", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ApartmanID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DatumDolaska")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DatumOdlaska")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("KorisnikID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ApartmanID");

                    b.HasIndex("KorisnikID");

                    b.ToTable("Rezervacije");
                });

            modelBuilder.Entity("Bookly.Domain.Entiteti.Rezervacija", b =>
                {
                    b.HasOne("Bookly.Domain.Entiteti.Apartman", "Apartman")
                        .WithMany("Rezervacije")
                        .HasForeignKey("ApartmanID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bookly.Domain.Entiteti.Korisnik", "Korisnik")
                        .WithMany("Rezervacije")
                        .HasForeignKey("KorisnikID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Apartman");

                    b.Navigation("Korisnik");
                });

            modelBuilder.Entity("Bookly.Domain.Entiteti.Apartman", b =>
                {
                    b.Navigation("Rezervacije");
                });

            modelBuilder.Entity("Bookly.Domain.Entiteti.Korisnik", b =>
                {
                    b.Navigation("Rezervacije");
                });
#pragma warning restore 612, 618
        }
    }
}
