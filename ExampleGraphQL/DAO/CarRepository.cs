using CarRentalGraphQL.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentalGraphQL.DAO
{
    public class CarRepository : ICarRepository
    {
        private readonly RentalDbContext db;

        public CarRepository(RentalDbContext db)
        {
            this.db = db;
        }

        public IQueryable<Car> GetAllCars()
        {
            return db.Cars.AsQueryable();
        }

        public async Task<Car> AddCar(string make, string model, bool isAvailable)
        {
            Car car = new Car
            {
                Make = make,
                Model = model,
                IsAvailable = isAvailable
            };
            db.Cars.Add(car);
            await db.SaveChangesAsync();
            return car;
        }

        public async Task<Car> UpdateCar(Car model)
        {
            var car = await db.Cars.Where(c => c.Id == model.Id).FirstOrDefaultAsync();
            if (car != null)
            {
                if (!string.IsNullOrEmpty(model.Make))
                    car.Make = model.Make;
                if (!string.IsNullOrEmpty(model.Model))
                    car.Model = model.Model;
                car.IsAvailable = model.IsAvailable;
                db.Cars.Update(car);
                await db.SaveChangesAsync();
            }
            return car;
        }

        public async Task DeleteCar(int id)
        {
            var car = await db.Cars.Where(c => c.Id == id).FirstOrDefaultAsync();
            if (car != null)
            {
                db.Cars.Remove(car);
                await db.SaveChangesAsync();
            }
        }
    }
}
