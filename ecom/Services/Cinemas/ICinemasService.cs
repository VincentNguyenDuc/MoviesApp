using ecom.Models;

namespace ecom.Services.Cinemas;

public interface ICinemasService
{
    Task<IEnumerable<Cinema>> GetAllAsync();
    Task<Cinema> GetByIdAsync(int id);
    Task AddAsync(Cinema cinema);
    Task<Cinema> UpdateAsync(int id, Cinema newCinema);
    Task DeleteAsync(int id);
}
