using SalesDatePrediction.API.Models;
using SalesDatePrediction.API.Repositories.Interfaces;
using SalesDatePrediction.API.Services.Interfaces;

namespace SalesDatePrediction.API.Services
{
    public class ShipperService : IShipperService
    {
        private readonly IShipperRepository _repo;

        public ShipperService(IShipperRepository repo)
        {
            _repo = repo;
        }

        public Task<IEnumerable<ShipperDto>> GetAllAsync()
        {
            return _repo.GetAllAsync();
        }
    }
}
