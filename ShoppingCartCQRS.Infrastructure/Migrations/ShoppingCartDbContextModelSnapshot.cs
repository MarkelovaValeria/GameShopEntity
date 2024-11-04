﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ShoppingCartCQRS.Infrastructure.Data;

#nullable disable

namespace ShoppingCartCQRS.Infrastructure.Migrations
{
    [DbContext(typeof(ShoppingCartDbContext))]
    partial class ShoppingCartDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ShoppingCart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double?>("TotalPrice")
                        .HasColumnType("float");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("ShoppingCarts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            UserName = "User1"
                        },
                        new
                        {
                            Id = 2,
                            UserName = "User2"
                        });
                });

            modelBuilder.Entity("ShoppingCartItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.Property<string>("GameTitle")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("ShoppingCartId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ShoppingCartId");

                    b.ToTable("ShoppingCartItems");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            GameId = 3,
                            GameTitle = "Red Dead Redemption 2",
                            Price = 59.990000000000002,
                            ShoppingCartId = 1
                        },
                        new
                        {
                            Id = 2,
                            GameId = 5,
                            GameTitle = "Sekiro: Shadows Die Twice",
                            Price = 59.990000000000002,
                            ShoppingCartId = 1
                        },
                        new
                        {
                            Id = 3,
                            GameId = 2,
                            GameTitle = "Dark Souls III",
                            Price = 29.989999999999998,
                            ShoppingCartId = 1
                        });
                });

            modelBuilder.Entity("ShoppingCartItem", b =>
                {
                    b.HasOne("ShoppingCart", "ShoppingCart")
                        .WithMany("Items")
                        .HasForeignKey("ShoppingCartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ShoppingCart");
                });

            modelBuilder.Entity("ShoppingCart", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
