using Server.Interfaces;
using Server.Models;
using Server.Models.Data;

namespace Server.Repositories;

public interface IBookingRepository : IGenericRepository<Booking> { }

public class BookingRepository : GenericRepository<Booking>, IBookingRepository
{
    public BookingRepository(EFDataContext context)
        : base(context) { }
}
