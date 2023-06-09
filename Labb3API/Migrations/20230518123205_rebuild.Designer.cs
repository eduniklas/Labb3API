﻿// <auto-generated />
using APILabb.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace APILabb.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230518123205_rebuild")]
    partial class rebuild
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("APILabb.Models.Interest", b =>
                {
                    b.Property<int>("InterestId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InterestId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("InterestId");

                    b.ToTable("Interests");
                });

            modelBuilder.Entity("APILabb.Models.InterestList", b =>
                {
                    b.Property<int>("InterestListId")
                        .HasColumnType("int");

                    b.Property<int>("FK_InterestId")
                        .HasColumnType("int");

                    b.Property<int>("FK_PersonId")
                        .HasColumnType("int");

                    b.Property<string>("PageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("InterestListId");

                    b.HasIndex("FK_InterestId");

                    b.HasIndex("FK_PersonId");

                    b.ToTable("InterestLists");
                });

            modelBuilder.Entity("APILabb.Models.Person", b =>
                {
                    b.Property<int>("PersonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PersonId"));

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("PersonId");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("InterestPerson", b =>
                {
                    b.Property<int>("InterestsInterestId")
                        .HasColumnType("int");

                    b.Property<int>("PersonsPersonId")
                        .HasColumnType("int");

                    b.HasKey("InterestsInterestId", "PersonsPersonId");

                    b.HasIndex("PersonsPersonId");

                    b.ToTable("InterestPerson");
                });

            modelBuilder.Entity("APILabb.Models.InterestList", b =>
                {
                    b.HasOne("APILabb.Models.Interest", "Interests")
                        .WithMany()
                        .HasForeignKey("FK_InterestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("APILabb.Models.Person", "Persons")
                        .WithMany()
                        .HasForeignKey("FK_PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Interests");

                    b.Navigation("Persons");
                });

            modelBuilder.Entity("InterestPerson", b =>
                {
                    b.HasOne("APILabb.Models.Interest", null)
                        .WithMany()
                        .HasForeignKey("InterestsInterestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("APILabb.Models.Person", null)
                        .WithMany()
                        .HasForeignKey("PersonsPersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
