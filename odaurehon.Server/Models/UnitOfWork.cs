using Server.Interfaces;
using Server.Models.Data;
using Server.Repositories;

namespace Server.Models
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EFDataContext _context;
        public UnitOfWork(EFDataContext context)
        {
            _context = context;
            Buses = new BusRepository(_context);
        }
        public IBusRepository Buses { get; private set; }

        IBusRepository IUnitOfWork.Developers => throw new NotImplementedException();

        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
