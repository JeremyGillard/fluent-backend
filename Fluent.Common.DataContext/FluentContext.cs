using Fluent.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Fluent.Data;

public class FluentContext : DbContext
{
    public DbSet<FlashCard> FlashCards { get; set; } = null!;
    public DbSet<Revision> Revisions { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Server=localhost;User Id=sa;Password=P@ssw0rd;Initial Catalog=Fluent");
    }
}