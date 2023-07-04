using ecom.Models;

namespace ecom.Data.Services;

public interface ICinemasService
{
    Task<IEnumerable<Cinema>> GetAll();
    Cinema GetById(int id);
    void Add(Cinema cinema);
    Cinema Update(int id, Cinema newCinema);
    void Delete(int id);
}
