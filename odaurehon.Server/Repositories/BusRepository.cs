using Server.Interfaces;
using Server.Models;
using Server.Models.Data;

namespace Server.Repositories
{
    public interface IBusRepository : IGenericRepository<Bus>
    {

    }

    public class BusRepository : GenericRepository<Bus>, IBusRepository
    {
        public BusRepository(EFDataContext context) : base(context)
        {

        }
    }
}
