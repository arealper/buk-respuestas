using SalesDatePrediction.API.Models;

namespace SalesDatePrediction.API.Repositories.Interfaces
{
    public interface IShipperRepository
    {
        Task<IEnumerable<ShipperDto>> GetAllAsync();
    }
}
