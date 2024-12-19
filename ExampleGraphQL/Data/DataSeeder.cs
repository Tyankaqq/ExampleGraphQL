
using CarRentalGraphQL.Models;
using Faker;

namespace CarRentalGraphQL.Data
{
    public static class DataSeeder
    {
        public static void SeedData(RentalDbContext db)
        {
            if (!db.Posts.Any())
            {
                for (int i = 1; i <= 10; i++)
                {
                    var post = new Post
                    {
                        Title = Lorem.Sentence(),
                        Content = Lorem.Paragraphs(3).FirstOrDefault(),
                        Author = Name.FullName(),
                        CreateAt = DateTime.Now
                    };
                    db.Posts.Add(post);
                    for (int j = 0; j < 10; j++)
                    {
                        var comment = new Comment
                        {
                            Content = Lorem.Sentence(),
                            Author = Name.FullName(),
                            CreatedAt = DateTime.Now,
                            Post = post
                        };
                        db.Comments.Add(comment);
                    }
                }
                db.SaveChanges();
            }

            if (!db.Cars.Any())
            {
                for (int i = 1; i <= 10; i++)
                {
                    var car = new Car
                    {
                        Make = Vehicle.Make(),
                        Model = Vehicle.Model(),
                        IsAvailable = true
                    };
                    db.Cars.Add(car);
                }
                db.SaveChanges();
            }

            if (!db.Renters.Any())
            {
                for (int i = 1; i <= 10; i++)
                {
                    var renter = new Renter
                    {
                        Name = Name.FullName(),
                        Email = Internet.Email()
                    };
                    db.Renters.Add(renter);
                }
                db.SaveChanges();
            }

            if (!db.Managers.Any())
            {
                for (int i = 1; i <= 10; i++)
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

            if (!db.Services.Any())
            {
                for (int i = 1; i <= 10; i++)
                {
                    var service = new Service
                    {
                        Name = Commerce.ProductName(),
                        Price = RandomNumber.Next(100, 1000)
                    };
                    db.Services.Add(service);
                }
                db.SaveChanges();
            }
        }
    }
}
