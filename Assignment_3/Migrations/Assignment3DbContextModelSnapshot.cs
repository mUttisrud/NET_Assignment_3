﻿// <auto-generated />
using Assignment_3.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Assignment_3.Migrations
{
    [DbContext(typeof(Assignment3DbContext))]
    partial class Assignment3DbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Assignment_3.Data.Models.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Alias")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PictureUrl")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Character");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Gender = "Male",
                            Name = "Batman"
                        },
                        new
                        {
                            Id = 2,
                            Gender = "Male",
                            Name = "Robin"
                        },
                        new
                        {
                            Id = 3,
                            Gender = "Female",
                            Name = "Hermione Granger"
                        });
                });

            modelBuilder.Entity("Assignment_3.Data.Models.Franchise", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Franchise");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Batman"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Harry Potter"
                        });
                });

            modelBuilder.Entity("Assignment_3.Data.Models.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Director")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("FranchiseId")
                        .HasColumnType("int");

                    b.Property<string>("Genre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PictureUrl")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("ReleaseYear")
                        .HasMaxLength(4)
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("TrailerUrl")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("FranchiseId");

                    b.ToTable("Movie");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FranchiseId = 1,
                            Genre = "Superhero, Action",
                            ReleaseYear = 2005,
                            Title = "Batman Begins"
                        },
                        new
                        {
                            Id = 2,
                            FranchiseId = 1,
                            Genre = "Superhero, Action",
                            ReleaseYear = 2008,
                            Title = "The Dark Knight"
                        },
                        new
                        {
                            Id = 3,
                            FranchiseId = 1,
                            Genre = "Superhero, Action",
                            ReleaseYear = 2012,
                            Title = "The Dark Knight Rises"
                        },
                        new
                        {
                            Id = 4,
                            FranchiseId = 2,
                            Genre = "Fantasy",
                            ReleaseYear = 2001,
                            Title = "Harry Potter And The Philosophers Stone"
                        });
                });

            modelBuilder.Entity("CharacterMovie", b =>
                {
                    b.Property<int>("CharactersId")
                        .HasColumnType("int");

                    b.Property<int>("MoviesId")
                        .HasColumnType("int");

                    b.HasKey("CharactersId", "MoviesId");

                    b.HasIndex("MoviesId");

                    b.ToTable("CharacterMovie");

                    b.HasData(
                        new
                        {
                            CharactersId = 1,
                            MoviesId = 1
                        },
                        new
                        {
                            CharactersId = 2,
                            MoviesId = 1
                        },
                        new
                        {
                            CharactersId = 1,
                            MoviesId = 2
                        },
                        new
                        {
                            CharactersId = 2,
                            MoviesId = 2
                        },
                        new
                        {
                            CharactersId = 1,
                            MoviesId = 3
                        },
                        new
                        {
                            CharactersId = 2,
                            MoviesId = 3
                        },
                        new
                        {
                            CharactersId = 3,
                            MoviesId = 4
                        });
                });

            modelBuilder.Entity("Assignment_3.Data.Models.Movie", b =>
                {
                    b.HasOne("Assignment_3.Data.Models.Franchise", "Franchise")
                        .WithMany("Movies")
                        .HasForeignKey("FranchiseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Franchise");
                });

            modelBuilder.Entity("CharacterMovie", b =>
                {
                    b.HasOne("Assignment_3.Data.Models.Character", null)
                        .WithMany()
                        .HasForeignKey("CharactersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Assignment_3.Data.Models.Movie", null)
                        .WithMany()
                        .HasForeignKey("MoviesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Assignment_3.Data.Models.Franchise", b =>
                {
                    b.Navigation("Movies");
                });
#pragma warning restore 612, 618
        }
    }
}
