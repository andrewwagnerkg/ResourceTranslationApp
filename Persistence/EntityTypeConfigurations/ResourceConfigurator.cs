using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityTypeConfigurations
{
    public class ResourceConfigurator : IEntityTypeConfiguration<Resource>
    {
        public void Configure(EntityTypeBuilder<Resource> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.AppKey).IsRequired();
            builder.HasIndex(x => new { x.AppKey, x.DefaultValue }).IsUnique().HasDatabaseName("IX_UniqueResource");
        }
    }
}
