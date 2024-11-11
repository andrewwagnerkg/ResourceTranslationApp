namespace Infrastructure.Extensions
{
    public static class EnumExtensions
    {
        public static IEnumerable<T> ToEnumerable<T>() where T : Enum
        {
            return Enum.GetValues(typeof(T)).Cast<T>().ToList();
        }
    }
}
