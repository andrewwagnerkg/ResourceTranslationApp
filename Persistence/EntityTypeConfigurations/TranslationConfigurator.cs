using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityTypeConfigurations
{
    public class TranslationConfigurator : IEntityTypeConfiguration<Translation>
    {
        public void Configure(EntityTypeBuilder<Translation> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasDefaultValueSql("NEWID()")
                .ValueGeneratedOnAdd();
            builder.HasIndex(x => new { x.LocaleId, x.ResourceId, x.TranslatedValue })
                .IsUnique()
                .HasDatabaseName("IX_UniqueTranslation");
            builder.HasOne(x => x.Locale)
                .WithMany(x => x.Translations)
                .HasForeignKey(x=>x.LocaleId);
            builder.HasOne(x => x.Resource)
                .WithMany(x => x.Translations)
                .HasForeignKey(x => x.ResourceId);
        }
    }
}
