using Server.Repositories;

namespace Server.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IBusRepository Buses { get; }
        IBookingRepository Bookings { get; }

        int Commit();
    }
}
