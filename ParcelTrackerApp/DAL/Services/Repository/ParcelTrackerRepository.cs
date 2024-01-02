using ParcelTrackerApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ParcelTrackerApp.DAL.Services.Repository
{
    public class ParcelTrackerRepository : IParcelTrackerRepository
    {
        private readonly DatabaseContext _dbContext;
        public ParcelTrackerRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<Parcel> CreateParcel(Parcel parcel)
        {
            try
            {
                var result = _dbContext.Parcels.Add(parcel);
                await _dbContext.SaveChangesAsync();
                return parcel;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<bool> DeleteParcelById(long id)
        {
            try
            {
                _dbContext.Parcels.Remove(_dbContext.Parcels.Single(a => a.Id == id));
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public List<Parcel> GetAllParcels()
        {
            try
            {
                var result = _dbContext.Parcels.ToList();
                return result;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public async Task<Parcel> GetParcelById(long id)
        {
            try
            {
                return await _dbContext.Parcels.FindAsync(id);
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }       

        public async Task<Parcel> UpdateParcel(Parcel model)
        {
            var ex = await _dbContext.Parcels.FindAsync(model.Id);
            try
            {
                await _dbContext.SaveChangesAsync();
                return ex;
            }
            catch (Exception exc)
            {
                throw (exc);
            }
        }
    }
}