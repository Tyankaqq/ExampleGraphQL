using CarRentalGraphQL.Models;
using System.Linq;

namespace CarRentalGraphQL.DAO
{
    public interface IRenterRepository
    {
        IQueryable<Renter> GetAllRenters();
        Task<Renter> AddRenter(string name, string email);
        Task<Renter> UpdateRenter(Renter model);
        Task DeleteRenter(int id);
    }
}
