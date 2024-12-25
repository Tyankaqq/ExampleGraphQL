using CarRentalGraphQL.Models;
using System.Linq;

namespace CarRentalGraphQL.DAO
{
    public interface ICarRepository
    {
        IQueryable<Car> GetAllCars();
        Task<Car> AddCar(string make, string model, bool isAvailable);
        Task<Car> UpdateCar(Car model);
        Task DeleteCar(int id);
    }
}
