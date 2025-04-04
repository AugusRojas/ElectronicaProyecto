using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Models;

public partial class Db_Context : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Sale> Sales { get; set; }
    public DbSet<PaymentMethod> PaymentMethods { get; set; }
    public DbSet<ProductsXSales> ProductsXSales { get; set; }

    public DbSet<Category> Category { get; set; }

    public Db_Context(DbContextOptions<Db_Context> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Definiendo las claves primarias de las tablas
        modelBuilder.Entity<Category>()
            .HasKey(c => c.idCategory);

        modelBuilder.Entity<PaymentMethod>()
            .HasKey(p => p.idPaymentMethod);

        modelBuilder.Entity<Product>()
            .HasKey(p => p.idProduct);

        modelBuilder.Entity<Sale>()
            .HasKey(s => s.idSale);

        modelBuilder.Entity<ProductsXSales>()
            .HasKey(ps => new { ps.idProduct, ps.idSale });


        //Definiendo las relaciones entre tablas
        modelBuilder.Entity<Product>()
            .HasMany(p => p.ProductsXSales)
            .WithOne(ps => ps.product)
            .HasForeignKey(ps => ps.idProduct);

        modelBuilder.Entity<Sale>()
            .HasMany(s => s.ProductsXSales)
            .WithOne(ps => ps.sale)
            .HasForeignKey(ps => ps.idSale);

        modelBuilder.Entity<PaymentMethod>()
            .HasMany(p => p.Sales)
            .WithOne(s => s.PaymentMethod)
            .HasForeignKey(s => s.idPaymentMethod);

        modelBuilder.Entity<Category>()
            .HasMany(c => c.Products)
            .WithOne(p => p.Category)
            .HasForeignKey(p => p.idCategory);

        modelBuilder.Entity<Product>()
            .HasOne(p => p.Category)
            .WithMany(c => c.Products)
            .HasForeignKey(p => p.idCategory);
    }

}
