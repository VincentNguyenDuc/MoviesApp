using MovieApp.Models;
using MovieApp.Services.Base;
using MovieApp.Data;

namespace MovieApp.Services.Producers;

public class ProducersService : EntityBaseService<Producer>, IProducersService
{
    public ProducersService(AppDbContext context) : base(context) { }
}
