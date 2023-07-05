using ecom.Models;
using Microsoft.EntityFrameworkCore;

namespace ecom.Data.Services.Cinemas;

public class CinemasService : ICinemasService
{
    private readonly AppDbContext _context;
    public CinemasService(AppDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Cinema>> GetAllAsync()
    {
        var result = await _context.Cinemas.ToListAsync();
        return result;
    }
    public async Task<Cinema> GetByIdAsync(int id)
    {
        var result = await _context.Cinemas.FirstOrDefaultAsync(x => x.Id == id);
        return result;
    }
    public async Task AddAsync(Cinema cinema)
    {
        await _context.Cinemas.AddAsync(cinema);
        await _context.SaveChangesAsync();
    }
    public async Task<Cinema> UpdateAsync(int id, Cinema newCinema)
    {
        _context.Cinemas.Update(newCinema);
        await _context.SaveChangesAsync();
        return newCinema;

    }
    public async Task DeleteAsync(int id)
    {
        var cinema = await _context.Cinemas.FirstOrDefaultAsync(n => n.Id == id);
        _context.Cinemas.Remove(cinema);
        await _context.SaveChangesAsync();
    }
}