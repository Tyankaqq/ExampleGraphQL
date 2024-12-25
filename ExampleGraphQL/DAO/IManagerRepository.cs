using CarRentalGraphQL.Models;
using System.Linq;

namespace CarRentalGraphQL.DAO
{
    public interface IManagerRepository
    {
        IQueryable<Manager> GetAllManagers();
        Task<Manager> AddManager(string name, string email);
        Task<Manager> UpdateManager(Manager model);
        Task DeleteManager(int id);
    }
}
