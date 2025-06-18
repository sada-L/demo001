using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using demo.Models;

namespace demo.Context;

public partial class PostgresContext : DbContext
{
    public PostgresContext()
    {
    }

    public PostgresContext(DbContextOptions<PostgresContext> options)
        : base(options)
    {
    }

    public virtual DbSet<MaterialType> MaterialTypes { get; set; }

    public virtual DbSet<Partner> Partners { get; set; }

    public virtual DbSet<PartnerProduct> PartnerProducts { get; set; }

    public virtual DbSet<PartnerType> PartnerTypes { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductType> ProductTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=89.110.53.87;Database=postgres;Username=postgres;password=QWEasd123;port=5522");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MaterialType>(entity =>
        {
            entity.HasKey(e => e.MaterialTypeId).HasName("material_types_pk");

            entity.ToTable("material_types", "demo");

            entity.Property(e => e.MaterialTypeId).HasColumnName("material_type_id");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.Procent).HasColumnName("procent");
        });

        modelBuilder.Entity<Partner>(entity =>
        {
            entity.HasKey(e => e.PartnerId).HasName("partners_pk");

            entity.ToTable("partners", "demo");

            entity.Property(e => e.PartnerId).HasColumnName("partner_id");
            entity.Property(e => e.Address)
                .HasColumnType("character varying")
                .HasColumnName("address");
            entity.Property(e => e.DirName)
                .HasColumnType("character varying")
                .HasColumnName("dir_name");
            entity.Property(e => e.Email)
                .HasColumnType("character varying")
                .HasColumnName("email");
            entity.Property(e => e.Inn)
                .HasColumnType("character varying")
                .HasColumnName("inn");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.PartnerTypeId).HasColumnName("partner_type_id");
            entity.Property(e => e.Phone)
                .HasColumnType("character varying")
                .HasColumnName("phone");
            entity.Property(e => e.Rate).HasColumnName("rate");

            entity.HasOne(d => d.PartnerType).WithMany(p => p.Partners)
                .HasForeignKey(d => d.PartnerTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("partners_partner_types_fk");
        });

        modelBuilder.Entity<PartnerProduct>(entity =>
        {
            entity.HasKey(e => e.PartnerProduct1).HasName("partner_product_pk");

            entity.ToTable("partner_product", "demo");

            entity.Property(e => e.PartnerProduct1).HasColumnName("partner_product");
            entity.Property(e => e.Count).HasColumnName("count");
            entity.Property(e => e.Date).HasColumnName("date");
            entity.Property(e => e.PartnerId).HasColumnName("partner_id");
            entity.Property(e => e.ProductId).HasColumnName("product_id");

            entity.HasOne(d => d.Partner).WithMany(p => p.PartnerProducts)
                .HasForeignKey(d => d.PartnerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("partner_product_partners_fk");

            entity.HasOne(d => d.Product).WithMany(p => p.PartnerProducts)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("partner_product_products_fk");
        });

        modelBuilder.Entity<PartnerType>(entity =>
        {
            entity.HasKey(e => e.PartnerTypeId).HasName("partner_types_pk");

            entity.ToTable("partner_types", "demo");

            entity.Property(e => e.PartnerTypeId).HasColumnName("partner_type_id");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("products_pk");

            entity.ToTable("products", "demo");

            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.Articul)
                .HasColumnType("character varying")
                .HasColumnName("articul");
            entity.Property(e => e.Cost).HasColumnName("cost");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.ProductTypeId).HasColumnName("product_type_id");

            entity.HasOne(d => d.ProductType).WithMany(p => p.Products)
                .HasForeignKey(d => d.ProductTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("products_product_types_fk");
        });

        modelBuilder.Entity<ProductType>(entity =>
        {
            entity.HasKey(e => e.ProductTypeId).HasName("product_types_pk");

            entity.ToTable("product_types", "demo");

            entity.Property(e => e.ProductTypeId).HasColumnName("product_type_id");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.Procent).HasColumnName("procent");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
