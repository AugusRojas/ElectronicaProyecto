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

    public Db_Context(DbContextOptions<Db_Context> options) : base(options) {}
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
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
    }

}
