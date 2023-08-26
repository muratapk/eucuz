﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using eucuz.Data;

#nullable disable

namespace eucuz.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("eucuz.Models.Admin", b =>
                {
                    b.Property<int>("admin_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("admin_Id"), 1L, 1);

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("admin_Id");

                    b.ToTable("admins");
                });

            modelBuilder.Entity("eucuz.Models.kategoriler", b =>
                {
                    b.Property<int>("kategori_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("kategori_Id"), 1L, 1);

                    b.Property<string>("kategori_Ad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("kategori_Id");

                    b.ToTable("kategorilers");
                });

            modelBuilder.Entity("eucuz.Models.sepet", b =>
                {
                    b.Property<int>("sepet_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("sepet_Id"), 1L, 1);

                    b.Property<int>("adet")
                        .HasColumnType("int");

                    b.Property<int>("urun_Id")
                        .HasColumnType("int");

                    b.Property<int>("urunlersurun_Id")
                        .HasColumnType("int");

                    b.HasKey("sepet_Id");

                    b.HasIndex("urunlersurun_Id");

                    b.ToTable("sepet");
                });

            modelBuilder.Entity("eucuz.Models.siparisler", b =>
                {
                    b.Property<int>("siparis_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("siparis_Id"), 1L, 1);

                    b.Property<int>("adet")
                        .HasColumnType("int");

                    b.Property<int>("urun_Id")
                        .HasColumnType("int");

                    b.HasKey("siparis_Id");

                    b.HasIndex("urun_Id");

                    b.ToTable("siparislers");
                });

            modelBuilder.Entity("eucuz.Models.Urunler", b =>
                {
                    b.Property<int>("urun_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("urun_Id"), 1L, 1);

                    b.Property<string>("aciklama")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("birim")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("indirim")
                        .HasColumnType("int");

                    b.Property<int>("kategori_Id")
                        .HasColumnType("int");

                    b.Property<int?>("kategorilerkategori_Id")
                        .HasColumnType("int");

                    b.Property<string>("olcut")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("resim")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("urun_Adi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("urun_Kodu")
                        .HasColumnType("int");

                    b.Property<int>("urun_fiyat")
                        .HasColumnType("int");

                    b.HasKey("urun_Id");

                    b.HasIndex("kategorilerkategori_Id");

                    b.ToTable("urunlers");
                });

            modelBuilder.Entity("eucuz.Models.sepet", b =>
                {
                    b.HasOne("eucuz.Models.Urunler", "urunlers")
                        .WithMany()
                        .HasForeignKey("urunlersurun_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("urunlers");
                });

            modelBuilder.Entity("eucuz.Models.siparisler", b =>
                {
                    b.HasOne("eucuz.Models.Urunler", "Urunler")
                        .WithMany()
                        .HasForeignKey("urun_Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Urunler");
                });

            modelBuilder.Entity("eucuz.Models.Urunler", b =>
                {
                    b.HasOne("eucuz.Models.kategoriler", null)
                        .WithMany("urunlers")
                        .HasForeignKey("kategorilerkategori_Id");
                });

            modelBuilder.Entity("eucuz.Models.kategoriler", b =>
                {
                    b.Navigation("urunlers");
                });
#pragma warning restore 612, 618
        }
    }
}
