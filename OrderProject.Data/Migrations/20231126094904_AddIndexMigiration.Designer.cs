﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using OrderProject.Data.DbContexs;

#nullable disable

namespace OrdersProject.Data.Migrations
{
    [DbContext(typeof(OrdersProjectDbContex))]
    [Migration("20231126094904_AddIndexMigiration")]
    partial class AddIndexMigiration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("OrdersProject.Domain.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ProductNumber")
                        .HasColumnType("integer");

                    b.Property<decimal>("ProductsPrice")
                        .HasColumnType("numeric");

                    b.Property<DateTime>("UpdateAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("UserOrderId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserOrderId");

                    b.HasIndex(new[] { "Id" }, "Index_Order")
                        .IsUnique();

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("OrdersProject.Domain.Entities.UserOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Adress")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("AllPrice")
                        .HasColumnType("numeric");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("EmailAdress")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdateAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Id" }, "Index_UserOrder")
                        .IsUnique();

                    b.ToTable("UserOrders");
                });

            modelBuilder.Entity("OrdersProject.Domain.Entities.Order", b =>
                {
                    b.HasOne("OrdersProject.Domain.Entities.UserOrder", "UserOrder")
                        .WithMany("Orders")
                        .HasForeignKey("UserOrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserOrder");
                });

            modelBuilder.Entity("OrdersProject.Domain.Entities.UserOrder", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
