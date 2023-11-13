using System.Reflection;
using Application.Common.Interface;
using Domain.Common;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    private readonly IConfig _config;
    private readonly IDateTime _dateTimeService;
    
    public virtual DbSet<Detail> DetailSet { get; set; }

    public ApplicationDbContext(IConfig config, IDateTime dateTimeService)
    {
        _config = config;
        _dateTimeService = dateTimeService;
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(builder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var sqlTimeout = 600;
        if (!optionsBuilder.IsConfigured)
        {
            var connectionString = _config.ApplicationSettingsConfig.DbConnectionString();
            optionsBuilder.UseSqlServer(connectionString,
                    opts => opts.CommandTimeout(sqlTimeout))
                .EnableSensitiveDataLogging(true)
                .EnableDetailedErrors(true)
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

        optionsBuilder.LogTo(Console.WriteLine);
        base.OnConfiguring(optionsBuilder);
    }
    
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
    {
        foreach (Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<AuditableEntity> entry in ChangeTracker.Entries<AuditableEntity>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    entry.Entity.Modified = DateTime.Now;
                    break;
            
                case EntityState.Modified:
                    entry.Entity.Modified = DateTime.Now;
                    break;
            }
        }
        var result = await base.SaveChangesAsync(cancellationToken);

        return result;
    }
}