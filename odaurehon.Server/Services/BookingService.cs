using Server.Interfaces;
using Server.Models;
using Server.Repositories;

namespace Server.Services;

public interface IBookingService
{
    void Add(Booking booking);
    void Delete(int id);
    void Update(Booking booking);
    IEnumerable<Booking> GetAll();
    Booking GetById(int id);
    IEnumerable<Booking> GetByCustomerId(int customerId);
    Booking GetByPaymentId(int paymentId);
    void SaveChanges();
}

public class BookingService : IBookingService
{
    IBookingRepository _bookingRepository;
    IUnitOfWork _unitOfWork;

    // Dependency Injection
    public BookingService(IBookingRepository bookingRepository, IUnitOfWork unitOfWork)
    {
        _bookingRepository = bookingRepository;
        _unitOfWork = unitOfWork;
    }

    public void Add(Booking booking)
    {
        _bookingRepository.Add(booking);
    }

    public void Delete(int id)
    {
        _bookingRepository.Delete(id);
    }

    public IEnumerable<Booking> GetAll()
    {
        return _bookingRepository.GetAll(["Customer", "Payment"]);
    }

    public IEnumerable<Booking> GetByCustomerId(int customerId)
    {
        return _bookingRepository.GetMulti(x => x.CustomerId == customerId, ["Customer", "Payment"]);
    }

    public Booking GetById(int id)
    {
        return _bookingRepository.GetSingleById(id);
    }

    public Booking GetByPaymentId(int paymentId)
    {
        return _bookingRepository.GetSingleByCondition(x => x.PaymentId == paymentId, ["Customer", "Payment"]);
    }

    public void SaveChanges()
    {
        _unitOfWork.Commit();
    }

    public void Update(Booking booking)
    {
        _bookingRepository.Update(booking);
    }
}
