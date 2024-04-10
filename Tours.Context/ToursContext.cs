using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using Tours.Context.Models;

namespace Tours.Context
{
    public class ToursContext : DbContext
    {
        public ToursContext() : base("DefaultConnection")
        {

        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<HotelComment> HotelComments { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<ReceivingPoint> ReceivingPoints { get; set; }
        public DbSet<Tour> Tours { get; set; }
        public DbSet<TypeTour> TypeTours { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
