using MovieApp.Services.Base;
using MovieApp.Models.FeatureModels;
using MovieApp.Data;

namespace MovieApp.Services.Actors;

public class ActorsService : EntityBaseService<Actor>, IActorsService
{
    public ActorsService(AppDbContext context) : base(context) { }
}
