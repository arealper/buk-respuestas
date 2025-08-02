using SalesDatePrediction.API.Models;
using SalesDatePrediction.API.Repositories.Interfaces;
using SalesDatePrediction.API.Services.Interfaces;

namespace SalesDatePrediction.API.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repo;

        public EmployeeService(IEmployeeRepository repo)
        {
            _repo = repo;
        }

        public Task<IEnumerable<EmployeeDto>> GetAllAsync()
        {
            return _repo.GetAllAsync();
        }
    }
}
