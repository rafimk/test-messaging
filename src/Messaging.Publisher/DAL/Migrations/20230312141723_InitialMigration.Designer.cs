﻿// <auto-generated />
using System;
using Messaging.Publisher.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Messaging.Publisher.DAL.Migrations
{
    [DbContext(typeof(CustomersDbContext))]
    [Migration("20230312141723_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Messaging.Publisher.Entities.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Messaging.Shared.Transactions.Inbox.InboxMessage", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("ProcessedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("ReceivedAt")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("Inbox");
                });

            modelBuilder.Entity("Messaging.Shared.Transactions.Outbox.OutboxMessage", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("Context")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Data")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("ReceivedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("SentAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Outbox");
                });
#pragma warning restore 612, 618
        }
    }
}