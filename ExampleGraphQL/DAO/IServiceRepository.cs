using CarRentalGraphQL.Models;
using System.Linq;

namespace CarRentalGraphQL.DAO
{
    public interface IServiceRepository
    {
        IQueryable<Service> GetAllServices();
        Task<Service> AddService(string name, decimal price);
        Task<Service> UpdateService(Service model);
        Task DeleteService(int id);
    }
}
