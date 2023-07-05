using ecom.Models;

namespace ecom.Data.Services.Actors;

public interface IActorsService
{
    Task<IEnumerable<Actor>> GetAllAsync();
    Task<Actor> GetByIdAsync(int id);
    Task AddAsync(Actor actor);
    Task<Actor> UpdateAsync(int id, Actor newActor);
    Task DeleteAsync(int id);
}
