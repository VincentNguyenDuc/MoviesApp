using ecom.Models;
using Microsoft.EntityFrameworkCore;
using ecom.Data;

namespace ecom.Services.Producers;

public class ProducersService : IProducersService
{
    private readonly AppDbContext _context; 

    public ProducersService(AppDbContext context)
    {
        _context = context;
    }
    public async Task AddAsync(Producer producer)
    {
        await _context.Producers.AddAsync(producer);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var producer = await _context.Producers.FirstOrDefaultAsync(n => n.Id == id);
        _context.Producers.Remove(producer);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Producer>> GetAllAsync()
    {
        var result = await _context.Producers.ToListAsync();
        return result;
    }

    public async Task<Producer> GetByIdAsync(int id)
    {
        var result = await _context.Producers.FirstOrDefaultAsync(n => n.Id == id);
        return result;
    }

    public async Task<Producer> UpdateAsync(int id, Producer newProducer)
    {
        _context.Producers.Update(newProducer);
        await _context.SaveChangesAsync();
        return newProducer;
    }
}
