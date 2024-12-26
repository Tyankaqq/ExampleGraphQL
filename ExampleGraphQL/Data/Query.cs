using CarRentalGraphQL.Models;
using CarRentalGraphQL.DAO;
using HotChocolate;
using HotChocolate.Data;

namespace CarRentalGraphQL.Data
{
    public class Query
    {
        [UseProjection]
        [UseFiltering]
        [UseSorting]
        [GraphQLDescription("Method used to get list of all Posts")]
        public IQueryable<Post> GetPosts([Service] IPostRepository postRepository) => postRepository.GetAllPostsOnly();

        [UseProjection]
        [UseFiltering]
        [UseSorting]
        [GraphQLDescription("Method used to get list of all Comments")]
        public IQueryable<Comment> GetComments([Service] ICommentRepository commentRepository) => commentRepository.GetAllComments();

        [UseProjection]
        [UseFiltering]
        [UseSorting]
        [GraphQLDescription("Method used to get list of all Cars")]
        public IQueryable<Car> GetCars([Service] ICarRepository carRepository) => carRepository.GetAllCars();

        [UseProjection]
        [UseFiltering]
        [UseSorting]
        [GraphQLDescription("Method used to get list of all Renters")]
        public IQueryable<Renter> GetRenters([Service] IRenterRepository renterRepository) => renterRepository.GetAllRenters();

        [UseProjection]
        [UseFiltering]
        [UseSorting]
        [GraphQLDescription("Method used to get list of all Managers")]
        public IQueryable<Manager> GetManagers([Service] IManagerRepository managerRepository) => managerRepository.GetAllManagers();

        [UseProjection]
        [UseFiltering]
        [UseSorting]
        [GraphQLDescription("Method used to get list of all Services")]
        public IQueryable<Service> GetServices([Service] IServiceRepository serviceRepository) => serviceRepository.GetAllServices();

        [UseProjection]
        [UseFiltering]
        [UseSorting]
        [GraphQLDescription("Method used to get list of all Rentals")]
        public IQueryable<Rental> GetRentals([Service] IRentalRepository rentalRepository) => rentalRepository.GetAllRentals();

        [UseProjection]
        [UseFiltering]
        [UseSorting]
        [GraphQLDescription("Method used to get available Cars")]
        public IQueryable<Car> GetAvailableCars([Service] ICarRepository carRepository) =>
            carRepository.GetAllCars().Where(c => c.IsAvailable);

        [UseProjection]
        [UseFiltering]
        [UseSorting]
        [GraphQLDescription("Method used to get rented Cars")]
        public IQueryable<Car> GetRentedCars([Service] ICarRepository carRepository) =>
            carRepository.GetAllCars().Where(c => !c.IsAvailable);

        [UseProjection]
        [UseFiltering]
        [UseSorting]
        [GraphQLDescription("Method used to get Cars available on a specific date")]
        public IQueryable<Car> GetCarsAvailableOnDate([Service] ICarRepository carRepository, [Service] RentalDbContext context, DateTime date) =>
            carRepository.GetAllCars().Where(c => c.IsAvailable && !context.Rentals
                .Any(r => r.CarId == c.Id && r.StartDate <= date && r.EndDate >= date));

        [UseProjection]
        [UseFiltering]
        [UseSorting]
        [GraphQLDescription("Method used to get Debtors (Renters with unpaid rentals)")]
        public IQueryable<Renter> GetDebtors([Service] IRenterRepository renterRepository) =>
            renterRepository.GetAllRenters().Where(r => r.Rentals.Any(rental => rental.TotalCost > 0));

        [UseProjection]
        [UseFiltering]
        [UseSorting]
        [GraphQLDescription("Method used to get the total cost of rentals within a date range")]
        public decimal GetTotalCost([Service] IRentalRepository rentalRepository, DateTime startDate, DateTime endDate) =>
            rentalRepository.GetAllRentals().Where(r => r.StartDate >= startDate && r.EndDate <= endDate).Sum(r => r.TotalCost);
    }
}
