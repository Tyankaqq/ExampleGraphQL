using Faker;
using CarRentalGraphQL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Bogus;

namespace CarRentalGraphQL.Data
{
    public class DataSeeder
    {
        public static void SeedData(RentalDbContext db)
        {
            Random random = new Random();

            // Добавление данных в таблицу Services
            if (!db.Services.Any())
            {
                for (int i = 0; i < 10; i++)
                {
                    var service = new Service
                    {
                        Name = Lorem.Sentence(2),
                        Price = (decimal)(random.NextDouble() * 100)
                    };
                    db.Services.Add(service);
                }
                db.SaveChanges();
            }

            // Добавление данных в таблицу Renters
            if (!db.Renters.Any())
            {
                for (int i = 0; i < 10; i++)
                {
                    var renter = new Renter
                    {
                        Name = Name.FullName(),
                        Email = Internet.Email(),
                        
                    };
                    db.Renters.Add(renter);
                }
                db.SaveChanges();
            }

            // Добавление данных в таблицу Managers
            if (!db.Managers.Any())
            {
                for (int i = 0; i < 10; i++)
                {
                    var manager = new Manager
                    {
                        Name = Name.FullName(),
                        Email = Internet.Email()
                    };
                    db.Managers.Add(manager);
                }
                db.SaveChanges();
            }

            // Добавление данных в таблицу Cars
            if (!db.Cars.Any())
            {
                for (int i = 0; i < 10; i++)
                {
                    var car = new Car
                    {
                        Make = Vehicle.Make(),
                        Model = Vehicle.Model(),
                        IsAvailable = random.Next(0, 2) == 1
                    };
                    db.Cars.Add(car);
                }
                db.SaveChanges();
            }

            // Добавление данных в таблицу Rentals
            if (!db.Rentals.Any())
            {
                if (!db.Cars.Any() || !db.Renters.Any())
                {
                    throw new InvalidOperationException("The 'Cars' or 'Renters' table is empty. Seed them first.");
                }

                var cars = db.Cars.ToList();
                var renters = db.Renters.ToList();

                for (int i = 0; i < 10; i++)
                {
                    var rental = new Rental
                    {
                        CarId = cars[random.Next(cars.Count)].Id,
                        RenterId = renters[random.Next(renters.Count)].Id,
                        StartDate = DateTime.Now.AddDays(-random.Next(1, 30)),
                        EndDate = DateTime.Now.AddDays(random.Next(1, 30)),
                        TotalCost = (decimal)(random.NextDouble() * 1000)
                    };
                    db.Rentals.Add(rental);
                }
                db.SaveChanges();
            }

            // Добавление данных в таблицу Comments
            if (!db.Comments.Any())
            {
                var posts = db.Posts.ToList();
                for (int i = 0; i < 20; i++)
                {
                    var comment = new Comment
                    {
                        Content = Lorem.Sentence(),
                        Author = Name.FullName(),
                        CreatedAt = DateTime.Now.AddDays(-random.Next(1, 30)),
                        PostId = posts[random.Next(posts.Count)].Id
                    };
                    db.Comments.Add(comment);
                }
                db.SaveChanges();
            }

            // Добавление данных в таблицу Posts
            if (!db.Posts.Any())
            {
                for (int i = 0; i < 10; i++)
                {
                    var post = new Post
                    {
                        Title = Lorem.Sentence(),
                        Content = Lorem.Paragraph(),
                        Author = Name.FullName(),
                        CreateAt = DateTime.Now.AddDays(-random.Next(1, 30))
                    };
                    db.Posts.Add(post);
                }
                db.SaveChanges();
            }
        }
    }
}
