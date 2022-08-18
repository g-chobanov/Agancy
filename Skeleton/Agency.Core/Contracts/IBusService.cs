using Agency.Models.Vehicles;
using Agency.Models.Vehicles.Contracts;

namespace Agency.Core.Contracts
{
    public interface IBusService
    {
        List<Bus> GetBuses();

        void AddBus(IBus bus);

        IBus GetBus(Guid ID);
    }
}