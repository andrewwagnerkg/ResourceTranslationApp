using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces
{
    public interface IApplicationDBContext
    {
        Task<int> SaveChangesAsync(CancellationToken cancelationToken);

        DbSet<Locale> Locales { get; set; }
        DbSet<Resource> Resources { get; set; }
    }
}
