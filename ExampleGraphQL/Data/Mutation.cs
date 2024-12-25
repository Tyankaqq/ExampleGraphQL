using CarRentalGraphQL.Models;
using CarRentalGraphQL.DAO;
using HotChocolate;
using HotChocolate.Authorization;
using HotChocolate.Types;

namespace CarRentalGraphQL.Data
{
    public class Mutation
    {
        [Serial]
        public async Task<Post?> UpdatePost(
            [Service] IPostRepository postRepository,
            Post model)
        {
            return await postRepository.UpdatePost(model);
        }

        [Serial]
        public async Task DeletePost(
            [Service] IPostRepository postRepository,
            Guid id)
        {
            await postRepository.DeletePost(id);
        }

        [Serial]
        public async Task<Post?> InsertPost(
            [Service] IPostRepository postRepository,
            string _author,
            string _content,
            string _title)
        {
            return await postRepository.AddPost(_title, _content, _author);
        }

        [Serial]
        public async Task<Car?> UpdateCar(
            [Service] ICarRepository carRepository,
            Car model)
        {
            return await carRepository.UpdateCar(model);
        }

        [Serial]
        public async Task DeleteCar(
            [Service] ICarRepository carRepository,
            int id)
        {
            await carRepository.DeleteCar(id);
        }

        [Serial]
        public async Task<Car?> InsertCar(
            [Service] ICarRepository carRepository,
            string _make,
            string _model,
            bool _isAvailable)
        {
            return await carRepository.AddCar(_make, _model, _isAvailable);
        }

        [Serial]
        public async Task<Renter?> UpdateRenter(
            [Service] IRenterRepository renterRepository,
            Renter model)
        {
            return await renterRepository.UpdateRenter(model);
        }

        [Serial]
        public async Task DeleteRenter(
            [Service] IRenterRepository renterRepository,
            int id)
        {
            await renterRepository.DeleteRenter(id);
        }

        [Serial]
        public async Task<Renter?> InsertRenter(
            [Service] IRenterRepository renterRepository,
            string _name,
            string _email)
        {
            return await renterRepository.AddRenter(_name, _email);
        }

        [Serial]
        public async Task<Manager?> UpdateManager(
            [Service] IManagerRepository managerRepository,
            Manager model)
        {
            return await managerRepository.UpdateManager(model);
        }

        [Serial]
        public async Task DeleteManager(
            [Service] IManagerRepository managerRepository,
            int id)
        {
            await managerRepository.DeleteManager(id);
        }

        [Serial]
        public async Task<Manager?> InsertManager(
            [Service] IManagerRepository managerRepository,
            string _name,
            string _email)
        {
            return await managerRepository.AddManager(_name, _email);
        }

        [Serial]
        public async Task<Service?> UpdateService(
            [Service] IServiceRepository serviceRepository,
            Service model)
        {
            return await serviceRepository.UpdateService(model);
        }

        [Serial]
        public async Task DeleteService(
            [Service] IServiceRepository serviceRepository,
            int id)
        {
            await serviceRepository.DeleteService(id);
        }

        [Serial]
        public async Task<Service?> InsertService(
            [Service] IServiceRepository serviceRepository,
            string _name,
            decimal _price)
        {
            return await serviceRepository.AddService(_name, _price);
        }

        [Serial]
        public async Task<Rental?> UpdateRental(
            [Service] IRentalRepository rentalRepository,
            Rental model)
        {
            return await rentalRepository.UpdateRental(model);
        }

        [Serial]
        public async Task DeleteRental(
            [Service] IRentalRepository rentalRepository,
            int id)
        {
            await rentalRepository.DeleteRental(id);
        }

        [Serial]
        public async Task<Rental?> InsertRental(
            [Service] IRentalRepository rentalRepository,
            int _carId,
            int _renterId,
            DateTime _startDate,
            DateTime _endDate,
            decimal _totalCost)
        {
            return await rentalRepository.AddRental(_carId, _renterId, _startDate, _endDate, _totalCost);
        }
    }
}
