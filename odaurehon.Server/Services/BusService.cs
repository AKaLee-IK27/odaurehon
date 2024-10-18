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
    IEnumerable<Bus> GetAllByDepartureTimeRange(TimeOnly from, TimeOnly to);
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
        return busRepository.GetAll();
    }

    public IEnumerable<Bus> GetAllByDepartureTimeRange(TimeOnly from, TimeOnly to)
    {
        throw new NotImplementedException();
    }

    public Bus GetById(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Bus> GetByRouteId(int routeId)
    {
        throw new NotImplementedException();
    }

    public void SaveChanges()
    {
        throw new NotImplementedException();
    }

    public void Update(Bus bus)
    {
        throw new NotImplementedException();
    }
}
