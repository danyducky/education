﻿// <auto-generated />
using System;
using Auth.DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Auth.DataLayer.Migrations
{
    [DbContext(typeof(AuthContext))]
    [Migration("20211010083423_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Auth.DataLayer.Entities.Credential", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("userId");

                    b.Property<Guid>("PersonId")
                        .HasColumnType("uuid")
                        .HasColumnName("personId");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid")
                        .HasColumnName("roleId");

                    b.HasKey("UserId", "PersonId", "RoleId");

                    b.ToTable("credentials");
                });

            modelBuilder.Entity("Auth.DataLayer.Entities.Person", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("userId");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("birthDate");

                    b.Property<string>("Firstname")
                        .HasColumnType("text")
                        .HasColumnName("firstname");

                    b.Property<string>("Patronymic")
                        .HasColumnType("text")
                        .HasColumnName("patronymic");

                    b.Property<string>("Surname")
                        .HasColumnType("text")
                        .HasColumnName("surname");

                    b.HasKey("UserId");

                    b.ToTable("persons");
                });

            modelBuilder.Entity("Auth.DataLayer.Entities.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Caption")
                        .HasColumnType("text")
                        .HasColumnName("caption");

                    b.Property<int>("Power")
                        .HasColumnType("integer")
                        .HasColumnName("power");

                    b.HasKey("Id");

                    b.ToTable("roles");
                });

            modelBuilder.Entity("Auth.DataLayer.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Email")
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("Password")
                        .HasColumnType("text")
                        .HasColumnName("password");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("registrationDate");

                    b.HasKey("Id");

                    b.ToTable("users");
                });

            modelBuilder.Entity("Auth.DataLayer.Entities.Person", b =>
                {
                    b.HasOne("Auth.DataLayer.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
