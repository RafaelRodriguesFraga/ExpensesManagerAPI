﻿// <auto-generated />
using System;
using ExpensesManager.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ExpensesManager.Infra.Migrations
{
    [DbContext(typeof(ExpensesManagerContext))]
    [Migration("20240706024116_Add_Seed")]
    partial class Add_Seed
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.17")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ExpensesManager.Domain.Entities.CreditCard", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("credit_card", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("ae8b9d29-3bfb-45ea-9c5b-c9c32ed24dc3"),
                            CreatedAt = new DateTime(2024, 7, 5, 23, 41, 16, 97, DateTimeKind.Local).AddTicks(2470),
                            Name = "Inter Gold"
                        },
                        new
                        {
                            Id = new Guid("85e5d4a8-c4b4-4356-9d27-d07c0c6a78a2"),
                            CreatedAt = new DateTime(2024, 7, 5, 23, 41, 16, 97, DateTimeKind.Local).AddTicks(2520),
                            Name = "Inter Black"
                        },
                        new
                        {
                            Id = new Guid("07e0314b-a148-414a-8d58-89e4c8feb0db"),
                            CreatedAt = new DateTime(2024, 7, 5, 23, 41, 16, 97, DateTimeKind.Local).AddTicks(2530),
                            Name = "Amex TGC"
                        },
                        new
                        {
                            Id = new Guid("8d43d296-1896-44f4-8a32-998374fb7a63"),
                            CreatedAt = new DateTime(2024, 7, 5, 23, 41, 16, 97, DateTimeKind.Local).AddTicks(2530),
                            Name = "XP Visa Infinite"
                        },
                        new
                        {
                            Id = new Guid("39541f54-fd2e-4670-8bb4-daa0295e19cc"),
                            CreatedAt = new DateTime(2024, 7, 5, 23, 41, 16, 97, DateTimeKind.Local).AddTicks(2540),
                            Name = "BB Elo Mais"
                        },
                        new
                        {
                            Id = new Guid("f4387472-57eb-4188-9d0d-76198051d94e"),
                            CreatedAt = new DateTime(2024, 7, 5, 23, 41, 16, 97, DateTimeKind.Local).AddTicks(2550),
                            Name = "C6 Bank Standard"
                        });
                });

            modelBuilder.Entity("ExpensesManager.Domain.Entities.Expense", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("CreditCardName")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("credit_card_name");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("InvoiceMonth")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)")
                        .HasColumnName("invoice_month");

                    b.Property<bool>("IsInstallment")
                        .HasColumnType("boolean")
                        .HasColumnName("is_installment");

                    b.Property<bool>("Paid")
                        .HasColumnType("boolean")
                        .HasColumnName("paid");

                    b.Property<Guid>("PersonId")
                        .HasColumnType("uuid")
                        .HasColumnName("person_id");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric")
                        .HasColumnName("price");

                    b.Property<DateTime>("PurchaseDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("purchase_date");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("expenses", (string)null);
                });

            modelBuilder.Entity("ExpensesManager.Domain.Entities.Person", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("name");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("people", (string)null);
                });

            modelBuilder.Entity("ExpensesManager.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)")
                        .HasColumnName("email");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("password");

                    b.HasKey("Id")
                        .HasName("id");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("ExpensesManager.Domain.Entities.Expense", b =>
                {
                    b.HasOne("ExpensesManager.Domain.Entities.Person", "Person")
                        .WithMany("Expenses")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("person_id");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("ExpensesManager.Domain.Entities.Person", b =>
                {
                    b.HasOne("ExpensesManager.Domain.Entities.User", "User")
                        .WithMany("People")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("user_id");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ExpensesManager.Domain.Entities.Person", b =>
                {
                    b.Navigation("Expenses");
                });

            modelBuilder.Entity("ExpensesManager.Domain.Entities.User", b =>
                {
                    b.Navigation("People");
                });
#pragma warning restore 612, 618
        }
    }
}
