using ecom.Services.Base;
using ecom.Models;
using ecom.Data;

namespace ecom.Services.Actors;

public class ActorsService : EntityBaseService<Actor>, IActorsService
{
    public ActorsService(AppDbContext context) : base(context) { }
}
