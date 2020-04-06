﻿// <auto-generated />
using System;
using Eintech.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Eintech.Migrations
{
    [DbContext(typeof(EintechDbContext))]
    [Migration("20200406102737_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Eintech.DAL.Models.Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Groups");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "One"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Two"
                        });
                });

            modelBuilder.Entity("Eintech.DAL.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("datetime2");

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.ToTable("People");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DateAdded = new DateTime(2001, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GroupId = 1,
                            Name = "Doc"
                        },
                        new
                        {
                            Id = 2,
                            DateAdded = new DateTime(2002, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GroupId = 2,
                            Name = "Grumpy"
                        },
                        new
                        {
                            Id = 3,
                            DateAdded = new DateTime(2003, 3, 3, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GroupId = 1,
                            Name = "Happy"
                        },
                        new
                        {
                            Id = 4,
                            DateAdded = new DateTime(2004, 4, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GroupId = 2,
                            Name = "Sleepy"
                        },
                        new
                        {
                            Id = 5,
                            DateAdded = new DateTime(2005, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            GroupId = 1,
                            Name = "Bashful"
                        });
                });

            modelBuilder.Entity("Eintech.DAL.Models.Person", b =>
                {
                    b.HasOne("Eintech.DAL.Models.Group", "Group")
                        .WithMany("People")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
