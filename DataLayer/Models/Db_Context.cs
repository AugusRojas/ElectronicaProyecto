using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Models;

public partial class Db_Context : DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Sale> Sales { get; set; }
    public DbSet<PaymentMethod> PaymentMethods { get; set; }

    public Db_Context(DbContextOptions<Db_Context> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>()
            .HasMany(p => p.Sales)
            .WithMany(s => s.Products);
        
        modelBuilder.Entity<Sale>()
            .HasOne(s=>s.PaymentMethod)
            .WithOne(p => p.Sale);
    }

}
