using MovieApp.Models;
using MovieApp.Data;
using MovieApp.Services.Base;

namespace MovieApp.Services.Cinemas;

public class CinemasService : EntityBaseService<Cinema>, ICinemasService
{
    public CinemasService(AppDbContext context) : base(context) { }
}