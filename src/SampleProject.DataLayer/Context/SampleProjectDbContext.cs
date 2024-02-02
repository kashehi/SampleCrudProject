using Microsoft.EntityFrameworkCore;
using SampleProject.Entities;

namespace SampleProject.DataLayer.Context;

public class SampleProjectDbContext : DbContext
{
    public SampleProjectDbContext(DbContextOptions options)
        : base(options)
    { }

    public DbSet<Product> Products { get; set; }
}

