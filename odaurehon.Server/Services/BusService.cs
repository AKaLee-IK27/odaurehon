using Server.Interfaces;
using Server.Models;
using Server.Repositories;

namespace Server.Services;

public interface IBusService
{
    void Add(Bus bus);
    void Delete(int id);
    void Update(Bus bus);
    IEnumerable<Bus> GetAll();
    Bus GetById(int id);
    IEnumerable<Bus> GetAllByDepartureTimeRange(DateTime from, DateTime to);
    IEnumerable<Bus> GetByRouteId(int routeId);
    void SaveChanges();
}

public class BusService : IBusService
{
    IBusRepository busRepository;
    IUnitOfWork unitOfWork;

    BusService(IBusRepository busRepository, IUnitOfWork unitOfWork)
    {
        this.busRepository = busRepository;
        this.unitOfWork = unitOfWork;
    }

    public void Add(Bus bus)
    {
        busRepository.Add(bus);
    }

    public void Delete(int id)
    {
        busRepository.Delete(id);
    }

    public IEnumerable<Bus> GetAll()
    {
        return busRepository.GetAll(["BusRoute"]);
    }

    public IEnumerable<Bus> GetAllByDepartureTimeRange(DateTime from, DateTime to)
    {
        return busRepository.GetAllByDepartureTimeRange(from, to);
    }

    public Bus GetById(int id)
    {
        return busRepository.GetSingleById(id);
    }

    public IEnumerable<Bus> GetByRouteId(int routeId)
    {
        return busRepository.GetMulti(b => b.BusRouteId == routeId, ["BusRoute"]);
    }

    public void SaveChanges()
    {
        unitOfWork.Commit();
    }

    public void Update(Bus bus)
    {
        busRepository.Update(bus);
    }
}
