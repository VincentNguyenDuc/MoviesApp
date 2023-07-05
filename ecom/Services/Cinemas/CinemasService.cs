using ecom.Models;
using ecom.Data;
using ecom.Services.Base;

namespace ecom.Services.Cinemas;

public class CinemasService : EntityBaseService<Cinema>, ICinemasService
{
    public CinemasService(AppDbContext context) : base(context) { }
}