﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PaymentServices.Infrastructure;

namespace PaymentServices.Infrastructure.Migrations
{
    [DbContext(typeof(PaymentContext))]
    partial class PaymentContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("PaymentServices.Domain.Entities.Order", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<long>("created_at")
                        .HasColumnType("bigint");

                    b.Property<long>("updated_at")
                        .HasColumnType("bigint");

                    b.Property<int>("user_id")
                        .HasColumnType("integer");

                    b.HasKey("id");

                    b.ToTable("orders");
                });

            modelBuilder.Entity("PaymentServices.Domain.Entities.Order_Details", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("count")
                        .HasColumnType("integer");

                    b.Property<long>("created_at")
                        .HasColumnType("bigint");

                    b.Property<int>("order_id")
                        .HasColumnType("integer");

                    b.Property<int>("price")
                        .HasColumnType("integer");

                    b.Property<int>("product_id")
                        .HasColumnType("integer");

                    b.Property<long>("updated_at")
                        .HasColumnType("bigint");

                    b.HasKey("id");

                    b.ToTable("order_Details");
                });

            modelBuilder.Entity("PaymentServices.Domain.Entities.Payment", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<long>("created_at")
                        .HasColumnType("bigint");

                    b.Property<string>("gross_amount")
                        .HasColumnType("text");

                    b.Property<int>("order_id")
                        .HasColumnType("integer");

                    b.Property<string>("payment_type")
                        .HasColumnType("text");

                    b.Property<string>("transaction_id")
                        .HasColumnType("text");

                    b.Property<string>("transaction_status")
                        .HasColumnType("text");

                    b.Property<string>("transaction_time")
                        .HasColumnType("text");

                    b.Property<long>("updated_at")
                        .HasColumnType("bigint");

                    b.HasKey("id");

                    b.ToTable("payments");
                });

            modelBuilder.Entity("PaymentServices.Domain.Entities.Product", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<long>("created_at")
                        .HasColumnType("bigint");

                    b.Property<string>("name")
                        .HasColumnType("text");

                    b.Property<string>("price")
                        .HasColumnType("text");

                    b.Property<long>("updated_at")
                        .HasColumnType("bigint");

                    b.HasKey("id");

                    b.ToTable("products");
                });
#pragma warning restore 612, 618
        }
    }
}
