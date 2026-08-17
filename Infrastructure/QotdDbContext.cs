using System;
using System.Collections.Generic;
using System.Text;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class QotdDbContext : DbContext
{
    public DbSet<Author> Authors => Set<Author>();
    public DbSet<Quote> Quotes => Set<Quote>();

    public QotdDbContext(DbContextOptions<QotdDbContext> options) : base(options)
    {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.SeedData();
    }
}