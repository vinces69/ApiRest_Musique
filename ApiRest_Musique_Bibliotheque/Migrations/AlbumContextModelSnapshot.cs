﻿// <auto-generated />
using ApiRest_Musique_Bibliotheque.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApiRest_Musique_Bibliotheque.Migrations
{
    [DbContext(typeof(AlbumContext))]
    partial class AlbumContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ApiRest_Musique_Bibliotheque.Models.Album", b =>
                {
                    b.Property<int>("idalbum")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("artistealbum")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("compositeuralbum")
                        .HasColumnType("longtext");

                    b.Property<string>("decsalbum")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<bool>("groupealbum")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("nomalbum")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("pochettealbum")
                        .HasColumnType("longtext");

                    b.HasKey("idalbum");

                    b.ToTable("album");
                });
#pragma warning restore 612, 618
        }
    }
}