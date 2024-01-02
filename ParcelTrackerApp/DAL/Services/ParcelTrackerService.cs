using ParcelTrackerApp.DAL.Interrfaces;
using ParcelTrackerApp.DAL.Services.Repository;
using ParcelTrackerApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ParcelTrackerApp.DAL.Services
{
    public class ParcelTrackerService : IParcelTrackerService
    {
        private readonly IParcelTrackerRepository _repository;

        public ParcelTrackerService(IParcelTrackerRepository repository)
        {
            _repository = repository;
        }

        public Task<Parcel> CreateParcel(Parcel parcel)
        {
            return _repository.CreateParcel(parcel);
        }

        public Task<bool> DeleteParcelById(long id)
        {
            return _repository.DeleteParcelById(id);
        }

        public List<Parcel> GetAllParcels()
        {
            return _repository.GetAllParcels();
        }

        public Task<Parcel> GetParcelById(long id)
        {
            return _repository.GetParcelById(id);
        }

        public Task<Parcel> UpdateParcel(Parcel model)
        {
            return _repository.UpdateParcel(model);
        }
    }
}