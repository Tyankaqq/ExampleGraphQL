using CarRentalGraphQL.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentalGraphQL.DAO
{
    public class RentalRepository : IRentalRepository
    {
        private readonly RentalDbContext db;

        public RentalRepository(RentalDbContext db)
        {
            this.db = db;
        }

        public IQueryable<Rental> GetAllRentals()
        {
            return db.Rentals.AsQueryable();
        }

        public async Task<Rental> AddRental(int carId, int renterId, DateTime startDate, DateTime endDate, decimal totalCost)
        {
            Rental rental = new Rental
            {
                CarId = carId,
                RenterId = renterId,
                StartDate = startDate,
                EndDate = endDate,
                TotalCost = totalCost
            };
            db.Rentals.Add(rental);
            await db.SaveChangesAsync();
            return rental;
        }

        public async Task<Rental> UpdateRental(Rental model)
        {
            var rental = await db.Rentals.Where(r => r.Id == model.Id).FirstOrDefaultAsync();
            if (rental != null)
            {
                rental.CarId = model.CarId;
                rental.RenterId = model.RenterId;
                rental.StartDate = model.StartDate;
                rental.EndDate = model.EndDate;
                rental.TotalCost = model.TotalCost;
                db.Rentals.Update(rental);
                await db.SaveChangesAsync();
            }
            return rental;
        }

        public async Task DeleteRental(int id)
        {
            var rental = await db.Rentals.Where(r => r.Id == id).FirstOrDefaultAsync();
            if (rental != null)
            {
                db.Rentals.Remove(rental);
                await db.SaveChangesAsync();
            }
        }
    }
}
