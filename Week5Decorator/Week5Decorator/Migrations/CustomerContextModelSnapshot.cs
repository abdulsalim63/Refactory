﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Week5Decorator.Models;

namespace Week5Decorator.Migrations
{
    [DbContext(typeof(CustomerContext))]
    partial class CustomerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Week5Decorator.Models.Customer", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("birthdate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long>("created_at")
                        .HasColumnType("bigint");

                    b.Property<string>("email")
                        .HasColumnType("text");

                    b.Property<string>("full_name")
                        .HasColumnType("text");

                    b.Property<string>("gender")
                        .HasColumnType("text");

                    b.Property<string>("password")
                        .HasColumnType("text");

                    b.Property<string>("phone_number")
                        .HasColumnType("text");

                    b.Property<long>("updated_at")
                        .HasColumnType("bigint");

                    b.Property<string>("username")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("customers");
                });

            modelBuilder.Entity("Week5Decorator.Models.CustomerCard", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<long>("created_at")
                        .HasColumnType("bigint");

                    b.Property<string>("credit_card_number")
                        .HasColumnType("text");

                    b.Property<int>("customer_id")
                        .HasColumnType("integer");

                    b.Property<string>("exp_month")
                        .HasColumnType("text");

                    b.Property<string>("exp_year")
                        .HasColumnType("text");

                    b.Property<string>("name_on_card")
                        .HasColumnType("text");

                    b.Property<int>("postal_code")
                        .HasColumnType("integer");

                    b.Property<long>("updated_at")
                        .HasColumnType("bigint");

                    b.HasKey("id");

                    b.HasIndex("customer_id")
                        .IsUnique();

                    b.ToTable("customerCards");
                });

            modelBuilder.Entity("Week5Decorator.Models.CustomerCard", b =>
                {
                    b.HasOne("Week5Decorator.Models.Customer", "Customer")
                        .WithOne("CustomerCard")
                        .HasForeignKey("Week5Decorator.Models.CustomerCard", "customer_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
