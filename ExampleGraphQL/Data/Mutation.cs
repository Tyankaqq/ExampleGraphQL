using Microsoft.EntityFrameworkCore;
using HotChocolate.Authorization;
using CarRentalGraphQL.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

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
        public async Task<Post?> InsertPost([Service] RentalDbContext context, string author, string content, string title)
        {
            var post = new Post
            {
                Author = author,
                Content = content,
                Title = title
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
        public async Task<Car?> InsertCar([Service] RentalDbContext context, string make, string model, bool isAvailable)
        {
            var car = new Car
            {
                Make = make,
                Model = model,
                IsAvailable = isAvailable
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
        public async Task<Renter?> InsertRenter([Service] RentalDbContext context, string name, string email)
        {
            var renter = new Renter
            {
                Name = name,
                Email = email
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
        public async Task<Manager?> InsertManager([Service] RentalDbContext context, string name, string email)
        {
            var manager = new Manager
            {
                Name = name,
                Email = email
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
        public async Task<Service?> InsertService([Service] RentalDbContext context, string name, decimal price)
        {
            var service = new Service
            {
                Name = name,
                Price = price
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
        public async Task<Rental?> InsertRental([Service] RentalDbContext context, int carId, int renterId, DateTime startDate, DateTime endDate, decimal totalCost)
        {
            var rental = new Rental
            {
                CarId = carId,
                RenterId = renterId,
                StartDate = startDate,
                EndDate = endDate,
                TotalCost = totalCost
            };
            context.Rentals.Add(rental);
            await context.SaveChangesAsync();
            return rental;
        }
    }
}
