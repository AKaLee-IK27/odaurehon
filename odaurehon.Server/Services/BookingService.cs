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
    IBookingRepository bookingRepository;
    IUnitOfWork unitOfWork;

    // Dependency Injection
    public BookingService(IBookingRepository bookingRepository, IUnitOfWork unitOfWork)
    {
        this.bookingRepository = bookingRepository;
        this.unitOfWork = unitOfWork;
    }

    public void Add(Booking booking)
    {
        bookingRepository.Add(booking);
    }

    public void Delete(int id)
    {
        bookingRepository.Delete(id);
    }

    public IEnumerable<Booking> GetAll()
    {
        return bookingRepository.GetAll(["Customer", "Payment"]);
    }

    public IEnumerable<Booking> GetByCustomerId(int customerId)
    {
        return bookingRepository.GetMulti(x => x.CustomerId == customerId, ["Customer", "Payment"]);
    }

    public Booking GetById(int id)
    {
        return bookingRepository.GetSingleById(id);
    }

    public Booking GetByPaymentId(int paymentId)
    {
        return bookingRepository.GetSingleByCondition(
            x => x.PaymentId == paymentId,
            ["Customer", "Payment"]
        );
    }

    public void SaveChanges()
    {
        unitOfWork.Commit();
    }

    public void Update(Booking booking)
    {
        bookingRepository.Update(booking);
    }
}
