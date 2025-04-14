using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    //Your Models (Entities) go here. This is the database, the models are the tables.
    public required DbSet<Activity> Activities { get; set; }
}