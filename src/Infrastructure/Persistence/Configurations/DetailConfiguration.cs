using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.Configurations;

public class DetailConfiguration : IEntityTypeConfiguration<Detail>
{
    public void Configure(EntityTypeBuilder<Detail> builder)
    {
            builder.HasKey(key => key.Id);
            builder.ToTable("detail");
            builder.Property(e => e.ValueNum).HasPrecision(12,5);
    }
}