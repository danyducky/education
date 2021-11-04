﻿// <auto-generated />
using System;
using Auth.DataLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Auth.DataLayer.Migrations
{
    [DbContext(typeof(AuthContext))]
    partial class AuthContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
                        .HasColumnName("user_id");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid")
                        .HasColumnName("role_id");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("credentials");
                });

            modelBuilder.Entity("Auth.DataLayer.Entities.Module", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("Caption")
                        .HasColumnType("text")
                        .HasColumnName("caption");

                    b.Property<string>("Route")
                        .HasColumnType("text")
                        .HasColumnName("route");

                    b.Property<string>("ShortCaption")
                        .HasColumnType("text")
                        .HasColumnName("short_caption");

                    b.HasKey("Id");

                    b.ToTable("modules");
                });

            modelBuilder.Entity("Auth.DataLayer.Entities.ModuleBindings", b =>
                {
                    b.Property<Guid>("ModuleId")
                        .HasColumnType("uuid")
                        .HasColumnName("module_id");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uuid")
                        .HasColumnName("role_id");

                    b.HasKey("ModuleId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("module_bindings");
                });

            modelBuilder.Entity("Auth.DataLayer.Entities.Person", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("birth_date");

                    b.Property<string>("Firstname")
                        .HasColumnType("text")
                        .HasColumnName("firstname");

                    b.Property<string>("Patronymic")
                        .HasColumnType("text")
                        .HasColumnName("patronymic");

                    b.Property<string>("Surname")
                        .HasColumnType("text")
                        .HasColumnName("surname");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

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
                        .HasColumnName("registration_date");

                    b.HasKey("Id");

                    b.ToTable("users");
                });

            modelBuilder.Entity("Auth.DataLayer.Entities.Credential", b =>
                {
                    b.HasOne("Auth.DataLayer.Entities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Auth.DataLayer.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Auth.DataLayer.Entities.ModuleBindings", b =>
                {
                    b.HasOne("Auth.DataLayer.Entities.Module", "Module")
                        .WithMany()
                        .HasForeignKey("ModuleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Auth.DataLayer.Entities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Module");

                    b.Navigation("Role");
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

            modelBuilder.Entity("Auth.DataLayer.Entities.User", b =>
                {
                    b.OwnsMany("Auth.DataLayer.Entities.RefreshToken", "RefreshTokens", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .ValueGeneratedOnAdd()
                                .HasColumnType("uuid")
                                .HasColumnName("id");

                            b1.Property<DateTime>("CreatedAt")
                                .HasColumnType("timestamp without time zone")
                                .HasColumnName("created_at");

                            b1.Property<string>("CreatedByIp")
                                .HasColumnType("text")
                                .HasColumnName("created_by_ip");

                            b1.Property<DateTime>("ExpiresIn")
                                .HasColumnType("timestamp without time zone")
                                .HasColumnName("expires_in");

                            b1.Property<string>("Token")
                                .HasColumnType("text")
                                .HasColumnName("token");

                            b1.Property<Guid>("UserId")
                                .HasColumnType("uuid");

                            b1.HasKey("Id");

                            b1.HasIndex("UserId");

                            b1.ToTable("refresh_tokens");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.Navigation("RefreshTokens");
                });
#pragma warning restore 612, 618
        }
    }
}
