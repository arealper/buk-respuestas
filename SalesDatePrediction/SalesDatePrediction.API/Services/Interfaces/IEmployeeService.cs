using SalesDatePrediction.API.Models;

namespace SalesDatePrediction.API.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDto>> GetAllAsync();
    }
}
