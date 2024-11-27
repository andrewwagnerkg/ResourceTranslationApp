namespace Core.Entities
{
    public class Translation : BaseEntity<Guid>
    {
        public long LocaleId { get; set; }
        public Locale Locale { get; set; }
        public long ResourceId { get; set; }
        public Resource Resource { get; set; }
        public string TranslatedValue { get; set; }
    }
}
