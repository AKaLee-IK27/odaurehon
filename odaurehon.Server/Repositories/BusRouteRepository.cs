using Server.Interfaces;
using Server.Models;
using Server.Models.Data;

namespace Server.Repositories;

public interface IBusRouteRepository : IGenericRepository<BusRoute> { }

public class BusRouteRepository : GenericRepository<BusRoute>, IBusRouteRepository
{
    public BusRouteRepository(EFDataContext context)
        : base(context) { }
}
