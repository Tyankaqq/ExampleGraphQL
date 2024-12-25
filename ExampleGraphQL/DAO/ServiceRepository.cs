using CarRentalGraphQL.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentalGraphQL.DAO
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly RentalDbContext db;

        public ServiceRepository(RentalDbContext db)
        {
            this.db = db;
        }

        public IQueryable<Service> GetAllServices()
        {
            return db.Services.AsQueryable();
        }

        public async Task<Service> AddService(string name, decimal price)
        {
            Service service = new Service
            {
                Name = name,
                Price = price
            };
            db.Services.Add(service);
            await db.SaveChangesAsync();
            return service;
        }

        public async Task<Service> UpdateService(Service model)
        {
            var service = await db.Services.Where(s => s.Id == model.Id).FirstOrDefaultAsync();
            if (service != null)
            {
                if (!string.IsNullOrEmpty(model.Name))
                    service.Name = model.Name;
                service.Price = model.Price;
                db.Services.Update(service);
                await db.SaveChangesAsync();
            }
            return service;
        }

        public async Task DeleteService(int id)
        {
            var service = await db.Services.Where(s => s.Id == id).FirstOrDefaultAsync();
            if (service != null)
            {
                db.Services.Remove(service);
                await db.SaveChangesAsync();
            }
        }
    }
}
