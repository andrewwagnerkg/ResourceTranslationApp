namespace Application.Exceptions
{
    public class UserNotFoundException : EntityNotFoundException
    {
        public UserNotFoundException(string userName) : base($"User not found by login {userName}")
        {
        }
    }
}
