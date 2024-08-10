﻿// <auto-generated />
using System;
using ExpensesManager.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ExpensesManager.Infra.Migrations
{
    [DbContext(typeof(ExpensesManagerContext))]
    partial class ExpensesManagerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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
                            Id = new Guid("c4cad1f1-f678-4ee4-a034-e767a78331d2"),
                            CreatedAt = new DateTime(2024, 8, 7, 21, 39, 0, 524, DateTimeKind.Local).AddTicks(3040),
                            Name = "Inter Gold"
                        },
                        new
                        {
                            Id = new Guid("d6f19267-bef9-4f44-86cf-0937c65871b6"),
                            CreatedAt = new DateTime(2024, 8, 7, 21, 39, 0, 524, DateTimeKind.Local).AddTicks(3080),
                            Name = "Inter Black"
                        },
                        new
                        {
                            Id = new Guid("473b5651-ae1f-4017-bced-bd342a8dcc09"),
                            CreatedAt = new DateTime(2024, 8, 7, 21, 39, 0, 524, DateTimeKind.Local).AddTicks(3090),
                            Name = "Amex TGC"
                        },
                        new
                        {
                            Id = new Guid("a62bc917-5a79-4d41-b01c-0cc4bd97b5c9"),
                            CreatedAt = new DateTime(2024, 8, 7, 21, 39, 0, 524, DateTimeKind.Local).AddTicks(3090),
                            Name = "XP Visa Infinite"
                        },
                        new
                        {
                            Id = new Guid("fdb8a5cc-2670-4c77-92f4-433c9c6080e3"),
                            CreatedAt = new DateTime(2024, 8, 7, 21, 39, 0, 524, DateTimeKind.Local).AddTicks(3100),
                            Name = "BB Elo Mais"
                        },
                        new
                        {
                            Id = new Guid("173b36c3-f538-445e-938e-dafe8a812d33"),
                            CreatedAt = new DateTime(2024, 8, 7, 21, 39, 0, 524, DateTimeKind.Local).AddTicks(3110),
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

                    b.Property<int>("CurrentInstallment")
                        .HasColumnType("integer")
                        .HasColumnName("current_installment");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<string>("InstallmentInfo")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("installment_info");

                    b.Property<decimal>("InstallmentPrice")
                        .HasColumnType("numeric")
                        .HasColumnName("installment_price");

                    b.Property<Guid>("InvoiceMonthId")
                        .HasMaxLength(10)
                        .HasColumnType("uuid")
                        .HasColumnName("invoice_month_id");

                    b.Property<bool>("IsInstallment")
                        .HasColumnType("boolean")
                        .HasColumnName("is_installment");

                    b.Property<Guid>("PersonId")
                        .HasColumnType("uuid")
                        .HasColumnName("person_id");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric")
                        .HasColumnName("price");

                    b.Property<DateTime>("PurchaseDate")
                        .HasColumnType("timestamp")
                        .HasColumnName("purchase_date");

                    b.Property<int>("TotalInstallments")
                        .HasColumnType("integer")
                        .HasColumnName("total_installments");

                    b.HasKey("Id");

                    b.HasIndex("InvoiceMonthId");

                    b.HasIndex("PersonId");

                    b.ToTable("expenses", (string)null);
                });

            modelBuilder.Entity("ExpensesManager.Domain.Entities.InvoiceMonth", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<int>("Code")
                        .HasColumnType("integer")
                        .HasColumnName("code");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id");

                    b.ToTable("invoice_months", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("f4371cca-b3e9-49d6-aacf-c1b99bb63caa"),
                            Code = 1,
                            CreatedAt = new DateTime(2024, 8, 7, 21, 39, 0, 524, DateTimeKind.Local).AddTicks(3760),
                            Name = "Janeiro"
                        },
                        new
                        {
                            Id = new Guid("cf143b5b-d705-4e46-b88c-8c5aa59fc9bc"),
                            Code = 2,
                            CreatedAt = new DateTime(2024, 8, 7, 21, 39, 0, 524, DateTimeKind.Local).AddTicks(3770),
                            Name = "Fevereiro"
                        },
                        new
                        {
                            Id = new Guid("58a0cfe2-0a5e-42cd-a2a7-1515831b068b"),
                            Code = 3,
                            CreatedAt = new DateTime(2024, 8, 7, 21, 39, 0, 524, DateTimeKind.Local).AddTicks(3770),
                            Name = "Marco"
                        },
                        new
                        {
                            Id = new Guid("498732b2-31ae-410b-9ce0-c436d31be794"),
                            Code = 4,
                            CreatedAt = new DateTime(2024, 8, 7, 21, 39, 0, 524, DateTimeKind.Local).AddTicks(3780),
                            Name = "Abril"
                        },
                        new
                        {
                            Id = new Guid("0325e053-cbcc-492b-b268-f7bcbd0fbacc"),
                            Code = 5,
                            CreatedAt = new DateTime(2024, 8, 7, 21, 39, 0, 524, DateTimeKind.Local).AddTicks(3790),
                            Name = "Maio"
                        },
                        new
                        {
                            Id = new Guid("4605c82b-4ef1-40a1-baaa-4646c4bb4dff"),
                            Code = 6,
                            CreatedAt = new DateTime(2024, 8, 7, 21, 39, 0, 524, DateTimeKind.Local).AddTicks(3800),
                            Name = "Junho"
                        },
                        new
                        {
                            Id = new Guid("42caa6f7-8fee-479a-ad6b-89fc85f89e6b"),
                            Code = 7,
                            CreatedAt = new DateTime(2024, 8, 7, 21, 39, 0, 524, DateTimeKind.Local).AddTicks(3810),
                            Name = "Julho"
                        },
                        new
                        {
                            Id = new Guid("eec7fa31-e1d7-49a8-a179-23900b7ff6af"),
                            Code = 8,
                            CreatedAt = new DateTime(2024, 8, 7, 21, 39, 0, 524, DateTimeKind.Local).AddTicks(3810),
                            Name = "Agosto"
                        },
                        new
                        {
                            Id = new Guid("253c382a-d5d4-4a0f-97d1-7bc582795caf"),
                            Code = 9,
                            CreatedAt = new DateTime(2024, 8, 7, 21, 39, 0, 524, DateTimeKind.Local).AddTicks(3820),
                            Name = "Setembro"
                        },
                        new
                        {
                            Id = new Guid("3176f263-02e6-40ae-a0d8-8bb770c5d581"),
                            Code = 10,
                            CreatedAt = new DateTime(2024, 8, 7, 21, 39, 0, 524, DateTimeKind.Local).AddTicks(3830),
                            Name = "Outubro"
                        },
                        new
                        {
                            Id = new Guid("f0509c30-2311-4209-a57f-b512b3b51d93"),
                            Code = 11,
                            CreatedAt = new DateTime(2024, 8, 7, 21, 39, 0, 524, DateTimeKind.Local).AddTicks(3840),
                            Name = "Novembro"
                        },
                        new
                        {
                            Id = new Guid("ac9fa14b-38c4-4c4c-a614-162093942e36"),
                            Code = 12,
                            CreatedAt = new DateTime(2024, 8, 7, 21, 39, 0, 524, DateTimeKind.Local).AddTicks(3850),
                            Name = "Dezembro"
                        });
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
                    b.HasOne("ExpensesManager.Domain.Entities.InvoiceMonth", "InvoiceMonth")
                        .WithMany("Expenses")
                        .HasForeignKey("InvoiceMonthId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("invoice_month_id");

                    b.HasOne("ExpensesManager.Domain.Entities.Person", "Person")
                        .WithMany("Expenses")
                        .HasForeignKey("PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("person_id");

                    b.Navigation("InvoiceMonth");

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

            modelBuilder.Entity("ExpensesManager.Domain.Entities.InvoiceMonth", b =>
                {
                    b.Navigation("Expenses");
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
