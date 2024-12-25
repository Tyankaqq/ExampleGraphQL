using CarRentalGraphQL.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace CarRentalGraphQL.DAO
{
    public class RenterRepository : IRenterRepository
    {
        private readonly RentalDbContext db;

        public RenterRepository(RentalDbContext db)
        {
            this.db = db;
        }

        public IQueryable<Renter> GetAllRenters()
        {
            return db.Renters.AsQueryable();
        }

        public async Task<Renter> AddRenter(string name, string email)
        {
            Renter renter = new Renter
            {
                Name = name,
                Email = email
            };
            db.Renters.Add(renter);
            await db.SaveChangesAsync();
            return renter;
        }

        public async Task<Renter> UpdateRenter(Renter model)
        {
            var renter = await db.Renters.Where(r => r.Id == model.Id).FirstOrDefaultAsync();
            if (renter != null)
            {
                if (!string.IsNullOrEmpty(model.Name))
                    renter.Name = model.Name;
                if (!string.IsNullOrEmpty(model.Email))
                    renter.Email = model.Email;
                db.Renters.Update(renter);
                await db.SaveChangesAsync();
            }
            return renter;
        }

        public async Task DeleteRenter(int id)
        {
            var renter = await db.Renters.Where(r => r.Id == id).FirstOrDefaultAsync();
            if (renter != null)
            {
                db.Renters.Remove(renter);
                await db.SaveChangesAsync();
            }
        }
    }
}
