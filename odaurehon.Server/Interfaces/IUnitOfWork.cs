using Server.Repositories;

namespace Server.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IBusRepository Developers { get; }

        int Complete();
    }
}
