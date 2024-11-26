namespace Core.Entities
{
    public class Resource : BaseEntity<long>
    {
        public string AppKey { get; set; }
        public string DefaultValue { get; set; }
    }
}
