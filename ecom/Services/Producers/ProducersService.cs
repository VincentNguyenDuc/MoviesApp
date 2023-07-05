using ecom.Models;
using ecom.Services.Base;
using ecom.Data;

namespace ecom.Services.Producers;

public class ProducersService : EntityBaseService<Producer>, IProducersService
{
    public ProducersService(AppDbContext context) : base(context) { }
}
