using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityTypeConfigurations
{
    public class LocaleConfigurator : IEntityTypeConfiguration<Locale>
    {
        public void Configure(EntityTypeBuilder<Locale> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x=>x.Code).HasMaxLength(10);
            builder.Property(x=>x.Name).HasMaxLength(250);
        }
    }
}
