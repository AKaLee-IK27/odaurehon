using Server.Interfaces;
using Server.Models;
using Server.Models.Data;

namespace Server.Repositories;

public interface IBusRepository : IGenericRepository<Bus>
{
    IEnumerable<Bus> GetAllByDepartureTimeRange(DateTime from, DateTime to);
}

public class BusRepository : GenericRepository<Bus>, IBusRepository
{
    public BusRepository(EFDataContext context)
        : base(context) { }

    public IEnumerable<Bus> GetAllByDepartureTimeRange(DateTime from, DateTime to)
    {
        var buses = dbContext.Buses.Where(bus =>
            bus.BusRoute.DepartureTime >= from && bus.BusRoute.DepartureTime <= to
        );

        return buses.ToList();
    }
}
