﻿// <auto-generated />
using JokeApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JokeApi.Migrations
{
    [DbContext(typeof(JokeApiDbContext))]
    [Migration("20220605132323_SeededJokesCommentsAndUser")]
    partial class SeededJokesCommentsAndUser
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("JokeApi.Data.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Body")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("JokeId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("JokeId");

                    b.HasIndex("UserId");

                    b.ToTable("Comments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Body = "First Comment",
                            JokeId = 1,
                            UserId = 1
                        });
                });

            modelBuilder.Entity("JokeApi.Data.Joke", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Body")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Joke");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Body = "First Joke",
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            Body = "Second Joke",
                            UserId = 1
                        });
                });

            modelBuilder.Entity("JokeApi.Data.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            username = "edwin@bbd.co.za"
                        });
                });

            modelBuilder.Entity("JokeApi.Data.Comment", b =>
                {
                    b.HasOne("JokeApi.Data.Joke", "Joke")
                        .WithMany("Comments")
                        .HasForeignKey("JokeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("JokeApi.Data.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Joke");

                    b.Navigation("User");
                });

            modelBuilder.Entity("JokeApi.Data.Joke", b =>
                {
                    b.HasOne("JokeApi.Data.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("JokeApi.Data.Joke", b =>
                {
                    b.Navigation("Comments");
                });
#pragma warning restore 612, 618
        }
    }
}
