using SalesDatePrediction.API.Models;

namespace SalesDatePrediction.API.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<EmployeeDto>> GetAllAsync();
    }
}
