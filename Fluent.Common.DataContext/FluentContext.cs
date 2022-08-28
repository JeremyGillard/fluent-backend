using Fluent.Models;

using Microsoft.EntityFrameworkCore;

namespace Fluent.Data;

public class FluentContext : DbContext
{
    public DbSet<FlashCard> FlashCards { get; set; } = null!;
    public DbSet<Revision> Revisions { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Database URL");
    }
}