
using ParcelTrackerApp.Models;
using System.Data.Entity;


namespace ParcelTrackerApp.DAL
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("DefaultConnection") { }

        public DbSet<Parcel> Parcels { get; set; }
    }
}