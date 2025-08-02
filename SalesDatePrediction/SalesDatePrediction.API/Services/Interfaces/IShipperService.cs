using SalesDatePrediction.API.Models;

namespace SalesDatePrediction.API.Services.Interfaces
{
    public interface IShipperService
    {
        Task<IEnumerable<ShipperDto>> GetAllAsync();
    }
}
