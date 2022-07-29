﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Products.DataAccessLayer.Context;

#nullable disable

namespace Products.DataAccessLayer.Migrations
{
    [DbContext(typeof(MahdaviContext))]
    [Migration("20220726163756_initPro001")]
    partial class initPro001
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Products.Domain.Categories.Entities.Category", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("BannerUrl")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(550)
                        .HasColumnType("character varying(550)")
                        .HasDefaultValue("https://via.placeholder.com/350");

                    b.Property<long>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long>("DeletedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(5000)
                        .HasColumnType("character varying(5000)");

                    b.Property<string>("IconUrl")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(550)
                        .HasColumnType("character varying(550)")
                        .HasDefaultValue("https://via.placeholder.com/850x350");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<long?>("ParentCategoryId")
                        .IsRequired()
                        .HasColumnType("bigint");

                    b.Property<string>("PermaLink")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValue("http://www.msn.com");

                    b.Property<int>("Priority")
                        .HasColumnType("integer");

                    b.Property<string>("ThumbnailUrl")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(550)
                        .HasColumnType("character varying(550)")
                        .HasDefaultValue("https://via.placeholder.com/300x100");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.Property<long>("UpdatedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("ParentCategoryId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            BannerUrl = "https://via.placeholder.com/350x50",
                            CreatedBy = 0L,
                            CreatedDate = new DateTime(2022, 7, 26, 21, 7, 56, 395, DateTimeKind.Local).AddTicks(6100),
                            DeletedBy = 0L,
                            Description = "CatDesc001",
                            IconUrl = "https://via.placeholder.com/400x200",
                            IsActive = true,
                            ParentCategoryId = 1L,
                            PermaLink = "http://wwww.microsoft.com",
                            Priority = 0,
                            ThumbnailUrl = "https://via.placeholder.com/150x250",
                            Title = "Cat001",
                            UpdatedBy = 0L
                        },
                        new
                        {
                            Id = 2L,
                            BannerUrl = "https://via.placeholder.com/8500x600",
                            CreatedBy = 0L,
                            CreatedDate = new DateTime(2022, 7, 26, 21, 7, 56, 395, DateTimeKind.Local).AddTicks(6160),
                            DeletedBy = 0L,
                            Description = "CatDesc002",
                            IconUrl = "https://via.placeholder.com/600x400",
                            IsActive = true,
                            ParentCategoryId = 1L,
                            PermaLink = "http://wwww.mymap.com",
                            Priority = 0,
                            ThumbnailUrl = "https://via.placeholder.com/950x650",
                            Title = "Cat002",
                            UpdatedBy = 0L
                        });
                });

            modelBuilder.Entity("Products.Domain.Products.Entities.Product", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("CategoryId")
                        .HasColumnType("bigint");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("CoverImageUrl")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text")
                        .HasDefaultValue("https://via.placeholder.com/450x150");

                    b.Property<long>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<long>("DeletedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(5000)
                        .HasColumnType("character varying(5000)");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("boolean")
                        .HasDefaultValue(false);

                    b.Property<string>("PermaLink")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)")
                        .HasDefaultValue("http://www.google.com");

                    b.Property<decimal>("Price")
                        .HasMaxLength(20)
                        .HasColumnType("numeric");

                    b.Property<string>("Titile")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("character varying(250)");

                    b.Property<long>("UpdatedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("UpdatedDate")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CategoryId = 1L,
                            Code = "https://via.placeholder.com/550x350",
                            CoverImageUrl = "https://via.placeholder.com/550x350",
                            CreatedBy = 0L,
                            CreatedDate = new DateTime(2022, 7, 26, 21, 7, 56, 395, DateTimeKind.Local).AddTicks(8080),
                            DeletedBy = 0L,
                            Description = "Description001",
                            IsActive = false,
                            PermaLink = "http://www.google.com",
                            Price = 1000m,
                            Titile = "Title001",
                            UpdatedBy = 0L
                        },
                        new
                        {
                            Id = 2L,
                            CategoryId = 1L,
                            Code = "https://via.placeholder.com/200x100",
                            CoverImageUrl = "https://via.placeholder.com/200x100",
                            CreatedBy = 0L,
                            CreatedDate = new DateTime(2022, 7, 26, 21, 7, 56, 395, DateTimeKind.Local).AddTicks(8090),
                            DeletedBy = 0L,
                            Description = "Description002",
                            IsActive = true,
                            PermaLink = "http://www.yahoo.com",
                            Price = 205m,
                            Titile = "Title002",
                            UpdatedBy = 0L
                        });
                });

            modelBuilder.Entity("Products.Domain.Categories.Entities.Category", b =>
                {
                    b.HasOne("Products.Domain.Categories.Entities.Category", "ParentCategory")
                        .WithMany()
                        .HasForeignKey("ParentCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ParentCategory");
                });

            modelBuilder.Entity("Products.Domain.Products.Entities.Product", b =>
                {
                    b.HasOne("Products.Domain.Categories.Entities.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Products.Domain.Categories.Entities.Category", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
