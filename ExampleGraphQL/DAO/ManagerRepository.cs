using CarRentalGraphQL.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentalGraphQL.DAO
{
    public class ManagerRepository : IManagerRepository
    {
        private readonly RentalDbContext db;

        public ManagerRepository(RentalDbContext db)
        {
            this.db = db;
        }

        public IQueryable<Manager> GetAllManagers()
        {
            return db.Managers.AsQueryable();
        }

        public async Task<Manager> AddManager(string name, string email)
        {
            Manager manager = new Manager
            {
                Name = name,
                Email = email
            };
            db.Managers.Add(manager);
            await db.SaveChangesAsync();
            return manager;
        }

        public async Task<Manager> UpdateManager(Manager model)
        {
            var manager = await db.Managers.Where(m => m.Id == model.Id).FirstOrDefaultAsync();
            if (manager != null)
            {
                if (!string.IsNullOrEmpty(model.Name))
                    manager.Name = model.Name;
                if (!string.IsNullOrEmpty(model.Email))
                    manager.Email = model.Email;
                db.Managers.Update(manager);
                await db.SaveChangesAsync();
            }
            return manager;
        }

        public async Task DeleteManager(int id)
        {
            var manager = await db.Managers.Where(m => m.Id == id).FirstOrDefaultAsync();
            if (manager != null)
            {
                db.Managers.Remove(manager);
                await db.SaveChangesAsync();
            }
        }
    }
}
