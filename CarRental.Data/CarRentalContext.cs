using CarRental.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarRental.Data
{
    public class CarRentalContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Car> Cars { get; set; }

        //One booking can have many cars.
        public DbSet<BookingCar> BookingCars { get; set; }

        protected override void OnModelCreating (ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookingCar>().HasKey(x => new { x.BookingId, x.CarId });

        }
    }
}
