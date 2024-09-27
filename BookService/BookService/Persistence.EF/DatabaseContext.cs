using System.ComponentModel.DataAnnotations;
using System.Reflection;
using Domain.Model.Model.Author;
using Domain.Model.Model.Book;
using Framework.Mark;
using Microsoft.EntityFrameworkCore;

namespace Persistence.EF;

public class DatabaseContext(DbContextOptions<DatabaseContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder builder)
    {
        ApplyOwnsOne(builder);
        base.OnModelCreating(builder);
    }

    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }

    private void ApplyOwnsOne(ModelBuilder builder)
    {
        var entityTypes = builder.Model.GetEntityTypes();

        foreach (var entityType in entityTypes)
        {
            var clrType = entityType.ClrType;

            var ownedProperties = clrType.GetProperties()
                .Where(p => typeof(IObjectValue).IsAssignableFrom(p.PropertyType))
                .ToList();

            foreach (var property in ownedProperties)
            {
                var navigationBuilder = builder.Entity(clrType).OwnsOne(property.PropertyType, property.Name);

                foreach (var prop in property.PropertyType.GetProperties())
                {
                    var maxLengthAttribute = prop.GetCustomAttribute<MaxLengthAttribute>();
                    if (maxLengthAttribute != null)
                        navigationBuilder.Property(prop.Name).HasMaxLength(maxLengthAttribute.Length);
                }
            }
        }

    }
}