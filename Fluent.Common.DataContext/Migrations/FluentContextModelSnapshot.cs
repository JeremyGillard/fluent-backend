﻿// <auto-generated />
using System;
using Fluent.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Fluent.Common.DataContext.Migrations
{
    [DbContext(typeof(FluentContext))]
    partial class FluentContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("FlashCardRevision", b =>
                {
                    b.Property<int>("FlashCardsId")
                        .HasColumnType("int");

                    b.Property<int>("RevisionsId")
                        .HasColumnType("int");

                    b.HasKey("FlashCardsId", "RevisionsId");

                    b.HasIndex("RevisionsId");

                    b.ToTable("FlashCardRevision");
                });

            modelBuilder.Entity("Fluent.Models.FlashCard", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Translation")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Word")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.ToTable("FlashCards");
                });

            modelBuilder.Entity("Fluent.Models.Revision", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Revisions");
                });

            modelBuilder.Entity("FlashCardRevision", b =>
                {
                    b.HasOne("Fluent.Models.FlashCard", null)
                        .WithMany()
                        .HasForeignKey("FlashCardsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Fluent.Models.Revision", null)
                        .WithMany()
                        .HasForeignKey("RevisionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
