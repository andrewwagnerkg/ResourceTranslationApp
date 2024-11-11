namespace Application.Exceptions
{
    public abstract class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(string message = "Not specified") : base($"Entity not found. With message {message}")
        { }
    }
}
