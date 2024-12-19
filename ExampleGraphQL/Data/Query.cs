using CarRentalGraphQL.Models;
using HotChocolate;
using HotChocolate.Authorization;
using HotChocolate.Data;
namespace CarRentalGraphQL.Data
{
    public class Query
    {
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Post> GetPosts([Service] RentalDbContext context) => context.Posts;

        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Comment> GetComments([Service] RentalDbContext context) => context.Comments;

        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Car> GetCars([Service] RentalDbContext context) => context.Cars;

        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Renter> GetRenters([Service] RentalDbContext context) => context.Renters;

        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Manager> GetManagers([Service] RentalDbContext context) => context.Managers;

        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Service> GetServices([Service] RentalDbContext context) => context.Services;

        [UseProjection]
        [UseFiltering]
        [UseSorting]
        public IQueryable<Rental> GetRentals([Service] RentalDbContext context) => context.Rentals;

        public IQueryable<Car> GetAvailableCars([Service] RentalDbContext context) =>
            context.Cars.Where(c => c.IsAvailable);

        public IQueryable<Car> GetRentedCars([Service] RentalDbContext context) =>
            context.Cars.Where(c => !c.IsAvailable);

        public IQueryable<Car> GetCarsAvailableOnDate([Service] RentalDbContext context, DateTime date) =>
            context.Cars.Where(c => c.IsAvailable && !context.Rentals.Any(r => r.CarId == c.Id && r.StartDate <= date && r.EndDate >= date));

        public IQueryable<Renter> GetDebtors([Service] RentalDbContext context) =>
            context.Renters.Where(r => r.Rentals.Any(rental => rental.TotalCost > 0));

        public decimal GetTotalCost([Service] RentalDbContext context, DateTime startDate, DateTime endDate) =>
            context.Rentals.Where(r => r.StartDate >= startDate && r.EndDate <= endDate).Sum(r => r.TotalCost);
    }
}
