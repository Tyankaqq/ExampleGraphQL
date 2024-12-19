using CarRentalGraphQL.Models;
using HotChocolate;
using HotChocolate.Authorization;
using HotChocolate.Types;
using Microsoft.EntityFrameworkCore;

namespace CarRentalGraphQL.Data
{
    public class Mutation
    {
        [Serial]
        public async Task<Post?> UpdatePost([Service] RentalDbContext context, Post model)
        {
            var post = await context.Posts.Where(p => p.Id == model.Id).FirstOrDefaultAsync();
            if (post != null)
            {
                if (!string.IsNullOrEmpty(model.Title))
                    post.Title = model.Title;
                if (!string.IsNullOrEmpty(model.Content))
                    post.Content = model.Content;
                if (!string.IsNullOrEmpty(model.Author))
                    post.Author = model.Author;
                post.CreateAt = DateTime.Now;
                context.Posts.Update(post);
                await context.SaveChangesAsync();
            }
            return post;
        }

        [Serial]
        public async Task DeletePost([Service] RentalDbContext context, Post model)
        {
            var post = await context.Posts.Where(p => p.Id == model.Id).FirstOrDefaultAsync();
            if (post != null)
            {
                context.Posts.Remove(post);
                await context.SaveChangesAsync();
            }
        }

        [Serial]
        public async Task<Post?> InsertPost([Service] RentalDbContext context, string _author, string _content, string _title)
        {
            Post post = new Post()
            {
                Author = _author,
                Content = _content,
                Title = _title
            };
            context.Posts.Add(post);
            await context.SaveChangesAsync();
            return post;
        }

        [Serial]
        public async Task<Car?> UpdateCar([Service] RentalDbContext context, Car model)
        {
            var car = await context.Cars.Where(c => c.Id == model.Id).FirstOrDefaultAsync();
            if (car != null)
            {
                if (!string.IsNullOrEmpty(model.Make))
                    car.Make = model.Make;
                if (!string.IsNullOrEmpty(model.Model))
                    car.Model = model.Model;
                car.IsAvailable = model.IsAvailable;
                context.Cars.Update(car);
                await context.SaveChangesAsync();
            }
            return car;
        }

        [Serial]
        public async Task DeleteCar([Service] RentalDbContext context, Car model)
        {
            var car = await context.Cars.Where(c => c.Id == model.Id).FirstOrDefaultAsync();
            if (car != null)
            {
                context.Cars.Remove(car);
                await context.SaveChangesAsync();
            }
        }

        [Serial]
        public async Task<Car?> InsertCar([Service] RentalDbContext context, string _make, string _model, bool _isAvailable)
        {
            Car car = new Car()
            {
                Make = _make,
                Model = _model,
                IsAvailable = _isAvailable
            };
            context.Cars.Add(car);
            await context.SaveChangesAsync();
            return car;
        }

        [Serial]
        public async Task<Renter?> UpdateRenter([Service] RentalDbContext context, Renter model)
        {
            var renter = await context.Renters.Where(r => r.Id == model.Id).FirstOrDefaultAsync();
            if (renter != null)
            {
                if (!string.IsNullOrEmpty(model.Name))
                    renter.Name = model.Name;
                if (!string.IsNullOrEmpty(model.Email))
                    renter.Email = model.Email;
                context.Renters.Update(renter);
                await context.SaveChangesAsync();
            }
            return renter;
        }

        [Serial]
        public async Task DeleteRenter([Service] RentalDbContext context, Renter model)
        {
            var renter = await context.Renters.Where(r => r.Id == model.Id).FirstOrDefaultAsync();
            if (renter != null)
            {
                context.Renters.Remove(renter);
                await context.SaveChangesAsync();
            }
        }

        [Serial]
        public async Task<Renter?> InsertRenter([Service] RentalDbContext context, string _name, string _email)
        {
            Renter renter = new Renter()
            {
                Name = _name,
                Email = _email
            };
            context.Renters.Add(renter);
            await context.SaveChangesAsync();
            return renter;
        }

        [Serial]
        public async Task<Manager?> UpdateManager([Service] RentalDbContext context, Manager model)
        {
            var manager = await context.Managers.Where(m => m.Id == model.Id).FirstOrDefaultAsync();
            if (manager != null)
            {
                if (!string.IsNullOrEmpty(model.Name))
                    manager.Name = model.Name;
                if (!string.IsNullOrEmpty(model.Email))
                    manager.Email = model.Email;
                context.Managers.Update(manager);
                await context.SaveChangesAsync();
            }
            return manager;
        }

        [Serial]
        public async Task DeleteManager([Service] RentalDbContext context, Manager model)
        {
            var manager = await context.Managers.Where(m => m.Id == model.Id).FirstOrDefaultAsync();
            if (manager != null)
            {
                context.Managers.Remove(manager);
                await context.SaveChangesAsync();
            }
        }

        [Serial]
        public async Task<Manager?> InsertManager([Service] RentalDbContext context, string _name, string _email)
        {
            Manager manager = new Manager()
            {
                Name = _name,
                Email = _email
            };
            context.Managers.Add(manager);
            await context.SaveChangesAsync();
            return manager;
        }

        [Serial]
        public async Task<Service?> UpdateService([Service] RentalDbContext context, Service model)
        {
            var service = await context.Services.Where(s => s.Id == model.Id).FirstOrDefaultAsync();
            if (service != null)
            {
                if (!string.IsNullOrEmpty(model.Name))
                    service.Name = model.Name;
                service.Price = model.Price;
                context.Services.Update(service);
                await context.SaveChangesAsync();
            }
            return service;
        }

        [Serial]
        public async Task DeleteService([Service] RentalDbContext context, Service model)
        {
            var service = await context.Services.Where(s => s.Id == model.Id).FirstOrDefaultAsync();
            if (service != null)
            {
                context.Services.Remove(service);
                await context.SaveChangesAsync();
            }
        }

        [Serial]
        public async Task<Service?> InsertService([Service] RentalDbContext context, string _name, decimal _price)
        {
            Service service = new Service()
            {
                Name = _name,
                Price = _price
            };
            context.Services.Add(service);
            await context.SaveChangesAsync();
            return service;
        }

        [Serial]
        public async Task<Rental?> UpdateRental([Service] RentalDbContext context, Rental model)
        {
            var rental = await context.Rentals.Where(r => r.Id == model.Id).FirstOrDefaultAsync();
            if (rental != null)
            {
                rental.CarId = model.CarId;
                rental.RenterId = model.RenterId;
                rental.StartDate = model.StartDate;
                rental.EndDate = model.EndDate;
                rental.TotalCost = model.TotalCost;
                context.Rentals.Update(rental);
                await context.SaveChangesAsync();
            }
            return rental;
        }

        [Serial]
        public async Task DeleteRental([Service] RentalDbContext context, Rental model)
        {
            var rental = await context.Rentals.Where(r => r.Id == model.Id).FirstOrDefaultAsync();
            if (rental != null)
            {
                context.Rentals.Remove(rental);
                await context.SaveChangesAsync();
            }
        }

        [Serial]
        public async Task<Rental?> InsertRental([Service] RentalDbContext context, int _carId, int _renterId, DateTime _startDate, DateTime _endDate, decimal _totalCost)
        {
            Rental rental = new Rental()
            {
                CarId = _carId,
                RenterId = _renterId,
                StartDate = _startDate,
                EndDate = _endDate,
                TotalCost = _totalCost
            };
            context.Rentals.Add(rental);
            await context.SaveChangesAsync();
            return rental;
        }
    }
}
