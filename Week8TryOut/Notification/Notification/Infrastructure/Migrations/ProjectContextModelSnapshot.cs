﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Notification.Infrastructure;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Notification.Infrastructure.Migrations
{
    [DbContext(typeof(ProjectContext))]
    partial class ProjectContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Notification.Domain.Entities.NotificationLogs", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<long>("created_at")
                        .HasColumnType("bigint");

                    b.Property<string>("email_destination")
                        .HasColumnType("text");

                    b.Property<int>("from")
                        .HasColumnType("integer");

                    b.Property<int>("notification_id")
                        .HasColumnType("integer");

                    b.Property<long>("read_at")
                        .HasColumnType("bigint");

                    b.Property<int>("target")
                        .HasColumnType("integer");

                    b.Property<string>("type")
                        .HasColumnType("text");

                    b.Property<long>("updatet_at")
                        .HasColumnType("bigint");

                    b.HasKey("id");

                    b.ToTable("notificationLogs");
                });

            modelBuilder.Entity("Notification.Domain.Entities.Notification_Model", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<long>("created_at")
                        .HasColumnType("bigint");

                    b.Property<string>("message")
                        .HasColumnType("text");

                    b.Property<string>("title")
                        .HasColumnType("text");

                    b.Property<long>("updatet_at")
                        .HasColumnType("bigint");

                    b.HasKey("id");

                    b.ToTable("notifications");
                });

            modelBuilder.Entity("Notification.Domain.Entities.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("address")
                        .HasColumnType("text");

                    b.Property<string>("email")
                        .HasColumnType("text");

                    b.Property<string>("name")
                        .HasColumnType("text");

                    b.Property<string>("password")
                        .HasColumnType("text");

                    b.Property<string>("username")
                        .HasColumnType("text");

                    b.HasKey("id");

                    b.ToTable("users");
                });
#pragma warning restore 612, 618
        }
    }
}
