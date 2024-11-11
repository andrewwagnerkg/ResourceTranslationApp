namespace Application.Interfaces
{
    public interface IApplicationDBContext
    {
        Task<int> SaveChangesAsync(CancellationToken cancelationToken);
    }
}
