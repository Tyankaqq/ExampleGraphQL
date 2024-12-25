using CarRentalGraphQL.Models;
using System.Linq;

namespace CarRentalGraphQL.DAO
{
    public interface IRentalRepository
    {
        IQueryable<Rental> GetAllRentals();
        Task<Rental> AddRental(int carId, int renterId, DateTime startDate, DateTime endDate, decimal totalCost);
        Task<Rental> UpdateRental(Rental model);
        Task DeleteRental(int id);
    }
}
